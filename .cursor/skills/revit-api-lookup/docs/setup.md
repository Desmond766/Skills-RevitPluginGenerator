# Setup (API lookup)

## Packaged index

Normal use requires:

- `symbols.jsonl` (~38k symbol rows)
- `md/` short sidecar files (`s*.md`) referenced by the `"md"` field in each JSONL line

## Tools

- **ripgrep (`rg`)** on `PATH`, or Cursor/VS Code’s bundled `rg.exe` (the script discovers it).
- **PowerShell** to run `../scripts/search-api.ps1`.

## First run

From the workspace root:

```powershell
powershell -ExecutionPolicy Bypass -File .cursor/skills/revit-api-lookup/scripts/search-api.ps1 OfCategoryId
```

Optional bilingual expansion uses `../../glossary.zh-en.md` by default.

See `../templates/config.yaml` for suggested query defaults.
