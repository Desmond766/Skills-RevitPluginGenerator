---
name: revit-api-lookup
description: Search the Revit 2024 API documentation (decompiled from RevitAPI.chm) for classes, methods, enums, and usage. Use when the user or another skill needs to find a Revit API signature, figure out which method to call, look up a BuiltInParameter/BuiltInCategory, or verify an overload before writing code. Also covers one-time CHM decompilation setup.
---

# Revit API Lookup

Structured index-based lookup over the decompiled Revit 2024 API help (`RevitAPI.chm`). A one-time preprocessor converts the 420 MB of noisy Sandcastle HTML into a 12 MB JSONL symbol index plus ~36K clean markdown sidecars (~500 B each). Typical lookup is ~10x fewer tokens than raw-HTML grep and much higher precision, because the index contains no navigation chrome.

## When to use this skill

Trigger on:
- "How do I call X in Revit API?"
- "What's the signature of `FilteredElementCollector.OfCategory`?"
- "Which `BuiltInParameter` gives wall area?"
- "Is there a method to ... in Revit?"
- Any time the scaffolding skill (`revit-addin-scaffold`) needs an API detail it isn't certain of.

## First-run setup (once per machine)

### Step 1: Place the CHM file

Drop `RevitAPI.chm` (shipped with the Revit 2024 SDK, typically at `C:\Program Files\Autodesk\Revit 2024 SDK\RevitAPI.chm`) into this skill's folder as:

```
.cursor/skills/revit-api-lookup/RevitAPI.chm
```

The script also accepts the older name `Revit.chm` as a fallback.

### Step 2: Decompile

```powershell
powershell -ExecutionPolicy Bypass -File .cursor/skills/revit-api-lookup/scripts/decompile-chm.ps1
```

Uses Windows' built-in `hh.exe -decompile` to expand the CHM into `./docs/html/`. Expect ~30K `.htm` files and ~420 MB. The `./docs/` folder is git-ignored.

### Step 3: Build the symbol index

```powershell
powershell -ExecutionPolicy Bypass -File scripts\build-api-index.ps1
```

(This script lives at the top-level `scripts\` folder of the repo, not inside the skill, because it's setup-only.)

Produces:

- `docs/symbols.jsonl` - ~38K rows, one per class/method/property/field/event/enum-member.
- `docs/md/*.md` - one clean markdown sidecar per symbol (~500 B each).

Takes ~3 minutes. Re-run with `-Force` if you update the CHM.

### Step 4: Verify

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

### Fulltext mode (fallback for prose queries)

When the query isn't a symbol name ("how does ExternalEvent work", "explain transaction regeneration"), grep the raw HTML instead. Slower and noisier, but covers remarks/examples prose not captured by the symbol index.

```powershell
powershell -ExecutionPolicy Bypass -File .cursor/skills/revit-api-lookup/scripts/search-api.ps1 "ExternalEvent Raise" -Fulltext
```

Fulltext mode strips Sandcastle nav chrome and drops VB/C++ signatures before showing hits, and ranks files by match density. Still expect 2-5x more tokens than symbol mode.

### When both fail

- Check the [cheatsheet](./cheatsheet.md) for common patterns — faster than any grep.
- Public mirror: `https://www.revitapidocs.com/2024/`.
- Some internal types have no HelpId (fall through to fulltext mode).

## Cheatsheet

For the 20% of APIs used 80% of the time (collectors, transactions, selection, parameters, units, events) see [`cheatsheet.md`](./cheatsheet.md).

## What NOT to do

- Do **not** read the entire `./docs/` folder or `symbols.jsonl` — stream via the search script.
- Do **not** paste raw HTML or full sidecar contents into chat; summarize the signature and a 1-2 sentence description.
- Do **not** invent method names. If symbol mode returns no match, try fulltext, then admit ignorance — don't hallucinate.
- Do **not** rely on memory for `BuiltInParameter` / `BuiltInCategory` enum values; look them up. They change subtly across Revit versions.
