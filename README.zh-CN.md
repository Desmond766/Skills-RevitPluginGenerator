# Cursor / Cline 的 Revit Add-in 技能

使用 **Cursor / Cline** 通过自然语言创建 Revit 2024 C# 插件、查询 Revit API、编译项目，并把编译后的 DLL 和 `.addin` 清单部署到你第一次使用时选择的目录。

本仓库在 [`.cursor/skills/`](.cursor/skills/) 下提供 agent skills。团队成员克隆或解压本仓库后，在 Cursor/Cline 中打开这个文件夹，就能使用同一套提示词、API 索引和部署脚本。

## 包含内容

| Skill | 作用 |
| --- | --- |
| [`revit-addin-scaffold`](.cursor/skills/revit-addin-scaffold/SKILL.md) | 根据自然语言请求创建新的 `.csproj`、`.addin`、`IExternalCommand` / `IExternalApplication`。 |
| [`revit-api-lookup`](.cursor/skills/revit-api-lookup/SKILL.md) | 通过已打包的索引查询 API 签名和用法，包括 [`symbols.jsonl`](.cursor/skills/revit-api-lookup/docs/symbols.jsonl) 和 markdown sidecar。正常使用不需要下载 CHM。 |
| [`revit-addin-build-deploy`](.cursor/skills/revit-addin-build-deploy/SKILL.md) | 使用 MSBuild 编译，并把 DLL 和重写后的 `.addin` 复制到你保存的部署目录。部署脚本位于该 skill 内部：[`deploy-addin.ps1`](.cursor/skills/revit-addin-build-deploy/scripts/deploy-addin.ps1)。 |

Agent 会根据 skill 描述自动选择要使用的 skill；通常不需要你手动运行某个 skill。

---

## 每台机器的前置条件

| 需要 | 原因 |
| --- | --- |
| **Revit 2024** | 提供编译所需的 `RevitAPI.dll` / `RevitAPIUI.dll`。 |
| **.NET SDK 6+** 或 **Visual Studio Build Tools** | 提供 MSBuild / `dotnet` 来编译插件；内置部署脚本会使用你 `PATH` 中可用的构建工具。 |
| **Cursor**（或兼容 Agent + skills 的编辑器） | 运行这些 skills；API 查询 skill 使用索引搜索时 `ripgrep` 会很有用。 |
| **Git**（如果使用 `git clone`） | 用于克隆和 `git pull` 更新。 |

如果 Revit 不在 `C:\Program Files\Autodesk\Revit 2024\`，请在构建前设置：

```powershell
$env:RevitInstallPath = 'D:\YourPath\Autodesk\Revit 2024'
```

项目模板会读取这个变量；标准安装路径下不需要手动修改 `.csproj`。

---

## 首次使用配置

下载本仓库后，每个新用户都应该先配置两个路径：Revit 安装路径，以及编译后的 DLL / `.addin` 部署到哪里。

### 1. 配置 Revit 安装路径

模板默认假设 Revit 2024 安装在：

```powershell
C:\Program Files\Autodesk\Revit 2024
```

如果你的 Revit 2024 安装在其他位置，请在创建插件或构建前设置 `RevitInstallPath`：

```powershell
$env:RevitInstallPath = 'D:\YourPath\Autodesk\Revit 2024'
```

如果想永久保存到当前 Windows 用户环境变量：

```powershell
[Environment]::SetEnvironmentVariable('RevitInstallPath', 'D:\YourPath\Autodesk\Revit 2024', 'User')
```

设置永久环境变量后，请重启 Cursor/Cline，让新终端能够读取该变量。

### 2. 配置编译后的 DLL 放在哪里

第一次让 agent 构建/部署插件时，它应该询问：

> 编译好的 Revit add-in 应该部署到哪里？

如果希望 Revit 下次启动时自动加载该插件，请使用当前用户的 Revit Addins 目录：

```powershell
$env:AppData\Autodesk\Revit\Addins\2024
```

你也可以选择其他目录，例如 `D:\RevitAddins\2024`，适用于团队从固定目录复制插件的流程。

部署脚本会把你选择的目录保存到：

```powershell
$env:AppData\RevitSkills\revit-addin-build-deploy.json
```

之后所有构建都会自动部署到这个已保存目录。

如果以后需要更改部署目录，运行一次带 `-AddinsDir` 的构建：

```powershell
powershell -ExecutionPolicy Bypass -File .cursor/skills/revit-addin-build-deploy/scripts/deploy-addin.ps1 -ProjectPath "path\to\YourAddin.csproj" -AddinsDir "D:\RevitAddins\2024"
```

或者直接删除/编辑：

```powershell
$env:AppData\RevitSkills\revit-addin-build-deploy.json
```

### 3. 检查构建工具

构建前请至少安装以下一种：

- 带 MSBuild 的 Visual Studio / Visual Studio Build Tools
- .NET SDK 6+，以及 .NET Framework 4.8 targeting pack

部署前请关闭 Revit。Revit 运行时会锁定已加载的 DLL，打开 Revit 时复制新构建可能失败。

---

## 快速开始

1. **获取仓库**：`git clone <your-repo-url>`，或解压团队分发的压缩包。
2. **在 Cursor/Cline 中打开仓库根目录**，让 agent 能访问 `.cursor/skills/`。
3. **在聊天中提出插件需求**，例如：*"Create a Revit add-in that exports all rooms in the active view to CSV with number, name, and area in m²."*

Agent 应该会创建项目、查询 API、实现代码、运行构建/部署，并把插件放入你保存的部署目录。重启 Revit 2024 后，在 **Add-Ins → External Tools** 中查找该命令；如果插件注册了 ribbon，则查看对应 ribbon。

---

## Revit 如何加载插件

1. build-deploy 流程会编译项目，并把 DLL 和**重写后的** `.addin` 写入你保存的部署目录。Revit 默认会在启动时读取 `%AppData%\Autodesk\Revit\Addins\2024\`。
2. 清单文件中的 `<Assembly>` 路径会被设置为你本机部署后的 DLL 路径，避免不同机器之间盲目共享路径。
3. 如果要为同一台电脑上的**所有用户**安装，可以使用 `C:\ProgramData\Autodesk\Revit\Addins\2024\`；这通常需要管理员权限。用 `-AddinsDir` 传入一次该路径即可保存为部署目录。

如果要**分享一个已构建的插件**而不重新构建：把 `.dll` 和 `.addin` 发给对方，让对方复制到自己的用户 Addins 目录即可。

---

## 与团队共享这些 skills

**Git（推荐）**：把本仓库推送到 GitHub / GitLab / Azure DevOps。团队成员克隆后在 Cursor/Cline 中打开；之后用 `git pull` 获取 skill 更新。

**Zip**：至少打包：

- `.cursor/` 整个目录，确保 skills 和已打包索引完整保留
- `README.md` 和 `.gitignore`（如果团队使用它们）

本发行包没有根目录 `setup.ps1`。入门流程是：安装前置条件，在 Cursor/Cline 中打开目录，配置上面的两个路径，然后开始使用。

---

## 示例提示词

- *"Create a Revit add-in that renames all selected walls by appending their length in millimeters."*
- *"Add a ribbon with three buttons: export rooms to CSV, tag all doors, dimension between two picked walls."*
- *"What Revit API gets a wall's base offset?"*（主要使用 API lookup）
- *"Build and deploy the `WallRenamer` add-in to Revit."*（主要使用 build-deploy）

scaffold skill 中的示例模式可能来自较旧 Revit 版本；该 skill 会把相关模式迁移到 Revit 2024。详见 [revit-addin-scaffold SKILL.md](.cursor/skills/revit-addin-scaffold/SKILL.md)。

---

## 仓库结构（克隆后会看到）

```text
RevitSkills/
├── .cursor/
│   └── skills/
│       ├── revit-addin-scaffold/       SKILL.md, docs/, templates/, scripts/
│       ├── revit-api-lookup/           SKILL.md, scripts/, docs/ (packaged index + md)
│       └── revit-addin-build-deploy/   SKILL.md, scripts/deploy-addin.ps1
├── .gitignore
└── README.md
```

维护者专用工具（例如从 CHM 重新生成 API 索引、从旧代码挖掘 `revit-addin-scaffold/docs/samples-index/` 等）不属于日常使用内容。本仓库日常使用只依赖 `.cursor/skills/` 下已打包好的索引。
