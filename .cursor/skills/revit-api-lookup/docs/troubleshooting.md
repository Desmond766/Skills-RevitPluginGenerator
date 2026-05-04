# Troubleshooting (API lookup)

| Issue | What to do |
|--------|------------|
| `symbols.jsonl not found` | Restore the packaged `docs/symbols.jsonl` and `docs/md/` tree; do not commit CHM/HTML for normal use. |
| `rg.exe not found` | Install ripgrep or open the project from VS Code/Cursor so the script can locate bundled `rg`. |
| No symbol hits (CJK query) | Add the term to `glossary.zh-en.md` and retry; pass the user’s phrase verbatim to `-Query`. |
| Prose question (“how does X work?”) | Prefer **symbol mode** first; use `-Fulltext` only if you maintain `docs/html/` from `RevitAPI.chm`. |
| Wrong overload | Narrow with `-Parent` / `-Kind`; check **`docs/cheatsheet.md`** for common patterns. |
