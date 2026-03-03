# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Log4Merge is a Windows desktop tool (WinForms, .NET 4.7.2) for viewing multiple log4net log files merged by timestamp, with text highlighting, filtering, and tail-mode support.

## Build Commands

```bash
# Build (Debug) — use full MSBuild path in bash on Windows
"/c/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/amd64/MSBuild.exe" "/c/Repos/Log4Merge/Log4Merge.sln" -p:Configuration=Debug -verbosity:minimal 2>&1

# Build (Release)
"/c/Program Files/Microsoft Visual Studio/2022/Professional/MSBuild/Current/Bin/amd64/MSBuild.exe" "/c/Repos/Log4Merge/Log4Merge.sln" -p:Configuration=Release -verbosity:minimal 2>&1

# Restore NuGet packages (if needed)
nuget restore Log4Merge.sln
```

Output goes to `Log4Merge\bin\Debug\` or `Log4Merge\bin\Release\`. There are no automated tests.

## Solution Structure

Two projects:
- **`Log4Merge`** — WinForms UI application
- **`Log4Merge.Domain`** — Class library (`Log4Merge.Domain\Log4Merge.Domain.csproj`) with all business logic

## Architecture

### Domain Layer (`Log4Merge.Domain`)

**Models** (`Log4Merge.Domain\Models\`, namespace `Log4Merge.Domain.Models`):
- `LogEntry` — Immutable log line: `SourceFileName`, `LineNumber`, `TimeStamp` (UTC), `Message`, `ShortMessage`, `LogLevel`. Has a static `Settings` property (set once at startup by the WinForms host) that drives timestamp formatting, level regex, and visible line length.
- `HighlightEntry` — Highlight rule: regex `Pattern`, `BackColor`, `ForeColor`. `IsMatch()` uses case-insensitive regex.
- `FilterCriteria` — Non-destructive filter state: `FilterText` (pipe-separated), `EnabledLevels` (`HashSet<string>`; `null` = all; `""` = "other"/unknown), `FromUtc`/`ToUtc`.
- `ColorJsonConverter` — `JsonConverter` for `System.Drawing.Color` serialization.
- `LoadProgress` — Progress reporting DTO for async file loading.

**Settings** (`Log4Merge.Domain\Settings\`):
- `ILogParserSettings` — Interface with `TimeStampFormat`, `LevelRegexPattern`, `GridVisibleLineLength`.

**Services** (`Log4Merge.Domain\Services\`):
- `LogParser` / `ILogParser` — Parses log4net files line-by-line. Handles multi-line entries, encoding fallback (UTF-8 → system default), and incremental reads from a byte offset for tail mode.
- `LogRepository` — Wraps `BindingList<LogEntry>`; all mutations go through it (`AddRange`, `DeduplicateAndSort`, `RemoveEntries`, `KeepHighlighted`, etc.).
- `LogFilter` (static) — `IsMatch(LogEntry, FilterCriteria)` — evaluates text, level, and time-range filters.
- `SessionService` / `ISessionService` — Saves/loads the list of loaded file paths.
- `HighlightProfileService` / `IHighlightProfileService` — Saves/loads highlight rules as JSON.

### UI Layer (`Log4Merge`)

**Key files:**
- `Program.cs` — Entry point; passes CLI args to `FormMainForm`.
- `MainForm.cs` / `MainForm.Designer.cs` — All UI logic. Holds `_repository` (`LogRepository`), `_highlightEntries` (`BindingList<HighlightEntry>`), and `_filterText`. Services are instantiated as fields.
- `Infrastructure\AppLogParserSettings.cs` — Adapts `Properties.Settings.Default` to `ILogParserSettings`.
- `HighlightPreferencesDialog.cs` — Manages highlight rules (regex + colors), import/export JSON.
- `SettingsForm.cs` — User-configurable settings (timestamp format, level regex, line length).
- `FileSelectionDialog.cs` — Programmatic dialog for multi-file drag-and-drop selection.

**Startup sequence:**
1. `FormMainForm` ctor sets `LogEntry.Settings = s_settings` before `InitializeComponent()`.
2. `FormMainForm_Shown` loads highlight profiles, then either loads CLI-arg files or offers session restore.
3. `LoadLogFilesAsync` parses files on a background thread (reporting `LoadProgress`), then calls `_repository.DeduplicateAndSort()` + `BindLogViewerDataGrip()` on the UI thread.

### Data Flow

1. Files loaded → `_logParser.ParseLogFile()` per file → deduplicated + sorted in `_repository`
2. `BindLogViewerDataGrip()` binds `_repository.Entries` to `gridLogsViewer`, applies highlight colors row-by-row, then calls `ApplyFilter()`
3. `ApplyFilter()` builds a `FilterCriteria` from UI state and calls `LogFilter.IsMatch()` per row, setting `row.Visible` — the underlying `_repository.Entries` list is never modified by filtering

### Grid Columns (in order)

`columnTimeStamp` (0), `columnSourceFileName` (1), `columnLineNumber` (2), `columnLogLevel` (3), `columnTimeInvisible` (hidden, raw UTC for sorting), `columnMessageInvisible` (hidden, full message), `columnMessage` (fill, shows `ShortMessage`)

### Filtering (non-destructive, overlay panel)

All filter controls live in `filterOverlayPanel` — a floating panel anchored top-right over the grid, toggled by the "Filters ▾" menu item. Contains: text search box (pipe-separated, Ctrl+F to focus), level checkboxes (ERROR/FATAL/WARN/INFO/DEBUG/TRACE/other), time-range pickers, and the Tail Mode toggle. `ApplyFilter()` ANDs all active criteria via `LogFilter.IsMatch()`.

### Destructive Filtering (right-click context menu on grid)

Modifies `_repository.Entries` permanently:
- Remove selected / unselected rows
- Remove rows before/after selected row (timestamp-based)
- Remove by text (pipe-separated, case-insensitive substring)
- Remove highlighted / keep highlighted (based on `_highlightEntries`)

### Tail Mode

Timer-driven; reads new bytes from each loaded file using `ParseLogFileFromPosition()`, appends to repository, re-sorts, and re-applies filter. File positions tracked in `_tailFilePositions`.

### Save Formats

- **Save As** (generic): `timestamp|sourceFile, Line:N|message` per line
- **Save As Log** (.log): `timestamp message` per line — re-loadable as log4net format

## Dependencies

- **Newtonsoft.Json 13.0.3** — highlight rule JSON import/export only (used in `HighlightProfileService` and `HighlightPreferencesDialog`)
- **Microsoft.VisualBasic** — `Interaction.InputBox` in "Remove By Text"
