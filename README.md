# Log4Merge

> **Merge, search, and triage multiple log4net log files — sorted by timestamp, in one view.**

Log4Merge is a lightweight Windows desktop tool for developers and support engineers who need to correlate activity across several log files simultaneously. Load any number of log4net `.log` files; the tool merges every line into a single chronological grid, deduplicates identical entries, and lets you slice the data without touching the original files.

---

## Contents

- [Quick Start](#quick-start)
- [Opening Log Files](#opening-log-files)
- [The Log Viewer Grid](#the-log-viewer-grid)
- [Live Search / Filter Bar](#live-search--filter-bar)
- [Text Highlighting](#text-highlighting)
- [Row Removal (Destructive Filters)](#row-removal-destructive-filters)
- [Saving Results](#saving-results)
- [Copying to Clipboard](#copying-to-clipboard)
- [Keyboard Shortcuts](#keyboard-shortcuts)
- [Log Format Reference](#log-format-reference)
- [Building from Source](#building-from-source)
- [License](#license)

---

## Quick Start

1. Launch `Log4Merge.exe`
2. **File → Open Log4net logs…** — pick one or more `.log` files
3. All lines merge into a single grid, sorted by timestamp
4. Use the **Search bar** at the top to filter live, or right-click rows to remove noise

---

## Opening Log Files

| Method | Description |
|---|---|
| **File → Open Log4net logs…** | Clears current view and loads selected files |
| **File → Append Log4net logs…** | Adds files on top of what is already loaded (good for incremental analysis) |
| **Command-line arguments** | `Log4Merge.exe app1.log app2.log` — files load on startup |
| **Windows Shell Extension** | Right-click any `.log` file in Explorer → *Open with Log4Merge* |

After loading, entries are automatically **deduplicated** (identical timestamp + message pairs from overlapping files are merged) and **sorted chronologically**.

Multi-line log entries (stack traces, exception details) are supported — continuation lines without a timestamp are appended to the preceding entry's message.

---

## The Log Viewer Grid

Each row represents one parsed log entry with four visible columns:

| Column | Description |
|---|---|
| **TimeStamp** | Parsed timestamp in `yyyy-MM-dd HH:mm:ss,fff` format |
| **Source File** | Full path to the file the entry came from |
| **Line** | Line number within the source file |
| **Log Message** | First 100 characters of the message. Double-click to expand by 20 characters at a time |

The grid supports **multi-row selection** (click + Shift/Ctrl) which is used by several removal operations.

---

## Live Search / Filter Bar

A non-destructive search bar sits above the grid. Rows are **hidden**, not deleted — the underlying data is always preserved.

```
Search: [________________________] [Filter] [Clear]
```

### How it works

- **Auto-applies as you type** with a 400 ms debounce — no button press needed
- **Filter button** or **Enter** applies the filter immediately
- **Clear button** or **Escape** removes the filter and shows all rows
- **Ctrl+F** focuses the search box from anywhere in the app

### Multi-pattern search

Separate patterns with `|` to show rows matching **any** of them:

```
NullReferenceException|timeout|connection refused
```

### Status bar

The status strip at the bottom updates to reflect the current view:

```
Lines: 342 / 12,847 (filtered)    ← filtered mode
Lines: 12,847                      ← all rows visible
```

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
| Export rules | **Export** → saves as a `.json` file |
| Import rules | **Import** → loads from a previously exported `.json` file |

Highlight profiles can be shared across machines via the export/import JSON feature.

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

## Keyboard Shortcuts

| Shortcut | Action |
|---|---|
| `Ctrl+F` | Focus the Search bar and select all text |
| `Enter` (in Search bar) | Apply filter immediately |
| `Escape` (in Search bar) | Clear filter and show all rows |
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
- `Newtonsoft.Json 13.0.3` — highlight profile JSON import/export
- `Microsoft.VisualBasic` — `Interaction.InputBox` for the Remove By Text dialog

---

## License

MIT
