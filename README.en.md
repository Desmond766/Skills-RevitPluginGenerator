# RevitSkills (for maintainers)

**English** · [中文 `README.md`](README.md)

This branch is for **maintaining the Cursor skills**: edit `.cursor/skills/` and reference sources under `existingCodes/`, and regenerate the packaged artifacts that ship with the skills. **Maintainers**: end users should use the distribution branch that only contains packaged outputs (for example `main`) and its README.

## What is in this repo (tracked paths)

| Path | Role |
| --- | --- |
| [`.cursor/skills/`](.cursor/skills/) | Three skills: `revit-addin-scaffold`, `revit-api-lookup`, `revit-addin-build-deploy` (SKILL files, templates, `samples-index`, `symbols.jsonl`, `docs/md/`, etc.). |
| [`existingCodes/`](existingCodes/) | Legacy / reference plug-in source; scanned by `scripts/build-index.ps1` to emit the scaffold [`samples-index/`](.cursor/skills/revit-addin-scaffold/samples-index/). |
| [`scripts/`](scripts/) | Maintainer scripts: e.g. **`build-api-index.ps1`** (CHM → index), **`build-index.ps1`** (existingCodes → INDEX), naming and sidecar helpers. |
| [`setup.ps1`](setup.ps1) | One-shot checks: Revit / build tools present; verify or **rebuild** the API index and scaffold sample index (see below). |

Other top-level folders (experimental add-ins, local `addins/`, etc.) are **not tracked by default**; extend `.gitignore` if you need more paths.

## Prerequisites

- **Revit 2024** (with `RevitAPI.dll` on the usual path, or set `$env:RevitInstallPath`).
- **MSBuild or .NET SDK** (for building samples and what the maintainer scripts invoke).
- **Cursor** (or an equivalent setup) for editing skills and agent use.
- To **rebuild the API symbol index from scratch**, you need a valid **`RevitAPI.chm`** from the **Revit 2024 SDK** (or pass `-ChmPath`). Do **not** commit `.chm` files to the repo.

## Maintainer workflow

### 1. After clone

```powershell
cd RevitSkills
.\setup.ps1
```

If checks pass and `symbols.jsonl` plus `samples-index` are already complete, only validation runs. **Without `existingCodes/`**, scaffold index rebuild can be skipped (when not using `-Force` and INDEX already exists).

### 2. Rebuild the Revit API index (maintainers)

When the SDK docs or parsing pipeline change and you need to rewrite the skill’s **JSONL + markdown sidecars**:

```powershell
.\setup.ps1 -ChmPath 'C:\...\RevitSDK\RevitAPI.chm' -Force
# or CHM already present; force full refresh
.\setup.ps1 -Force
```

Internally this uses: `decompile-chm.ps1` → `scripts/build-api-index.ps1` (see `.cursor/skills/revit-api-lookup/SKILL.md` and script comments).

What you may commit follows **`.gitignore`**: **`docs/symbols.jsonl`** and **`docs/md/**`**; local decompressed **`docs/html/`**, `RevitAPI.chm`, and temp files stay ignored—avoid `git add -f` unless you intentionally change policy.

### 3. Rebuild scaffold `samples-index` (maintainers)

After changing layout under `existingCodes/` or when you want INDEX to reflect a new batch of reference projects:

```powershell
.\scripts\build-index.ps1
# or
.\setup.ps1 -Force
```

(Without a fresh INDEX or without `-Force`, `setup.ps1` may still invoke `build-index.ps1` when it finds `existingCodes/`.)

### 4. Skill docs and scripts

- Story and lookup entry points: **`SKILL.md`** in each skill directory (see [scaffold example](.cursor/skills/revit-addin-scaffold/SKILL.md); same for the other two).
- Deploy: [`deploy-addin.ps1`](.cursor/skills/revit-addin-build-deploy/scripts/deploy-addin.ps1) (ships with the skill for users).

## `.gitignore` notes (this branch)

- **Whitelist** tracks **`README.md`**, **`README.en.md`**, **`.gitignore`**, **`setup.ps1`**, **`scripts/`**, **`existingCodes/`**, **`.cursor/`**.
- **API artifacts**: commit **`symbols.jsonl`** and **`docs/md/**`**; do not commit the full decompressed **`docs/html/`** tree or **`RevitAPI.chm`** (size and Autodesk redistribution).
- **Backups**: `**/symbols.jsonl.bak.*`, `**/symbols.jsonl.new`, etc. are not committed.
- Under **`existingCodes/`**, common build noise such as **`bin/`**, **`obj/`**, **`packages/`**, **`.vs/`** is ignored.

To track another maintainer-only root script, add `!/YourScript.ps1` to the whitelist (or put it under `scripts/`).

## Compared to a “skills only” release branch

Merges to **`main`** (or an equivalent) often **drop** `existingCodes/`, root `scripts/`, or narrow `.gitignore` to what end users need. **`develop`** keeps the full maintainer chain—review for secrets and license issues before pushing.
