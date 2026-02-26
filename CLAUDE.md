# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Log4Merge is a Windows desktop tool (WinForms, .NET 4.7.2) for viewing multiple log4net log files merged by timestamp with text highlighting support.

## Build Commands

```bash
# Build (Debug)
msbuild Log4Merge.sln /p:Configuration=Debug

# Build (Release)
msbuild Log4Merge.sln /p:Configuration=Release

# Restore NuGet packages (if needed)
nuget restore Log4Merge.sln
```

The output goes to `bin\Debug\` or `bin\Release\`. There are no automated tests in this project.

## Architecture

This is a single-project WinForms application with no test suite.

### Key Files

- **`Program.cs`** — Entry point; passes command-line args (file paths) to `FormMainForm`.
- **`MainForm.cs`** / `MainForm.Designer.cs` — Primary UI (`FormMainForm`). Manages `_logEntries` (`BindingList<LogEntry>`) and `_highlightEntries` (`BindingList<HighlightEntry>`). All filtering and display logic lives here.
- **`HighlightPreferencesDialog.cs`** — Dialog for managing highlight rules (regex patterns + colors). Supports import/export as JSON.
- **`Log4MergeShellExtension.cs`** — Windows Shell COM extension (`IContextMenu` + `IShellExtInit`) that adds "Open with Log4Merge" to Explorer's right-click menu. Uses P/Invoke for Win32 APIs.
- **`Domain/LogEntry.cs`** — Model for a single log line: `SourceFileName`, `LineNumber`, `TimeStamp` (UTC), `Message`, `ShortMessage` (first 100 chars).
- **`Domain/HighlightEntry.cs`** — Model for a highlight rule: regex `Pattern`, `BackColor`, `ForeColor`. `IsMatch()` uses case-insensitive regex.
- **`Domain/ColorJsonConverter.cs`** — Custom `JsonConverter` for `System.Drawing.Color` serialization (used in highlight import/export).

### Log Parsing

`AppendLogsFromTheFile()` in `MainForm.cs` parses log4net format line by line:
- Lines starting with a timestamp (`yyyy-MM-dd HH:mm:ss,fff`, first 23 chars) create new `LogEntry` objects.
- Lines without a timestamp are appended to the previous entry's `Message` (multi-line log support).
- Timestamps are stored as UTC via `ToUniversalTime()`.

### Data Flow

1. Files opened via menu or passed as CLI args → `AppendLogsFromTheFile()` per file
2. All entries merged, deduplicated (`Distinct()`), sorted by `TimeStamp`
3. `BindLogViewerDataGrip()` binds to `gridLogsViewer` (DataGridView) and applies highlight colors row-by-row

### Filtering Operations (right-click context menu on grid)

- Remove selected / unselected rows
- Remove rows before/after a selected row (timestamp-based)
- Remove by text (pipe-separated patterns, case-insensitive substring match)
- Remove highlighted / remove unhighlighted (based on `_highlightEntries`)

### Save Formats

- **Save As** (generic): `timestamp|sourceFile, Line:N|message` per line
- **Save As Log** (.log): `timestamp message` per line — re-loadable as log4net format

## Dependencies

- **Newtonsoft.Json 13.0.3** (`packages\Newtonsoft.Json.13.0.3\`) — used only for highlight rule JSON import/export
- **Microsoft.VisualBasic** — used for `Interaction.InputBox` in the "Remove By Text" feature
