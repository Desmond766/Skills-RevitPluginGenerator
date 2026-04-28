---
name: revit-api-lookup
description: Search the packaged Revit 2024 API index for classes, methods, enums, and usage. Use when the user or another skill needs to find a Revit API signature, figure out which method to call, look up a BuiltInParameter/BuiltInCategory, or verify an overload before writing code.
---

# Revit API Lookup

Structured index-based lookup over a packaged Revit 2024 API symbol index. Normal users do **not** need to download `RevitAPI.chm` or run CHM decompilation: the skill ships with `docs/symbols.jsonl` plus clean markdown sidecars under `docs/md/`. Typical lookup is ~10x fewer tokens than raw-HTML grep and much higher precision, because the packaged index contains no navigation chrome.

## When to use this skill

Trigger on:
- "How do I call X in Revit API?"
- "`FilteredElementCollector.OfCategory` 的签名是什么？" / "墙的面积是哪个 `BuiltInParameter`？"
- "What's the signature of `FilteredElementCollector.OfCategory`?"
- "Which `BuiltInParameter` gives wall area?"
- "Is there a method to ... in Revit?"
- Any time the scaffolding skill (`revit-addin-scaffold`) needs an API detail it isn't certain of.

## Bilingual prompt protocol (read first)

The Revit API is English-only, but users prompt in both English and Chinese. This skill stays symmetric through two mechanisms — both automatic:

- **Glossary-driven query expansion.** `search-api.ps1` detects CJK in `-Query` and expands it via `.cursor/skills/glossary.zh-en.md` into the matching English / API identifiers (e.g. `墙` → `Wall`, `OST_Walls`). Results still show the original English signature, since that's what the add-in code must call.
- **`zh` hints on records.** The packaged index contains `"zh":"墙、墙体"` on JSONL records (and a `**中文**: ...` line in sidecars) whose `name` or `parent` maps to a glossary term. A pure-CJK query like `-Query 墙` hits via the `zh` field even without translation.

Practical rules for the agent:

1. **Pass the user's term verbatim**, in whatever language they used, to `-Query`. Don't manually translate — the script does it better because it sees the current glossary.
2. **If you get no results on a CJK query**, add a row to `glossary.zh-en.md` mapping that term to the correct English API name(s), then retry. The glossary is editable at runtime.
3. **When explaining results to a Chinese-prompt user**, translate the English summary back into Chinese. The API identifiers themselves (`Wall.Create`, `RBS_PIPE_DIAMETER_PARAM`) must stay in English — those are the literal tokens that go into the C# code.

## Packaged index

Normal users should find these files already present:

- `docs/symbols.jsonl` - ~38K rows, one per class/method/property/field/event/enum-member.
- `docs/md/*.md` - one clean markdown sidecar per symbol (~500 B each). File names are derived from `Microsoft.Help.Id` (e.g. `Autodesk_Revit_DB_Wall_Width.md`), not CHM GUIDs, so you can grep/edit by API name. If you ever receive an index with GUID filenames (legacy), run `scripts/rename-api-md-sidecars.ps1` once to rewrite names and `symbols.jsonl` together.

Do not ask users to download `RevitAPI.chm` for normal lookup. `RevitAPI.chm` and raw decompiled HTML are maintainer-only inputs used when refreshing the packaged index.

### Verify packaged index

```powershell
Get-Content .cursor/skills/revit-api-lookup/docs/symbols.jsonl | Measure-Object | Select-Object Count
```

Expect ~38,000 symbols.

## Lookup workflow

The helper script has two modes. **Prefer symbol mode (the default)** — it's the one the index was built for and it's what gives you the 10x token savings.

### Symbol mode (default, fast, precise)

```powershell
powershell -ExecutionPolicy Bypass -File .cursor/skills/revit-api-lookup/scripts/search-api.ps1 <SymbolName>
```

Examples:

```powershell
# Look up a method signature
.\search-api.ps1 OfCategoryId

# Look up an enum value scoped to a specific enum
.\search-api.ps1 OST_Walls -Parent BuiltInCategory

# Look up a BuiltInParameter value
.\search-api.ps1 HOST_AREA_COMPUTED -Parent BuiltInParameter

# List all methods on a class
.\search-api.ps1 -Parent FilteredElementCollector -Kind method -Top 50

# List all enum members of BuiltInCategory starting with OST_Wall
.\search-api.ps1 OST_Wall -Parent BuiltInCategory -Kind enumMember -Top 20

# CJK query: script auto-translates via glossary.zh-en.md and prints the
# English/API alternatives it tried. Pass -NoTranslate to disable.
.\search-api.ps1 墙
.\search-api.ps1 管道直径
.\search-api.ps1 吊架
```

Output per match is the clean markdown sidecar: summary + C# signature + parameters + return value + remarks + exceptions. No navigation chrome, no VB/C++ duplicates.

Flags:

| Flag | Effect |
|---|---|
| `<Query>` (positional) | Symbol name. Case-insensitive. Partial match allowed; exact matches rank first. |
| `-Parent <Type>` | Restrict to members of this class/enum (exact match on the declaring type). |
| `-Kind <kind>` | One of `type`, `method`, `property`, `field`, `event`, `enumMember`. |
| `-Top <int>` | Max sidecars to show. Default 8. |
| `-Symbol` | Force symbol mode (default when `-Fulltext` is not set). |
| `-NoTranslate` | Skip glossary-based CJK query expansion. Useful only if you want to grep for a literal Chinese substring appearing in a sidecar. |
| `-GlossaryPath <file>` | Override the glossary path. Defaults to `.cursor/skills/glossary.zh-en.md` (parent of this skill). |

### Fulltext mode (maintainer-only fallback for prose queries)

When the query isn't a symbol name ("how does ExternalEvent work", "explain transaction regeneration"), raw HTML fulltext can help, but it requires a local maintainer-generated `docs/html/` folder from `RevitAPI.chm`. Do not require this from ordinary users; prefer symbol mode plus `cheatsheet.md` for packaged-skill use.

```powershell
powershell -ExecutionPolicy Bypass -File .cursor/skills/revit-api-lookup/scripts/search-api.ps1 "ExternalEvent Raise" -Fulltext
```

Fulltext mode strips Sandcastle nav chrome and drops VB/C++ signatures before showing hits, and ranks files by match density. Still expect 2-5x more tokens than symbol mode.

## Maintainer refresh workflow

Only maintainers need this when updating the packaged Revit API index:

1. Place `RevitAPI.chm` from the Revit 2024 SDK beside this skill, or pass `-ChmPath`.
2. Run `powershell -ExecutionPolicy Bypass -File .cursor/skills/revit-api-lookup/scripts/decompile-chm.ps1`.
3. Run `powershell -ExecutionPolicy Bypass -File scripts\build-api-index.ps1 -Force`.
4. Commit `docs/symbols.jsonl` and `docs/md/**`; do **not** commit `RevitAPI.chm` or `docs/html/`.

### When both fail

- Check the [cheatsheet](./cheatsheet.md) for common patterns — faster than any grep.
- Public mirror: `https://www.revitapidocs.com/2024/`.
- Some internal types have no HelpId (fall through to fulltext mode).

## Cheatsheet

For the 20% of APIs used 80% of the time (collectors, transactions, selection, parameters, units, events) see [`cheatsheet.md`](./cheatsheet.md).

## What NOT to do

- Do **not** ask normal users to download `RevitAPI.chm` or run decompilation; use the packaged symbol index.
- Do **not** read the entire `./docs/` folder or `symbols.jsonl` — stream via the search script.
- Do **not** paste raw HTML or full sidecar contents into chat; summarize the signature and a 1-2 sentence description.
- Do **not** invent method names. If symbol mode returns no match, try fulltext, then admit ignorance — don't hallucinate.
- Do **not** rely on memory for `BuiltInParameter` / `BuiltInCategory` enum values; look them up. They change subtly across Revit versions.
