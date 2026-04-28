# RevitSkills（开发者）

本分支用于**维护 Cursor 技能**：编辑 `.cursor/skills/`、`existingCodes/` 下的参考源码，并重生成随技能分发出去的打包索引。**面向维护者**：终端使用者请使用仅含打包产物的分发分支（如 `main`）及对应 README。

## 仓库里有什么（本会跟踪的内容）

| 路径 | 作用 |
| --- | --- |
| [`.cursor/skills/`](.cursor/skills/) | 三个 Skill：`revit-addin-scaffold`、`revit-api-lookup`、`revit-addin-build-deploy`（含 SKILL、模板、samples-index、`symbols.jsonl` / `docs/md/` 等）。 |
| [`existingCodes/`](existingCodes/) | 历史/参考插件源码，供 `scripts/build-index.ps1` 扫描，生成 scaffold 侧的 [`samples-index/`](.cursor/skills/revit-addin-scaffold/samples-index/)。 |
| [`scripts/`](scripts/) | 维护脚本：如 **`build-api-index.ps1`**（CHM→索引）、**`build-index.ps1`**（existingCodes→INDEX）、命名与 sidecar 辅助脚本等。 |
| [`setup.ps1`](setup.ps1) | 单次环境检查：是否具备 Revit/构建工具；验证或按需**重打包** API 索引与 scaffold 样本索引（见下）。 |

根目录下其他目录（例如实验性插件、本地 `addins/` 等）**默认不纳入版本库**；需要时再改 `.gitignore`。

## 前置条件

- **Revit 2024**（及常见安装路径下的 `RevitAPI.dll`，或通过 `$env:RevitInstallPath` 指定）。
- **MSBuild 或 dotnet SDK**（用于构建示例与运行维护脚本调用流程）。
- **Cursor**（或同类环境）——编辑技能与被代理调用时使用。
- 需要**从零重建 API 符号索引**时：本机须有 **Revit 2024 SDK** 自带的 `RevitAPI.chm`，或通过 `-ChmPath` 指向合法副本（勿将 `.chm` 提交进仓库）。

## 维护工作流简述

### 1. 克隆后自检

```powershell
cd RevitSkills
.\setup.ps1
```

已通过且仓库内已有完整 `symbols.jsonl` 与 `samples-index` 时，只会做检查。**无 existingCodes/** 时可跳过 scaffold 索引重建逻辑（只要不 `-Force` 且 INDEX 已存在）。

### 2. 重打包 Revit API 索引（维护者）

当 Revit SDK 文档或解析逻辑更新，需要重写技能内的 **JSONL + markdown sidecars** 时：

```powershell
.\setup.ps1 -ChmPath 'C:\...\RevitSDK\RevitAPI.chm' -Force
# 或已有 CHM；仅强制重跑
.\setup.ps1 -Force
```

内部会调用：`decompile-chm.ps1` → `scripts/build-api-index.ps1`（细节见 `.cursor/skills/revit-api-lookup/SKILL.md` 与各脚本注释）。

产物提交范围以 **`.gitignore` 为准**：可提交 **`docs/symbols.jsonl`**、`**docs/md/**`；本地解压的 **`docs/html/`**、`RevitAPI.chm` 及部分临时文件仍被忽略，勿手动 `git add -f` 除非你明确要改策略。

### 3. 重打包 scaffold `samples-index`（维护者）

修改了 `existingCodes/` 组织结构或希望在 INDEX 里反映新的一批参考工程时：

```powershell
.\scripts\build-index.ps1
# 或
.\setup.ps1 -Force
```

（在无现成 INDEX 或未 `-Force` 时，`setup.ps1` 也会在检测到 `existingCodes/` 的情况下调用 `build-index.ps1`。）

### 4. 技能正文与脚本

- 叙事与检索入口：**各 SKILL 目录下的 [`SKILL.md`](.cursor/skills/revit-addin-scaffold/SKILL.md)**（另两个技能同理）。
- 部署：**[`deploy-addin.ps1`](.cursor/skills/revit-addin-build-deploy/scripts/deploy-addin.ps1)**（在用户侧随技能分发）。

## `.gitignore` 设计要点（本分支）

- **白名单**：只跟踪 **`README.md`、`.gitignore`、`setup.ps1`、`scripts/`、`existingCodes/`、`.cursor/`**。
- **API 打包产物**：仓库内跟踪 **`symbols.jsonl`** 与 **`docs/md/**`**；解压后的整棵 `docs/html/` 与 **`RevitAPI.chm`** 不提交（体积与 Autodesk 分发策略）。
- **临时备份**：`**/symbols.jsonl.bak.*`、`**/symbols.jsonl.new` 等不入库。
- **`existingCodes/`** 下常见 **`bin/`、`obj/`、`packages/`、`.vs/`** 等已由规则排除。

如需把新的「维护用根脚本」一并纳入仓库，在白名单中为该文件添加 `!/YourScript.ps1`（或归入 `scripts/`）。

## 与仅技能分发的分支对比

合并到 **`main`**（或等价发布分支）时常会**删减**：`existingCodes/`、根 `scripts/`、或收窄 `.gitignore` 仅保留用户使用技能所需的文件。**本 `develop` 分支**保留完整维护链——提交前确认无敏感信息与子模块违规内容。
