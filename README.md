# Log4Merge

> **Merge, search, and triage multiple log4net log files — sorted by timestamp, in one view.**

Log4Merge is a lightweight Windows desktop tool for developers and support engineers who need to correlate activity across several log files simultaneously. Load any number of log4net `.log` files; the tool merges every line into a single chronological grid, deduplicates identical entries, and lets you slice the data without touching the original files.

---

## Contents

- [Quick Start](#quick-start)
- [Opening Log Files](#opening-log-files)
- [Drag & Drop](#drag--drop)
- [Session Restore](#session-restore)
- [The Log Viewer Grid](#the-log-viewer-grid)
- [Filters Panel](#filters-panel)
- [Log Level Filter](#log-level-filter)
- [Live Search / Filter Bar](#live-search--filter-bar)
- [Time Range Filter](#time-range-filter)
- [Auto-Refresh / Tail Mode](#auto-refresh--tail-mode)
- [Text Highlighting](#text-highlighting)
- [Row Removal (Destructive Filters)](#row-removal-destructive-filters)
- [Saving Results](#saving-results)
- [Copying to Clipboard](#copying-to-clipboard)
- [Status Bar](#status-bar)
- [Keyboard Shortcuts](#keyboard-shortcuts)
- [Log Format Reference](#log-format-reference)
- [Building from Source](#building-from-source)
- [License](#license)

---

## Quick Start

1. Launch `Log4Merge.exe`
2. **File → Open Log4net logs…** — pick one or more `.log` files
3. All lines merge into a single grid, sorted by timestamp
4. Click **Filters ▾** (top-right of the menu bar) to open the filter panel — search, level toggles, time range, and Tail Mode are all there
5. Highlight rules from your last session are restored automatically on startup

---

## Opening Log Files

| Method | Description |
|---|---|
| **File → Open Log4net logs…** | Clears current view and loads selected files |
| **File → Append Log4net logs…** | Adds files on top of what is already loaded (good for incremental analysis) |
| **Command-line arguments** | `Log4Merge.exe app1.log app2.log` — files load on startup |
| **Drag & Drop** | Drop `.log` files or a folder onto the window — see [Drag & Drop](#drag--drop) |

After loading, entries are automatically **deduplicated** (identical timestamp + message pairs from overlapping files are merged) and **sorted chronologically**.

Multi-line log entries (stack traces, exception details) are supported — continuation lines without a timestamp are appended to the preceding entry's message.

Files are loaded asynchronously with a progress bar in the status strip so the UI stays responsive during large loads.

The open dialog remembers the last directory you used across sessions.

---

## Drag & Drop

You can drag one or more `.log` files — or an entire folder — and drop them directly onto the Log4Merge window.

| What you drop | Behaviour |
|---|---|
| **Single `.log` file** | Loaded immediately, replacing the current view |
| **Multiple `.log` files** | A file-selection dialog lists all dropped files; tick the ones you want, then choose **Open** (replace) or **Append** |
| **Folder** | Log4Merge scans the folder for `.log` files and presents them in the same file-selection dialog |

If any of the selected files cannot be parsed (unrecognised format, access error, etc.) an alert is shown after loading completes listing the failed files. Successfully parsed files are still loaded normally.

---

## Session Restore

On startup, if no files are passed via command line, Log4Merge checks whether a previous session was saved. If it finds one, a dialog asks whether to reopen those files:

- Click **Yes** to reload all files from the last session
- Click **No** to start with an empty view
- Files that have been deleted since the last session are silently skipped
- The session is updated automatically every time files are loaded or appended

Sessions are stored in `%APPDATA%\Log4Merge\session.json`.

---

## The Log Viewer Grid

Each row represents one parsed log entry with five visible columns:

| Column | Description |
|---|---|
| **TimeStamp** | Parsed timestamp in `yyyy-MM-dd HH:mm:ss,fff` format |
| **Log Level** | Severity extracted from the message text (ERROR, FATAL, WARN, INFO, DEBUG, TRACE) |
| **Source File** | Full path to the file the entry came from |
| **Line** | Line number within the source file |
| **Log Message** | First 100 characters of the message. Double-click to expand by 20 characters at a time |

The grid supports **multi-row selection** (click + Shift/Ctrl) which is used by several removal operations.

---

## Filters Panel

All non-destructive filters live in a floating **Filters** panel that hovers over the top-right corner of the grid.

**Open / close** the panel by clicking **Filters ▾** in the menu bar (right-aligned), or press **Ctrl+F**. Close it with the **×** button in the panel header or by clicking **Filters ▾** again.

The panel contains (top to bottom):

| Section | Description |
|---|---|
| **Text search** | Search box + Clear button — hides non-matching rows as you type |
| **Log level toggles** | Checkboxes for ERROR, FATAL, WARN, INFO, DEBUG, TRACE, other |
| **Time range** | From / To date-time pickers + Clear button |
| **Tail Mode** | Checkbox to enable live file watching |

When one or more filters are active the menu item badge updates — e.g. **Filters (2) ▾** — so you always know filters are in effect even when the panel is closed.

All filters are non-destructive: they hide rows without removing them from the underlying data, and they all combine with each other (AND logic).

---

## Log Level Filter

Inside the Filters panel, a row of checkboxes lets you toggle visibility by severity level:

```
[ERROR] [FATAL] [WARN] [INFO] [DEBUG] [TRACE] [other]
```

- Uncheck a level to **hide** all rows at that level; check it again to **show** them
- **other** covers entries where no recognisable level was detected
- The level filter combines with the text search and time range filters — all active filters must match for a row to be visible

---

## Live Search / Filter Bar

Inside the Filters panel, a text box provides non-destructive search. Rows are **hidden**, not deleted — the underlying data is always preserved.

### How it works

- **Auto-applies as you type** with a 400 ms debounce — no button press needed
- **Clear button** removes the filter and shows all rows
- **Ctrl+F** opens the Filters panel and focuses the search box

### Multi-pattern search

Separate patterns with `|` to show rows matching **any** of them:

```
NullReferenceException|timeout|connection refused
```

---

## Time Range Filter

Inside the Filters panel, two date/time pickers let you narrow the visible rows to a specific window of time without deleting anything.

- Set a **From** and/or **To** date/time to hide rows outside that range
- Click **Clear** to remove the range and show all rows again
- Combines with the text and level filters

This complements the destructive **Remove Before/After Selected** context menu operations — use the time range filter when you want to explore a window without committing to a removal.

---

## Auto-Refresh / Tail Mode

Enable **Tail Mode** via the checkbox at the bottom of the Filters panel to watch the loaded log files for new content in real time.

- When active, a `FileSystemWatcher` monitors every loaded file for changes
- New lines appended to any file are parsed and added to the grid automatically
- The status bar shows when Tail Mode is active
- Uncheck the checkbox to stop watching

Tail Mode is useful when monitoring a running application — load the log files once, enable Tail Mode, and watch new entries appear without reloading.

---

## Text Highlighting

**Preferences → Highlighting…** opens the highlight rules editor.

Each rule defines:
- A **regex pattern** (case-insensitive) to match against the log message
- A **background color** for matching rows
- A **foreground (text) color** for matching rows

The pattern list renders each entry using its own colors so you can see exactly how it will look in the grid.

### Managing rules

| Action | How |
|---|---|
| Add a rule | Enter pattern, pick colors, click **Add** |
| Edit a rule | Select it in the list, modify pattern/colors in-place |
| Remove a rule | Select one or more entries, click **Remove** |
| Export rules | **Export** → saves as a `.json` file for sharing |
| Import rules | **Import** → loads from a previously exported `.json` file |

### Auto-save / Auto-load

Highlight rules are **automatically saved** to `%APPDATA%\Log4Merge\highlights.json` every time you close the Highlighting dialog with OK. They are **automatically restored** the next time you launch the app — no manual import needed.

Profiles can still be exported and imported manually to share rules across machines.

---

## Row Removal (Destructive Filters)

Right-click anywhere in the grid to open the context menu. These operations **permanently remove** rows from the current view (they do not affect the source files).

### By highlight status

| Menu item | Effect |
|---|---|
| **Remove Highlighted** | Deletes all rows that match any highlight rule |
| **Remove Unhighlighted** | Keeps only rows that match at least one highlight rule; removes everything else |

### By selection

| Menu item | Effect |
|---|---|
| **Remove Selected** | Deletes the currently selected rows |
| **Remove Unselected** | Keeps only the selected rows; removes everything else |
| **Delete key** | Same as Remove Selected |

### By timestamp

Select a row first, then right-click:

| Menu item | Effect |
|---|---|
| **Remove Before Selected** | Removes all rows with a timestamp earlier than the selected row |
| **Remove After Selected** | Removes all rows with a timestamp later than the selected row |

### By text pattern

**Remove By Text Pattern…** opens an input box where you enter pipe-separated search terms (case-insensitive substring match). All rows whose message contains **any** of the terms are removed:

```
healthcheck|ping|OPTIONS /api
```

---

## Saving Results

After filtering/trimming the grid to only what matters, export the result via the **File** menu.

| Option | Format | Use case |
|---|---|---|
| **File → Save As…** | `timestamp\|sourceFile, Line:N\|message` | Human-readable audit trail with source attribution |
| **File → Save As Log4Net** | `timestamp message` | Log4net-compatible format — can be re-loaded into Log4Merge |

Both options are disabled until at least one file is loaded.

---

## Copying to Clipboard

Right-click → **Copy** copies the selected cells to the clipboard.

- For the **Log Message** column, the **full message** is copied (not the truncated 100-character preview shown in the grid).
- For other columns, the displayed cell value is copied.
- Multiple selected cells are joined with newlines, ordered by row.

---

## Status Bar

The status strip at the bottom shows live metrics for the current view:

| Segment | Description |
|---|---|
| **Lines** | `X / Y (filtered)` when a filter is active; `Y` when all rows are visible |
| **Highlighted** | Number of rows matching at least one highlight rule |
| **Time span** | Earliest to latest timestamp across all visible entries |
| **Sources** | Number of distinct source files loaded |

---

## Keyboard Shortcuts

| Shortcut | Action |
|---|---|
| `Ctrl+F` | Open the Filters panel (if hidden) and focus the search box |
| `Escape` (in search box) | Clear the text filter |
| `Delete` (in grid) | Remove all selected rows |

---

## Log Format Reference

Log4Merge parses the standard log4net one-line format:

```
yyyy-MM-dd HH:mm:ss,fff <message text...>
```

**Example:**
```
2024-03-15 14:23:01,456 [ERROR] MyApp.Service - Database connection failed: timeout after 30s
2024-03-15 14:23:01,457    at MyApp.Data.DbContext.Connect() in DbContext.cs:line 142
2024-03-15 14:23:01,458    at MyApp.Service.Start() in Service.cs:line 67
```

- The first 23 characters must be a valid `yyyy-MM-dd HH:mm:ss,fff` timestamp.
- Lines that do not start with a valid timestamp are treated as continuations and appended to the previous entry's message (multi-line / stack trace support).
- Timestamps are stored internally as UTC.
- The timestamp format can be changed in **Preferences → Settings…** if your logs use a different pattern.

---

## Building from Source

**Requirements:** Visual Studio 2022, .NET Framework 4.7.2, MSBuild

```bash
# Debug build
msbuild Log4Merge.sln /p:Configuration=Debug

# Release build
msbuild Log4Merge.sln /p:Configuration=Release
```

Output goes to `bin\Debug\` or `bin\Release\`. There is no test suite.

**Dependencies** (via NuGet):
- `Newtonsoft.Json 13.0.3` — highlight profile JSON import/export and auto-save
- `Microsoft.VisualBasic` — `Interaction.InputBox` for the Remove By Text dialog

---

## License

MIT
