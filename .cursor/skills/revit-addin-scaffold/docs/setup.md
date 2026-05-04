# Setup (scaffold)

## Before scaffolding

- Read **`../templates/config.yaml`** for suggested Revit version, target framework, and vendor defaults.
- For bilingual prompts, consult **`../../glossary.zh-en.md`** (skills root: `.cursor/skills/glossary.zh-en.md`).
- Browse **`../docs/samples-index/INDEX.md`** with ripgrep (see `SKILL.md`) before writing new code from scratch.

## Layout

- **`docs/patterns.md`** — transaction, selection, ribbon recipes.
- **`docs/samples-index/`** — packaged reference snippets from legacy add-ins (Revit 2020/2018 era); port logic to Revit 2024 APIs.
- **`templates/*.template`** — copy into your new project and replace `{{…}}` tokens.

No packaged executable lives under `scripts/`; build and install are handled by **revit-addin-build-deploy**.
