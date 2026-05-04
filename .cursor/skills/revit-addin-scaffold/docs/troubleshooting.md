# Troubleshooting (scaffold)

| Issue | Mitigation |
|--------|------------|
| No sample match in `INDEX.md` | Broaden `rg` patterns (EN \| ZH); extend glossary; fall back to `docs/patterns.md` + **revit-api-lookup**. |
| Ported code won't compile | Revit 2024 deprecations (`DisplayUnitType`, `ParameterType`, etc.) — see migration notes in `SKILL.md`; verify symbols with **revit-api-lookup**. |
| Wrong UI language | Match ribbon/dialog strings to the user’s prompt language (see bilingual protocol in `SKILL.md`). |
| .NET version error | Must stay on **.NET Framework 4.8**, **x64** only — not .NET 6/8. |
