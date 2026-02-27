# Log4Merge — Planned Features

This document tracks feature ideas identified through codebase analysis.

---

## [Implemented]1. Live Search / Non-Destructive Filter Bar
A text box + "Filter" button above the grid that hides non-matching rows without deleting them. A "Clear Filter" button restores all rows. Currently all filter operations are destructive (rows are permanently removed from `_logEntries`).

## 2. Log Level Parsing + Column
Parse log level (ERROR, WARN, INFO, DEBUG) from the message text and show it as a dedicated column. Add toolbar checkboxes or a dropdown to toggle which levels are visible.

## 3. Persist Highlight Profiles & Last Directory
- Auto-save highlight entries to `%AppData%\Log4Merge\highlights.json` on dialog OK, auto-load on startup.
- Remember the last used directory in the open dialog (currently hardcoded to `C:\tmp\logs-test\sideGall`).

## 4. Session Restore
Remember which log files were loaded (file paths saved to `%AppData%\Log4Merge\session.json`). On startup, offer to re-open the last session. Useful when iterating on the same set of logs.

## 5. Async File Loading with Progress
Large log files currently freeze the UI (synchronous `File.ReadAllLines`). Load files on a background thread with a progress bar in the status strip. Shows "Loading X of Y files..." during load.

## 6. Auto-Refresh / Tail Mode
Watch loaded files with a `FileSystemWatcher` and append new lines as they are written. A toggle button in the toolbar to enable/disable live tailing. Useful for monitoring active applications.

## 7. Find & Highlight (Ctrl+F)
A find bar (like a browser's Ctrl+F) that temporarily highlights matching rows in a distinct color and jumps between matches. Does not change `_logEntries`, purely visual navigation.

## 8. Keep By Text Pattern
A "Keep rows containing..." operation — the inverse of the current "Remove By Text Pattern". The current workaround requires using Highlight + Remove Unhighlighted, which is indirect.

## 9. Regex Support in Remove / Keep By Text
Current "Remove By Text" uses simple substring matching (`.Contains()`). Allow toggling to full regex matching, consistent with the highlight system which already uses `Regex`.

## 10. Time Range Picker (Non-Destructive)
A date/time range control (two datetime pickers) in the toolbar that hides rows outside the range without removing them. Complements the current destructive "Remove Before/After Selected".

## 11. Export to HTML / CSV
Add export options that produce structured output:
- **HTML**: color-coded table with actual highlight colors applied (useful for sharing with others who don't have the tool)
- **CSV**: proper RFC 4180 CSV with headers

## 12. Status Bar Enhancements
Show additional stats in the status strip:
- Count of currently highlighted rows (e.g., "Highlighted: 42 / 1,203")
- Time span of loaded logs (earliest to latest timestamp)
- Number of source files loaded

## 13. Copy Full Row as Log Line
Right-click → "Copy as Log Line" copies the row in the original log4net format (`timestamp message`) rather than the current generic cell copy.

## 14. Bookmarks / Annotations
Let users mark specific rows with a colored dot and an optional note. Bookmarks persist in the session. A "Next/Previous Bookmark" keyboard shortcut (F2/Shift+F2) for navigation.
