# Existing Plug-ins Index

Auto-generated catalog of 197 Revit plug-ins under `existingCodes/`. Each entry summarizes signals mined from the source (Transaction labels, TaskDialog titles, BuiltInCategory / BuiltInParameter references, UI framework, integrations) plus a hand-editable `Description:` line.

**Regenerate** when you add or change plug-ins:

```powershell
powershell -ExecutionPolicy Bypass -File scripts/build-index.ps1
```

**Search** (agents should always `rg` this file first before reading source).
Each entry carries a `Tags:` line seeded from `.cursor/skills/glossary.zh-en.md`
that unions English and Chinese synonyms, so either-language grep finds the same entry:

```powershell
# Bilingual regex: English OR Chinese term, both hit the same entries.
rg -i "wall|墙.*material|材质" existingCodes\INDEX.md -A 8
rg -i "pipe|管道.*elevation|高程"  existingCodes\INDEX.md -A 8
rg -i "excel|表格"                  existingCodes\INDEX.md -A 8
rg -i "hanger|吊架"                 existingCodes\INDEX.md -A 8
```

## Architecture (17)

### AddPipelineInformation
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AddPipelineInformation\AddPipelineInformation
- Author: 梁涛插件源代码
- Actions: "构件安装位置赋值", "埋地管道参数赋值", "可见性设置"
- Dialogs: "提示", "revit"
- Categories: OST_Views, OST_Rooms, OST_PipeCurves, OST_Floors, OST_Ceilings
- APIs: FilteredElementCollector, TransactionGroup, RayCast / ReferenceIntersector
- Tags: assign, ceiling, curve, dialog, element, floor, form, foundation, line, link, linked model, message, parameter, pipe, prompt, room, set value, shared parameter, slab, taskdialog, view, window, 板, 参数, 窗口, 窗体, 弹窗, 地板, 吊顶, 对话框, 房间, 赋值, 共享参数, 构件, 管道, 管线, 基础, 链接, 链接模型, 楼板, 曲线, 设置值, 视图, 水管, 提示, 天花板, 图元, 线, 消息, 消息框, 写入, 元素, 直线
- Description: TODO (hand-edit)

### AnalysisOfNetHeightIssues
- Path: existingCodes\梁涛插件源代码\6.不常用\AnalysisOfNetHeightIssues\AnalysisOfNetHeightIssues
- Author: 梁涛插件源代码
- Actions: "Asda"
- Dialogs: "Revit", "1"
- Categories: OST_StructuralFraming, OST_DuctCurves, OST_Floors, OST_Ceilings, OST_RvtLinks
- Parameters: RBS_CURVE_HEIGHT_PARAM
- APIs: FilteredElementCollector, Pick (Selection), Modeless (ExternalEvent), RayCast / ReferenceIntersector
- UI: WinForms
- Tags: ceiling, curve, duct, floor, height, link, linked model, model, slab, 板, 地板, 吊顶, 风管, 高度, 链接, 链接模型, 楼板, 模型, 曲线, 天花板
- Description: TODO (hand-edit)

### ChangeDoorSymbolAngle
- Path: existingCodes\梁涛插件源代码\1.土建\ChangeDoorSymbolAngle\ChangeDoorSymbolAngle
- Author: 梁涛插件源代码
- Actions: "门类型角度批量修改"
- Dialogs: "revit"
- Categories: OST_Doors
- APIs: FilteredElementCollector
- Tags: batch, bulk, change, degree, door, modify, type, update, 调整, 度, 更改, 更新, 角度, 类型, 门, 批量, 修改
- Description: TODO (hand-edit)

### ClosedFloorLine
- Path: existingCodes\梁涛插件源代码\11.其他\ClosedFloorLine\ClosedFloorLine
- Author: 梁涛插件源代码
- Actions: "闭合楼板模型线并创建楼板"
- Dialogs: "BIMTRANS", "Error", "re", "revit"
- APIs: Pick (Selection)
- Tags: create, error, floor, generate, line, model, new, slab, 板, 报错, 创建, 错误, 地板, 建立, 楼板, 模型, 生成, 线, 新建, 新增, 直线
- Description: TODO (hand-edit)

### ColoringOfStructuralPlates
- Path: existingCodes\梁涛插件源代码\1.土建\ColoringOfStructuralPlates\ColoringOfStructuralPlates
- Author: 梁涛插件源代码
- Actions: "更改楼板颜色"
- Dialogs: "revit", "rvi", "ondoc", "提示"
- Categories: OST_ProjectBasePoint, OST_IOSModelGroups, OST_Floors, OST_Ceilings
- Parameters: BASEPOINT_ELEVATION_PARAM, FLOOR_ATTR_THICKNESS_PARAM, STRUCTURAL_ELEVATION_AT_TOP, CEILING_HEIGHTABOVELEVEL_PARAM, INVALID
- APIs: FilteredElementCollector, Pick (Selection), Modeless (ExternalEvent)
- Tags: ceiling, change, color, colour, elevation, floor, height, level, message, model, modify, paint, point, project, prompt, slab, taskdialog, thickness, update, 板, 标高, 弹窗, 地板, 点, 吊顶, 调整, 高程, 高度, 更改, 更新, 厚度, 楼板, 模型, 染色, 上色, 提示, 天花板, 填色, 项目, 消息, 消息框, 修改, 着色
- Description: TODO (hand-edit)

### CreateThresholdStone
- Path: existingCodes\梁涛插件源代码\1.土建\CreateThresholdStone\CreateThresholdStone
- Author: 梁涛插件源代码
- Actions: "创建门槛石"
- Dialogs: "BIMTRANS"
- Categories: OST_Floors
- Parameters: FLOOR_ATTR_DEFAULT_THICKNESS_PARAM
- APIs: FilteredElementCollector, Pick (Selection), RayCast / ReferenceIntersector
- Tags: create, door, floor, generate, new, slab, thickness, 板, 创建, 地板, 厚度, 建立, 楼板, 门, 生成, 新建, 新增
- Description: TODO (hand-edit)

### CutBox
- Path: existingCodes\品成插件源代码\通用\CutBox\CutBox
- Author: 品成插件源代码
- Actions: "CutBox"
- Dialogs: "Revit"
- Categories: OST_Columns, OST_StructuralColumns, OST_Doors, OST_Windows, OST_Walls
- Parameters: FAMILY_BASE_LEVEL_PARAM, FAMILY_BASE_LEVEL_OFFSET_PARAM, FAMILY_TOP_LEVEL_PARAM, FAMILY_TOP_LEVEL_OFFSET_PARAM, WALL_BASE_CONSTRAINT
- APIs: FilteredElementCollector, Pick (Selection)
- UI: WinForms
- Tags: base constraint, column, dialog, door, family, floor, form, height, level, offset, slab, top constraint, type, wall, window, 板, 标高, 窗, 窗户, 窗口, 窗体, 地板, 底部限制条件, 顶部限制条件, 对话框, 高度, 类型, 楼板, 门, 偏移, 偏移量, 墙, 墙体, 柱, 柱子, 族
- Description: TODO (hand-edit)

### CutFloor
- Path: existingCodes\梁涛插件源代码\3.管综\CutFloor\CutFloor
- Author: 梁涛插件源代码
- Actions: "删除旧楼板", "拆分楼板"
- Dialogs: "revit", "result", "reit", "BIMTRANS", "Error"
- Parameters: FLOOR_PARAM_IS_STRUCTURAL, FLOOR_HEIGHTABOVELEVEL_PARAM
- APIs: Pick (Selection), TransactionGroup, Shared parameters
- Tags: break, delete, error, floor, height, level, remove, slab, split, 板, 报错, 标高, 拆分, 错误, 打断, 地板, 分割, 高度, 楼板, 删除, 移除
- Description: TODO (hand-edit)

### DoorReview
- Path: existingCodes\梁涛插件源代码\1.土建\DoorReview\DoorReview
- Author: 梁涛插件源代码
- Actions: "更换门类型"
- Dialogs: "revit", "revti"
- Categories: OST_TextNotes, OST_Doors
- Parameters: FURNITURE_WIDTH, FAMILY_HEIGHT_PARAM
- APIs: FilteredElementCollector, Modeless (ExternalEvent)
- Tags: annotate, door, family, furniture, height, note, type, view, width, 高度, 家具, 宽度, 类型, 门, 视图, 文字注释, 注释, 族
- Description: TODO (hand-edit)

### FlippingDoor
- Path: existingCodes\梁涛插件源代码\1.土建\FlippingDoor\FlippingDoor
- Author: 梁涛插件源代码
- Actions: "修改底高度", "更改族类型", "隐藏CAD图层", "显示CAD图层", "创建模型线"
- Dialogs: "提示", "Error", "ds", "re", "test"
- Categories: OST_Doors, OST_Walls, OST_TextNotes, OST_Views, OST_Floors
- Parameters: INSTANCE_SILL_HEIGHT_PARAM, FURNITURE_WIDTH, FAMILY_HEIGHT_PARAM, FLOOR_HEIGHTABOVELEVEL_PARAM
- APIs: FilteredElementCollector, Pick (Selection), Element creation, Modeless (ExternalEvent), TransactionGroup, RayCast / ReferenceIntersector
- Tags: annotate, change, create, degree, delete, door, error, family, family symbol, family type, floor, furniture, generate, height, hide, level, line, message, model, modify, new, note, prompt, remove, show, slab, taskdialog, type, unhide, update, view, wall, width, 板, 报错, 标高, 创建, 错误, 弹窗, 地板, 调整, 度, 高度, 更改, 更新, 家具, 建立, 角度, 宽度, 类型, 楼板, 门, 模型, 墙, 墙体, 取消隐藏, 删除, 生成, 视图, 提示, 文字注释, 显示, 线, 消息, 消息框, 新建, 新增, 修改, 移除, 隐藏, 直线, 注释, 族, 族符号, 族类型
- Description: TODO (hand-edit)

### FlippingFloor
- Path: existingCodes\梁涛插件源代码\6.不常用\FlippingFloor\FlippingFloor
- Author: 梁涛插件源代码
- Actions: "创建楼板类型", "创建模型线", "文字注释位置调整", "创建楼板", "楼板开洞"
- Dialogs: "提示", "111", "错误提示", "错误", "创建楼板类型"
- Categories: OST_TextNotes, OST_Floors, OST_Views, OST_Lines, OST_Levels
- Parameters: LEVEL_PARAM
- APIs: FilteredElementCollector, Pick (Selection), Modeless (ExternalEvent), TransactionGroup, RayCast / ReferenceIntersector
- Integrations: Database
- Tags: annotate, change, comments, create, delete, error, floor, generate, level, line, message, model, modify, new, note, prompt, remove, slab, taskdialog, type, update, view, 板, 报错, 备注, 标高, 创建, 错误, 弹窗, 地板, 调整, 更改, 更新, 建立, 类型, 楼板, 模型, 删除, 生成, 视图, 提示, 文字注释, 线, 消息, 消息框, 新建, 新增, 修改, 移除, 直线, 注释
- Description: TODO (hand-edit)

### FlippingFloorTiling
- Path: existingCodes\梁涛插件源代码\1.土建\FlippingFloorTiling\FlippingFloorTiling
- Author: 梁涛插件源代码
- Actions: "创建临时模型线", "创建美缝", "删除未附着面的美缝实例"
- Dialogs: "提示"
- Categories: OST_GenericModel
- APIs: FilteredElementCollector, Pick (Selection), Element creation, TransactionGroup
- Integrations: HTTP
- Tags: create, delete, floor, generate, line, message, model, new, prompt, remove, slab, taskdialog, 板, 创建, 弹窗, 地板, 建立, 楼板, 模型, 删除, 生成, 提示, 线, 消息, 消息框, 新建, 新增, 移除, 直线
- Description: TODO (hand-edit)

### FloorReview
- Path: existingCodes\梁涛插件源代码\6.不常用\FloorReview\FloorReview
- Author: 梁涛插件源代码
- Actions: "删除所有文字注释", "修改族类型", "更改标高", "更改文本注释颜色"
- Dialogs: "sd", "11", "error", "sdsd", "ds32"
- Categories: OST_TextNotes, OST_Floors, OST_Levels
- Parameters: LEVEL_PARAM
- APIs: FilteredElementCollector, Modeless (ExternalEvent)
- Integrations: Database
- Tags: annotate, change, comments, delete, elevation, error, family, family symbol, family type, floor, level, modify, note, remove, slab, type, update, view, 板, 报错, 备注, 标高, 错误, 地板, 调整, 高程, 更改, 更新, 类型, 楼板, 删除, 视图, 文字注释, 修改, 移除, 注释, 族, 族符号, 族类型
- Description: TODO (hand-edit)

### NewFlippingFloor
- Path: existingCodes\梁涛插件源代码\6.不常用\NewFlippingFloor\NewFlippingFloor
- Author: 梁涛插件源代码
- Actions: "创建楼板", "楼板开洞"
- Dialogs: "错误"
- Categories: OST_Levels, OST_Floors
- APIs: FilteredElementCollector, Pick (Selection)
- Tags: create, error, floor, generate, level, new, slab, 板, 报错, 标高, 创建, 错误, 地板, 建立, 楼板, 生成, 新建, 新增
- Description: TODO (hand-edit)

### RampArrowParallelFloor
- Path: existingCodes\梁涛插件源代码\1.土建\RampArrowParallelFloor\RampArrowParallelFloor
- Author: 梁涛插件源代码
- Actions: "生成坡道箭头", "旋转", "坡道箭头平行楼板", "删除临时剖面", "元素旋转180度"
- Dialogs: "提示", "revit", "rev", "dsd", "re"
- Categories: OST_GenericModel
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, TransactionGroup, RayCast / ReferenceIntersector
- Tags: create, degree, delete, element, family, floor, generate, message, model, new, prompt, remove, rotate, section view, slab, taskdialog, 板, 创建, 弹窗, 地板, 度, 构件, 建立, 角度, 楼板, 模型, 剖面, 剖面视图, 删除, 生成, 提示, 图元, 消息, 消息框, 新建, 新增, 旋转, 移除, 元素, 族
- Description: TODO (hand-edit)

### WallOffsetAndJoin
- Path: existingCodes\品成插件源代码\土建\WallOffsetAndJoin\WallOffsetAndJoin
- Author: 品成插件源代码
- Actions: "WallOffsetAndJoin"
- Dialogs: "R", "Revit", "r"
- Categories: OST_Floors, OST_StructuralFraming
- Parameters: WALL_BASE_CONSTRAINT, WALL_BASE_OFFSET, WALL_HEIGHT_TYPE, WALL_USER_HEIGHT_PARAM, WALL_TOP_OFFSET
- APIs: FilteredElementCollector, Pick (Selection)
- Tags: base constraint, beam, connect, elevation, floor, height, join, level, offset, slab, thickness, top constraint, type, wall, 板, 标高, 地板, 底部限制条件, 顶部限制条件, 高程, 高度, 合并, 厚度, 类型, 连接, 梁, 楼板, 偏移, 偏移量, 墙, 墙体
- Description: TODO (hand-edit)

### WallReview
- Path: existingCodes\梁涛插件源代码\1.土建\WallReview\WallReview
- Author: 梁涛插件源代码
- Dialogs: "dss", "错误", "提示"
- Categories: OST_Walls
- APIs: FilteredElementCollector, Modeless (ExternalEvent)
- Tags: error, message, prompt, taskdialog, view, wall, 报错, 错误, 弹窗, 墙, 墙体, 视图, 提示, 消息, 消息框
- Description: TODO (hand-edit)

## Structural (33)

### AddParaToBuriedPipe
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AddParaToBuriedPipe\AddParaToBuriedPipe
- Author: 梁涛插件源代码
- Actions: "埋地管道参数赋值"
- Dialogs: "提示"
- Categories: OST_Views, OST_PipeCurves, OST_Floors, OST_Ceilings, OST_StructuralFoundation
- APIs: FilteredElementCollector, RayCast / ReferenceIntersector
- Tags: assign, ceiling, curve, floor, foundation, link, linked model, message, parameter, pipe, prompt, set value, shared parameter, slab, taskdialog, view, 板, 参数, 弹窗, 地板, 吊顶, 赋值, 共享参数, 管道, 管线, 基础, 链接, 链接模型, 楼板, 曲线, 设置值, 视图, 水管, 提示, 天花板, 消息, 消息框, 写入
- Description: TODO (hand-edit)

### ARC_BeamMaterial
- Path: existingCodes\品成插件源代码\土建\ARC_BeamMaterial\ARC_BeamMaterial
- Author: 品成插件源代码
- Actions: "PaintBeamByHeight", "ClearBeamMaterial"
- Dialogs: "Revit"
- Categories: OST_Materials, OST_StructuralFraming
- Parameters: STRUCTURAL_MATERIAL_PARAM
- APIs: FilteredElementCollector
- UI: WinForms
- Tags: arc, beam, color, colour, height, material, millimeter, mm, paint, 材料, 材质, 高度, 毫米, 弧, 梁, 染色, 上色, 填色, 圆弧, 着色
- Description: TODO (hand-edit)

### ARC_ClearBeam
- Path: existingCodes\品成插件源代码\土建\ARC_ClearBeam\ARC_ClearBeam
- Author: 品成插件源代码
- Actions: "ClearBeam"
- Dialogs: "Revit"
- Categories: OST_StructuralFraming, OST_Materials
- Parameters: STRUCTURAL_MATERIAL_PARAM
- APIs: FilteredElementCollector
- Tags: arc, beam, material, 材料, 材质, 弧, 梁, 圆弧
- Description: TODO (hand-edit)

### ARC_ColumnConnect
- Path: existingCodes\品成插件源代码\土建\ARC_ColumnConnect\ARC_ColumnConnect
- Author: 品成插件源代码
- Dialogs: "a", "提示"
- APIs: FilteredElementCollector, Pick (Selection), Element creation
- Tags: arc, column, connect, join, message, prompt, taskdialog, 弹窗, 合并, 弧, 连接, 提示, 消息, 消息框, 圆弧, 柱, 柱子
- Description: TODO (hand-edit)

### ARC_SlopeBeam
- Path: existingCodes\品成插件源代码\土建\ARC_SlopeBeam\ARC_SlopeBeam
- Author: 品成插件源代码
- Actions: "SlopeBeam"
- Dialogs: "Revit"
- Categories: OST_StructuralFraming, OST_StructuralColumns, OST_Floors, OST_Ceilings, OST_StructuralFoundation
- Parameters: Z_OFFSET_VALUE, STRUCTURAL_BEAM_END0_ELEVATION, STRUCTURAL_BEAM_END1_ELEVATION, SCHEDULE_TOP_LEVEL_PARAM, SCHEDULE_TOP_LEVEL_OFFSET_PARAM
- APIs: FilteredElementCollector, RayCast / ReferenceIntersector
- Tags: arc, beam, ceiling, column, elevation, floor, foundation, level, link, linked model, offset, roof, schedule, slab, slope, 板, 标高, 地板, 吊顶, 高程, 弧, 基础, 链接, 链接模型, 梁, 楼板, 明细表, 偏移, 偏移量, 坡度, 天花板, 屋顶, 圆弧, 柱, 柱子
- Description: TODO (hand-edit)

### AutomaticallyGenerateDimensions
- Path: existingCodes\梁涛插件源代码\10.CEG\AutomaticallyGenerateDimensions\AutomaticallyGenerateDimensions
- Author: 梁涛插件源代码
- Actions: "create dim", "rotation"
- Dialogs: "sd", "fd;"
- Categories: OST_StructuralFraming, OST_SpecialityEquipment
- APIs: FilteredElementCollector, ElementTransformUtils
- Tags: create, dimension, generate, new, 标注, 尺寸标注, 创建, 建立, 生成, 新建, 新增
- Description: TODO (hand-edit)

### BeamColor
- Path: existingCodes\品成插件源代码\通用\BeamColor\BeamColor
- Author: 品成插件源代码
- Actions: "给梁赋色写净高"
- Dialogs: "ll", "r", "提示", "ex"
- Categories: OST_StructuralFraming, OST_Floors, OST_Ceilings, OST_RvtLinks, OST_Levels
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Ribbon (IExternalApplication), Modeless (ExternalEvent), RayCast / ReferenceIntersector
- UI: WinForms
- Tags: beam, ceiling, color, colour, floor, level, link, linked model, message, paint, prompt, slab, taskdialog, 板, 标高, 弹窗, 地板, 吊顶, 链接, 链接模型, 梁, 楼板, 染色, 上色, 提示, 天花板, 填色, 消息, 消息框, 着色
- Description: TODO (hand-edit)

### BeamColorInLink
- Path: existingCodes\品成插件源代码\通用\BeamColorInLink\BeamColorInLink
- Author: 品成插件源代码
- Actions: "标记梁净高"
- Dialogs: "提示"
- Categories: OST_StructuralFraming, OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks
- APIs: Pick (Selection), ElementTransformUtils, Modeless (ExternalEvent), RayCast / ReferenceIntersector
- UI: WinForms
- Tags: beam, ceiling, color, colour, floor, foundation, link, linked model, mark, message, paint, prompt, slab, tag, taskdialog, 板, 标记, 标签, 打标, 弹窗, 地板, 吊顶, 基础, 链接, 链接模型, 梁, 楼板, 染色, 上色, 提示, 天花板, 填色, 消息, 消息框, 着色
- Description: TODO (hand-edit)

### CADPointReview
- Path: existingCodes\梁涛插件源代码\1.土建\CADPointReview\CADPointReview
- Author: 梁涛插件源代码
- Dialogs: "reit", "re", "revit", "提示"
- Categories: OST_FireAlarmDevices, OST_CommunicationDevices, OST_DataDevices, OST_SecurityDevices, OST_LightingFixtures
- APIs: FilteredElementCollector, Pick (Selection), RayCast / ReferenceIntersector
- Tags: ceiling, column, floor, foundation, link, linked model, message, millimeter, mm, point, prompt, slab, taskdialog, view, 板, 弹窗, 地板, 点, 吊顶, 毫米, 基础, 链接, 链接模型, 楼板, 视图, 提示, 天花板, 消息, 消息框, 柱, 柱子
- Description: TODO (hand-edit)

### ColumnCornerProtectorDirectionAdjustment
- Path: existingCodes\梁涛插件源代码\1.土建\ColumnCornerProtectorDirectionAdjustment\ColumnCornerProtectorDirectionAdjustment
- Author: 梁涛插件源代码
- Actions: "添加网格", "清空", "套柱护角调整"
- Dialogs: "revit", "revi", "BIMTRANS"
- Categories: OST_Floors, OST_StructuralColumns, OST_StructuralFoundation
- APIs: FilteredElementCollector, Pick (Selection), TransactionGroup
- Tags: change, column, floor, foundation, modify, slab, update, 板, 地板, 调整, 更改, 更新, 基础, 楼板, 修改, 柱, 柱子
- Description: TODO (hand-edit)

### CreateDimensions
- Path: existingCodes\梁涛插件源代码\5.吊架出图\CreateDimensions\CreateDimensions
- Author: 梁涛插件源代码
- Actions: "创建模型线", "在吊架间创建尺寸标注"
- Dialogs: "ss"
- Categories: OST_MechanicalEquipment, OST_Walls, OST_StructuralFraming, OST_StructuralColumns
- Parameters: WALL_ATTR_WIDTH_PARAM
- APIs: Pick (Selection), TransactionGroup
- Tags: column, create, dimension, generate, hanger, line, model, new, support, wall, width, 标注, 尺寸标注, 创建, 吊架, 建立, 宽度, 模型, 墙, 墙体, 生成, 线, 新建, 新增, 支吊架, 直线, 柱, 柱子
- Description: TODO (hand-edit)

### CreateHorizontalProfileFrame
- Path: existingCodes\饶昌锋插件源代码\107创建平行剖面\CreateHorizontalProfileFrame
- Author: 饶昌锋插件源代码
- Dialogs: "asdas", "asdasdasda", "Asda", "Asdasd"
- Categories: OST_Doors, OST_StructuralFraming
- Parameters: WALL_USER_HEIGHT_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils
- Tags: create, door, generate, height, new, wall, 创建, 高度, 建立, 门, 墙, 墙体, 生成, 新建, 新增
- Description: TODO (hand-edit)

### CreateIrregularColumns
- Path: existingCodes\梁涛插件源代码\1.土建\CreateIrregularColumns\CreateIrregularColumns
- Author: 梁涛插件源代码
- Actions: "创建族", "创建异形柱", "关联族参数"
- Dialogs: "提示", "ds", "dss", "test"
- Categories: OST_Levels, OST_StructuralColumns, OST_Materials
- Parameters: STRUCTURAL_MATERIAL_PARAM, MATERIAL_ID_PARAM
- APIs: FilteredElementCollector, Pick (Selection), Element creation, FamilyManager (family editor)
- Tags: arc, column, create, family, generate, level, material, message, new, parameter, prompt, shared parameter, taskdialog, 标高, 材料, 材质, 参数, 创建, 弹窗, 共享参数, 弧, 建立, 生成, 提示, 消息, 消息框, 新建, 新增, 圆弧, 柱, 柱子, 族
- Description: TODO (hand-edit)

### CreateVerticalProfileFrame
- Path: existingCodes\饶昌锋插件源代码\105创建垂直剖面\CreateVerticalProfileFrame
- Author: 饶昌锋插件源代码
- Dialogs: "asdas", "asdasdasda", "Asda", "Asdasd"
- Categories: OST_Doors, OST_StructuralFraming
- Parameters: WALL_USER_HEIGHT_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils
- Tags: create, door, generate, height, new, wall, 创建, 高度, 建立, 门, 墙, 墙体, 生成, 新建, 新增
- Description: TODO (hand-edit)

### CutInstance
- Path: existingCodes\梁涛插件源代码\1.土建\CutInstance\CutInstance
- Author: 梁涛插件源代码
- Actions: "剪切"
- Dialogs: "ee", "revit"
- Categories: OST_StructuralFraming, OST_Walls, OST_StructuralColumns
- APIs: FilteredElementCollector, Pick (Selection)
- Tags: column, wall, 墙, 墙体, 柱, 柱子
- Description: TODO (hand-edit)

### Demo02
- Path: existingCodes\梁涛插件源代码\10.CEG\Demo02\Demo02
- Author: 梁涛插件源代码
- Actions: "ds", "Create Sketch Plane", "Create Dimensions", "Create Tags", "Create Dedicated Device Annotations"
- Dialogs: "ab", "yes", "ds", "sd", "tip"
- Categories: OST_StructuralFraming, OST_Views, OST_SpecialityEquipment
- Parameters: VIEW_TEMPLATE, LEADER_OFFSET_SHEET, TEXT_SIZE
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, Ribbon (IExternalApplication), Modeless (ExternalEvent), RayCast / ReferenceIntersector
- Integrations: Excel interop
- Tags: change, create, dimension, family, family symbol, family type, generate, length, line, meter, modify, new, offset, parameter, pipe, shared parameter, sheet, tag, tee, template, type, update, view, 标记, 标签, 标注, 参数, 尺寸标注, 创建, 打标, 调整, 更改, 更新, 共享参数, 管道, 管线, 建立, 类型, 米, 模板, 偏移, 偏移量, 三通, 生成, 视图, 水管, 图纸, 线, 新建, 新增, 修改, 长度, 直线, 族, 族符号, 族类型
- Description: TODO (hand-edit)

### FlippingBeam
- Path: existingCodes\梁涛插件源代码\1.土建\FlippingBeam\FlippingBeam
- Author: 梁涛插件源代码
- Actions: "1111", "创建梁", "修改文字注释高度", "删除所有文字注释", "删除所有梁标记"
- Dialogs: "sd", "CAD Text Information", "test", "sds", "dsda"
- Categories: OST_StructuralFraming, OST_TextNotes, OST_StructuralFramingTags, OST_StructuralFoundation, OST_GenericModel
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, Ribbon (IExternalApplication), Modeless (ExternalEvent)
- Tags: annotate, batch, beam, bulk, change, comments, create, degree, delete, dialog, family, family symbol, family type, form, foundation, generate, height, mark, message, model, modify, new, note, prompt, remove, tag, taskdialog, type, update, window, 备注, 标记, 标签, 窗口, 窗体, 创建, 打标, 弹窗, 调整, 度, 对话框, 高度, 更改, 更新, 基础, 建立, 角度, 类型, 梁, 模型, 批量, 删除, 生成, 提示, 文字注释, 消息, 消息框, 新建, 新增, 修改, 移除, 注释, 族, 族符号, 族类型
- Description: TODO (hand-edit)

### MEP_SlopeWithFloor
- Path: existingCodes\品成插件源代码\机电\MEP_SlopeWithFloor\MEP_SlopeWithFloor
- Author: 品成插件源代码
- Actions: "SlopeWithFloor", "SlopeWithFloor2"
- Categories: OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks
- Parameters: RBS_START_LEVEL_PARAM, RBS_CURVE_HEIGHT_PARAM, RBS_CABLETRAY_HEIGHT_PARAM, ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, RayCast / ReferenceIntersector
- UI: WinForms
- Tags: cable tray, ceiling, conduit, curve, diameter, floor, foundation, height, level, link, linked model, mep, meter, partition, pipe, pipe size, slab, slope, start offset, width, 板, 标高, 地板, 吊顶, 分区, 高度, 管道, 管径, 管线, 机电, 基础, 宽度, 链接, 链接模型, 楼板, 米, 坡度, 起点偏移, 桥架, 曲线, 水电, 水管, 天花板, 线槽, 线管, 直径
- Description: TODO (hand-edit)

### MEP_VerticalLocation
- Path: existingCodes\品成插件源代码\机电\MEP_VerticalLocation\MEP_VerticalLocation
- Author: 品成插件源代码
- Actions: "LocateElement"
- Categories: OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks
- Parameters: INSTANCE_FREE_HOST_OFFSET_PARAM, RBS_OFFSET_PARAM
- APIs: FilteredElementCollector, RayCast / ReferenceIntersector
- UI: WinForms
- Tags: ceiling, element, floor, foundation, link, linked model, mep, offset, slab, tee, 板, 地板, 吊顶, 构件, 机电, 基础, 链接, 链接模型, 楼板, 偏移, 偏移量, 三通, 水电, 天花板, 图元, 元素
- Description: TODO (hand-edit)

### ModifyTheElevationOfThePointLocation
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\ModifyTheElevationOfThePointLocation\ModifyTheElevationOfThePointLocation
- Author: 梁涛插件源代码
- Actions: "调整标高"
- Dialogs: "提示", "Revit"
- Categories: OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks
- Parameters: FLOOR_ATTR_THICKNESS_PARAM
- APIs: FilteredElementCollector, Pick (Selection), TransactionGroup, RayCast / ReferenceIntersector
- Tags: ceiling, change, elevation, floor, foundation, level, link, linked model, message, modify, point, prompt, slab, taskdialog, thickness, update, 板, 标高, 弹窗, 地板, 点, 吊顶, 调整, 高程, 更改, 更新, 厚度, 基础, 链接, 链接模型, 楼板, 提示, 天花板, 消息, 消息框, 修改
- Description: TODO (hand-edit)

### NetHeightDim
- Path: existingCodes\品成插件源代码\通用\NetHeightDim\NetHeightDim
- Author: 品成插件源代码
- Actions: "删除标注", "创建标注", "标注居中"
- Dialogs: "r"
- Categories: OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, RayCast / ReferenceIntersector
- UI: WinForms
- Tags: ceiling, create, delete, dimension, floor, foundation, generate, height, link, linked model, new, remove, slab, 板, 标注, 尺寸标注, 创建, 地板, 吊顶, 高度, 基础, 建立, 链接, 链接模型, 楼板, 删除, 生成, 天花板, 新建, 新增, 移除
- Description: TODO (hand-edit)

### NewCreatVerticalCableTray
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\NewCreatVerticalCableTray\NewCreatVerticalCableTray
- Author: 梁涛插件源代码
- Actions: "创建竖向桥架"
- Dialogs: "提示"
- Categories: OST_Views, OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks
- Parameters: RBS_START_LEVEL_PARAM, FLOOR_ATTR_THICKNESS_PARAM, RBS_CABLETRAY_WIDTH_PARAM, RBS_CABLETRAY_HEIGHT_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, RayCast / ReferenceIntersector
- Tags: cable tray, ceiling, create, floor, foundation, generate, height, level, link, linked model, message, new, prompt, slab, start offset, taskdialog, thickness, view, width, 板, 标高, 创建, 弹窗, 地板, 吊顶, 高度, 厚度, 基础, 建立, 宽度, 链接, 链接模型, 楼板, 起点偏移, 桥架, 生成, 视图, 提示, 天花板, 线槽, 消息, 消息框, 新建, 新增
- Description: TODO (hand-edit)

### PipeSetSlopeWithTerrian
- Path: existingCodes\品成插件源代码\土建\PipeSetSlopeWithTerrian\PipeSetSlopeWithTerrian
- Author: 品成插件源代码
- Actions: "slopePipeSet_CustomMode", "slopePipeSet_AutoMode"
- Categories: OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks
- Parameters: RBS_START_LEVEL_PARAM, ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: Pick (Selection), ElementTransformUtils, RayCast / ReferenceIntersector
- UI: WinForms
- Tags: cable tray, ceiling, conduit, curve, diameter, floor, foundation, height, level, link, linked model, meter, millimeter, mm, partition, pipe, pipe size, slab, slope, start offset, width, 板, 标高, 地板, 吊顶, 分区, 高度, 管道, 管径, 管线, 毫米, 基础, 宽度, 链接, 链接模型, 楼板, 米, 坡度, 起点偏移, 桥架, 曲线, 水管, 天花板, 线槽, 线管, 直径
- Description: TODO (hand-edit)

### ReplaceParkingPlace
- Path: existingCodes\梁涛插件源代码\2.机电建模及算量\ReplaceParkingPlace\ReplaceParkingPlace
- Author: 梁涛插件源代码
- Actions: "车位族实例替换", "元素替换"
- Dialogs: "revit", "e", "提示"
- Categories: OST_GenericModel, OST_StructuralColumns
- APIs: FilteredElementCollector, Pick (Selection), Element creation
- Tags: arrange, column, element, family, family instance, layout, message, model, place, prompt, taskdialog, 布局, 布置, 弹窗, 构件, 模型, 排布, 排列, 提示, 图元, 消息, 消息框, 元素, 柱, 柱子, 族, 族实例
- Description: TODO (hand-edit)

### ReplaceSleeve
- Path: existingCodes\梁涛插件源代码\1.土建\ReplaceSleeve\ReplaceSleeve
- Author: 梁涛插件源代码
- Actions: "获取空心柱族类型", "替换为空心柱"
- Dialogs: "rebot", "ERROR", "BIMTRANS"
- Categories: OST_StructuralColumns
- APIs: FilteredElementCollector, TransactionGroup
- UI: WinForms
- Tags: arrange, casing, column, error, family, family symbol, family type, layout, place, sleeve, type, 报错, 布局, 布置, 错误, 类型, 排布, 排列, 套管, 柱, 柱子, 族, 族符号, 族类型
- Description: TODO (hand-edit)

### ReviewDoorClearHeight
- Path: existingCodes\梁涛插件源代码\1.土建\ReviewDoorClearHeight\ReviewDoorClearHeight
- Author: 梁涛插件源代码
- Actions: "创建solid实体"
- Dialogs: "revit"
- Categories: OST_Floors, OST_StructuralFraming, OST_StructuralFoundation
- Parameters: WALL_ATTR_WIDTH_PARAM, FURNITURE_WIDTH, FAMILY_HEIGHT_PARAM
- APIs: FilteredElementCollector, Pick (Selection)
- Tags: create, door, family, floor, foundation, furniture, generate, height, new, slab, view, wall, width, 板, 创建, 地板, 高度, 基础, 家具, 建立, 宽度, 楼板, 门, 墙, 墙体, 生成, 视图, 新建, 新增, 族
- Description: TODO (hand-edit)

### ReviewParkingSpaceSpacing
- Path: existingCodes\梁涛插件源代码\1.土建\ReviewParkingSpaceSpacing\ReviewParkingSpaceSpacing
- Author: 梁涛插件源代码
- Dialogs: "BIMTRANS", "revit", "revit2"
- Categories: OST_StructuralColumns, OST_Walls
- APIs: FilteredElementCollector, Pick (Selection)
- Tags: column, view, wall, 墙, 墙体, 视图, 柱, 柱子
- Description: TODO (hand-edit)

### SplitSubSlab
- Path: existingCodes\品成插件源代码\土建\SplitSubSlab\SplitSubSlab
- Author: 品成插件源代码
- Actions: "SubSlab_Create", "SubSlab_Enable", "SubSlab_Edit"
- Dialogs: "R", "Revit", "r"
- Categories: OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks
- Parameters: LEVEL_PARAM, FLOOR_HEIGHTABOVELEVEL_PARAM
- APIs: Pick (Selection), RayCast / ReferenceIntersector
- Tags: break, ceiling, create, floor, foundation, generate, height, level, link, linked model, new, slab, split, 板, 标高, 拆分, 创建, 打断, 地板, 吊顶, 分割, 高度, 基础, 建立, 链接, 链接模型, 楼板, 生成, 天花板, 新建, 新增
- Description: TODO (hand-edit)

### SplitSubSlab
- Path: existingCodes\梁涛插件源代码\6.不常用\SplitSubSlab\SplitSubSlab
- Author: 梁涛插件源代码
- Actions: "111", "sss", "创建带坡度的楼板", "SubSlab_Create", "SubSlab_Enable"
- Dialogs: "p", "错误", "ll", "Revit"
- Parameters: LEVEL_PARAM, FLOOR_HEIGHTABOVELEVEL_PARAM, SPECIFY_SLOPE_OR_OFFSET, ROOF_SLOPE
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, TransactionGroup, RayCast / ReferenceIntersector
- Tags: break, create, degree, error, floor, generate, height, level, new, offset, roof, slab, slope, split, 板, 报错, 标高, 拆分, 创建, 错误, 打断, 地板, 度, 分割, 高度, 建立, 角度, 楼板, 偏移, 偏移量, 坡度, 生成, 屋顶, 新建, 新增
- Description: TODO (hand-edit)

### SupplySleeperBeam
- Path: existingCodes\梁涛插件源代码\1.土建\SupplySleeperBeam\SupplySleeperBeam
- Author: 梁涛插件源代码
- Actions: "补充大样/垫梁"
- Dialogs: "revit", "ERROR"
- Categories: OST_Levels, OST_Walls
- Parameters: INSTANCE_REFERENCE_LEVEL_PARAM, WALL_ATTR_WIDTH_PARAM, STRUCTURAL_BEAM_END0_ELEVATION, Z_OFFSET_VALUE, Z_JUSTIFICATION
- APIs: FilteredElementCollector, Pick (Selection), Element creation
- Tags: beam, elevation, error, floor, height, level, offset, slab, thickness, wall, width, 板, 报错, 标高, 错误, 地板, 高程, 高度, 厚度, 宽度, 梁, 楼板, 偏移, 偏移量, 墙, 墙体
- Description: TODO (hand-edit)

### VerticalPipeElevationAdjustment
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\VerticalPipeElevationAdjustment\VerticalPipeElevationAdjustment
- Author: 梁涛插件源代码
- Actions: "立管两端标高调整", "可见性设置"
- Dialogs: "提示", "revit"
- Categories: OST_Views, OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks
- Parameters: FLOOR_ATTR_THICKNESS_PARAM
- APIs: FilteredElementCollector, Pick (Selection), TransactionGroup, RayCast / ReferenceIntersector
- Tags: adjust elevation, ceiling, change, elevation, floor, foundation, level, link, linked model, message, modify, pipe, prompt, riser, slab, taskdialog, thickness, update, vertical pipe, view, 板, 标高, 标高调整, 弹窗, 地板, 吊顶, 调整, 高程, 更改, 更新, 管道, 管线, 厚度, 基础, 立管, 链接, 链接模型, 楼板, 视图, 水管, 提示, 天花板, 消息, 消息框, 修改
- Description: TODO (hand-edit)

### ViewScaling
- Path: existingCodes\梁涛插件源代码\10.CEG\ViewScaling\ViewScaling
- Author: 梁涛插件源代码
- Actions: "Move Dim", "Change DetailLine", "Move TextNote", "View Scaling", "Change DetailLine Length"
- Dialogs: "revit", "错误", "rerr"
- Categories: OST_Dimensions, OST_TextNotes, OST_StructuralFraming, OST_Lines
- Parameters: DIM_TOTAL_LENGTH
- APIs: FilteredElementCollector, Pick (Selection), TransactionGroup
- Tags: annotate, change, dimension, error, length, line, modify, move, note, tag, update, view, 报错, 标记, 标签, 标注, 尺寸标注, 错误, 打标, 调整, 更改, 更新, 视图, 文字注释, 线, 修改, 移动, 长度, 直线, 注释
- Description: TODO (hand-edit)

### WallColumnLevelBeamFloor
- Path: existingCodes\梁涛插件源代码\1.土建\WallColumnLevelBeamFloor\WallColumnLevelBeamFloor
- Author: 梁涛插件源代码
- Actions: "斜板补充"
- Dialogs: "d", "revit", "rei", "reid", "ds"
- Categories: OST_Floors, OST_Walls, OST_StructuralFraming, OST_StructuralColumns, OST_RvtLinks
- Parameters: FLOOR_PARAM_IS_STRUCTURAL, FLOOR_ATTR_THICKNESS_PARAM, FAMILY_BASE_LEVEL_PARAM, FAMILY_BASE_LEVEL_OFFSET_PARAM, WALL_BASE_CONSTRAINT
- APIs: FilteredElementCollector, Pick (Selection), TransactionGroup, RayCast / ReferenceIntersector
- Tags: base constraint, beam, column, elevation, family, floor, height, level, link, linked model, offset, slab, thickness, top constraint, type, view, wall, 板, 标高, 地板, 底部限制条件, 顶部限制条件, 高程, 高度, 厚度, 类型, 链接, 链接模型, 梁, 楼板, 偏移, 偏移量, 墙, 墙体, 视图, 柱, 柱子, 族
- Description: TODO (hand-edit)

## MEP (104)

### AddHanger
- Path: existingCodes\品成插件源代码\机电\AddHanger\AddHanger
- Author: 品成插件源代码
- Actions: "Add Hanger"
- Dialogs: "Revit", "revit"
- Categories: OST_DuctCurves, OST_PipeCurves, OST_CableTray, OST_MechanicalEquipment, OST_Conduit
- Parameters: ELEM_FAMILY_PARAM, RBS_CABLETRAY_WIDTH_PARAM, RBS_CABLETRAY_HEIGHT_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_DIAMETER_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, RayCast / ReferenceIntersector
- UI: WinForms
- Tags: cable tray, ceiling, conduit, curve, diameter, duct, family, family name, floor, foundation, hanger, height, insulation, insulation thickness, link, linked model, meter, pipe, pipe size, slab, support, thickness, width, 板, 保温, 保温厚度, 地板, 吊顶, 吊架, 风管, 高度, 隔热, 管道, 管径, 管线, 厚度, 基础, 绝缘, 宽度, 链接, 链接模型, 楼板, 米, 桥架, 曲线, 水管, 天花板, 线槽, 线管, 支吊架, 直径, 族, 族名称
- Description: TODO (hand-edit)

### AddHanger4GY
- Path: existingCodes\品成插件源代码\机电\AddHanger4GY\AddHanger4GY
- Author: 品成插件源代码
- Actions: "Add Hanger"
- Dialogs: "Revit", "revit"
- Categories: OST_CableTray, OST_DuctCurves, OST_PipeCurves, OST_Conduit, OST_MechanicalEquipment
- Parameters: ELEM_FAMILY_PARAM, RBS_REFERENCE_INSULATION_THICKNESS, RBS_CURVE_WIDTH_PARAM, RBS_PIPE_OUTER_DIAMETER, RBS_CABLETRAY_WIDTH_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, RayCast / ReferenceIntersector
- Tags: cable tray, ceiling, conduit, curve, diameter, duct, family, family name, floor, foundation, hanger, height, insulation, insulation thickness, link, linked model, meter, pipe, pipe size, slab, support, thickness, width, 板, 保温, 保温厚度, 地板, 吊顶, 吊架, 风管, 高度, 隔热, 管道, 管径, 管线, 厚度, 基础, 绝缘, 宽度, 链接, 链接模型, 楼板, 米, 桥架, 曲线, 水管, 天花板, 线槽, 线管, 支吊架, 直径, 族, 族名称
- Description: TODO (hand-edit)

### AddHanger4PLZM
- Path: existingCodes\品成插件源代码\机电\AddHanger4PLZM\AddHanger4PLZM
- Author: 品成插件源代码
- Actions: "Add Hanger4PLXC"
- Dialogs: "Revit", "revit"
- Categories: OST_PipeCurves, OST_CableTray, OST_MechanicalEquipment, OST_Floors, OST_Ceilings
- Parameters: ELEM_FAMILY_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CABLETRAY_WIDTH_PARAM, RBS_CABLETRAY_HEIGHT_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, RayCast / ReferenceIntersector
- Tags: cable tray, ceiling, curve, diameter, family, family name, floor, foundation, hanger, height, link, linked model, meter, pipe, pipe size, slab, support, width, 板, 地板, 吊顶, 吊架, 高度, 管道, 管径, 管线, 基础, 宽度, 链接, 链接模型, 楼板, 米, 桥架, 曲线, 水管, 天花板, 线槽, 支吊架, 直径, 族, 族名称
- Description: TODO (hand-edit)

### AddHangerOrHangers
- Path: existingCodes\梁涛插件源代码\4.吊架布置\AddHangerOrHangers\AddHangerOrHangers
- Author: 梁涛插件源代码
- Actions: "Add Hanger", "Add Hanger4GY"
- Dialogs: "提示", "Revit", "revit"
- Categories: OST_DuctCurves, OST_CableTray, OST_PipeCurves, OST_MechanicalEquipment, OST_Conduit
- Parameters: ELEM_FAMILY_PARAM, RBS_CABLETRAY_WIDTH_PARAM, RBS_CABLETRAY_HEIGHT_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, RayCast / ReferenceIntersector
- Tags: cable tray, ceiling, conduit, curve, diameter, duct, family, family name, floor, foundation, hanger, height, link, linked model, message, meter, pipe, pipe size, prompt, slab, support, taskdialog, width, 板, 弹窗, 地板, 吊顶, 吊架, 风管, 高度, 管道, 管径, 管线, 基础, 宽度, 链接, 链接模型, 楼板, 米, 桥架, 曲线, 水管, 提示, 天花板, 线槽, 线管, 消息, 消息框, 支吊架, 直径, 族, 族名称
- Description: TODO (hand-edit)

### AddInfoBetweenPointLocation
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AddInfoBetweenPointLocation\AddInfoBetweenPointLocation
- Author: 梁涛插件源代码
- Actions: "赋值", "读取csv创建竖向线管"
- Dialogs: "revit", "error", "ddd", "test"
- Categories: OST_ElectricalEquipment, OST_ElectricalFixtures, OST_Conduit
- Parameters: RBS_CONDUIT_DIAMETER_PARAM
- APIs: FilteredElementCollector, Pick (Selection)
- Integrations: Excel interop
- Tags: assign, conduit, create, csv, diameter, error, generate, line, meter, new, pipe size, point, set value, 报错, 创建, 错误, 点, 赋值, 管径, 建立, 米, 设置值, 生成, 线, 线管, 写入, 新建, 新增, 直径, 直线
- Description: TODO (hand-edit)

### AddLightsAccordingToCAD
- Path: existingCodes\梁涛插件源代码\2.机电建模及算量\AddLightsAccordingToCAD\AddLightsAccordingToCAD
- Author: 梁涛插件源代码
- Actions: "更改宿主", "灯具位置调整", "Add Lights"
- Dialogs: "revit", "Revit", "Error"
- Categories: OST_LightingFixtures, OST_CableTray, OST_Levels
- Parameters: RBS_START_LEVEL_PARAM, INSTANCE_SCHEDULE_ONLY_LEVEL_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, RayCast / ReferenceIntersector
- Tags: cable tray, change, error, level, lighting fixture, modify, schedule, start offset, update, 报错, 标高, 错误, 灯具, 调整, 更改, 更新, 明细表, 起点偏移, 桥架, 线槽, 修改
- Description: TODO (hand-edit)

### AddParaBySymbol
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AddParaBySymbol\AddParaBySymbol
- Author: 梁涛插件源代码
- Actions: "补充设备编号参数"
- Dialogs: "提示"
- Categories: OST_MechanicalEquipment, OST_DuctAccessory, OST_PipeAccessory
- APIs: FilteredElementCollector
- Tags: duct, mechanical equipment, message, parameter, pipe, prompt, shared parameter, taskdialog, 参数, 弹窗, 风管, 共享参数, 管道, 管线, 机械设备, 设备, 水管, 提示, 消息, 消息框
- Description: TODO (hand-edit)

### AddSleeveDiameter
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AddSleeveDiameter\AddSleeveDiameter
- Author: 梁涛插件源代码
- Actions: "sss", "套管管径标识参数赋值"
- Dialogs: "dd", "Revit"
- Categories: OST_PipeCurves, OST_MechanicalEquipment
- Parameters: RBS_PIPE_DIAMETER_PARAM
- APIs: FilteredElementCollector, Pick (Selection)
- Tags: assign, casing, curve, diameter, meter, parameter, pipe, pipe size, set value, shared parameter, sleeve, 参数, 赋值, 共享参数, 管道, 管径, 管线, 米, 曲线, 设置值, 水管, 套管, 写入, 直径
- Description: TODO (hand-edit)

### AdjustCableTray
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AdjustCableTray\AdjustCableTray
- Author: 梁涛插件源代码
- Actions: "move", "调整照明线槽"
- Dialogs: "模术师产品介绍", "revit", "提示"
- Categories: OST_StairsRailing, OST_CableTray
- APIs: FilteredElementCollector, Pick (Selection)
- Tags: cable tray, change, line, message, modify, move, prompt, railing, stair, taskdialog, update, 弹窗, 调整, 更改, 更新, 栏杆, 楼梯, 桥架, 提示, 线, 线槽, 消息, 消息框, 修改, 移动, 直线
- Description: TODO (hand-edit)

### AlignmentOfPipelineBends
- Path: existingCodes\梁涛插件源代码\3.管综\AlignmentOfPipelineBends\AlignmentOfPipelineBends
- Author: 梁涛插件源代码
- Actions: "管线弯通对齐"
- Dialogs: "提示"
- Categories: OST_PipeFitting, OST_CableTrayFitting, OST_DuctFitting
- APIs: Pick (Selection), ElementTransformUtils
- Tags: align, bend, cable tray, duct, elbow, line, message, pipe, pipe fitting, prompt, taskdialog, 弹窗, 对齐, 风管, 管道, 管件, 管线, 桥架, 三通, 水管, 提示, 弯头, 线, 线槽, 消息, 消息框, 直线
- Description: TODO (hand-edit)

### ArrangeHangerAccordingToNozzle
- Path: existingCodes\梁涛插件源代码\4.吊架布置\ArrangeHangerAccordingToNozzle\ArrangeHangerAccordingToNozzle
- Author: 梁涛插件源代码
- Actions: "AddPipeHanger"
- Dialogs: "提示", "revit", "fdf", "sd"
- Categories: OST_Sprinklers, OST_Levels, OST_PipeCurves, OST_CableTray, OST_Floors
- Parameters: RBS_PIPE_DIAMETER_PARAM, CURVE_ELEM_LENGTH, RBS_START_LEVEL_PARAM, RBS_END_OFFSET_PARAM, INSTANCE_FREE_HOST_OFFSET_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, Ribbon (IExternalApplication), RayCast / ReferenceIntersector
- Tags: arrange, cable tray, ceiling, curve, diameter, duct, elevation, floor, foundation, hanger, layout, length, level, link, linked model, message, meter, offset, pipe, pipe size, place, prompt, slab, sprinkler, start offset, support, taskdialog, thickness, wall, width, 板, 标高, 布局, 布置, 弹窗, 地板, 吊顶, 吊架, 风管, 高程, 管道, 管径, 管线, 厚度, 基础, 宽度, 链接, 链接模型, 楼板, 米, 排布, 排列, 喷淋, 喷头, 偏移, 偏移量, 起点偏移, 墙, 墙体, 桥架, 曲线, 水管, 提示, 天花板, 线槽, 消息, 消息框, 长度, 支吊架, 直径
- Description: TODO (hand-edit)

### ArrangeHangerAccordingToNozzle
- Path: existingCodes\梁涛插件源代码\4.吊架布置\ArrangeHangerAccordingToNozzle（框选）\ArrangeHangerAccordingToNozzle
- Author: 梁涛插件源代码
- Actions: "AddHanger"
- Dialogs: "提示"
- Categories: OST_PipeCurves, OST_Levels, OST_CableTray, OST_Floors, OST_Ceilings
- Parameters: CURVE_ELEM_LENGTH, RBS_START_LEVEL_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_END_OFFSET_PARAM, INSTANCE_FREE_HOST_OFFSET_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, RayCast / ReferenceIntersector
- Tags: arrange, cable tray, ceiling, curve, diameter, duct, elevation, floor, foundation, hanger, layout, length, level, link, linked model, message, meter, offset, pipe, pipe size, place, prompt, slab, start offset, support, taskdialog, thickness, wall, width, 板, 标高, 布局, 布置, 弹窗, 地板, 吊顶, 吊架, 风管, 高程, 管道, 管径, 管线, 厚度, 基础, 宽度, 链接, 链接模型, 楼板, 米, 排布, 排列, 偏移, 偏移量, 起点偏移, 墙, 墙体, 桥架, 曲线, 水管, 提示, 天花板, 线槽, 消息, 消息框, 长度, 支吊架, 直径
- Description: TODO (hand-edit)

### ArrangeSingleOrMultiplePipeHangersInTheLinkedModel
- Path: existingCodes\梁涛插件源代码\4.吊架布置\ArrangeSingleOrMultiplePipeHangersInTheLinkedModel\ArrangeSingleOrMultiplePipeHangersInTheLinkedModel
- Author: 梁涛插件源代码
- Actions: "Add Hanger", "Add Hanger4GY"
- Dialogs: "提示", "Revit", "revit"
- Categories: OST_DuctCurves, OST_CableTray, OST_PipeCurves, OST_MechanicalEquipment, OST_Conduit
- Parameters: ELEM_FAMILY_PARAM, RBS_CABLETRAY_WIDTH_PARAM, RBS_CABLETRAY_HEIGHT_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, RayCast / ReferenceIntersector
- Tags: arrange, cable tray, ceiling, conduit, curve, diameter, duct, family, family name, floor, foundation, hanger, height, layout, link, linked model, message, meter, model, pipe, pipe size, place, prompt, slab, support, taskdialog, width, 板, 布局, 布置, 弹窗, 地板, 吊顶, 吊架, 风管, 高度, 管道, 管径, 管线, 基础, 宽度, 链接, 链接模型, 楼板, 米, 模型, 排布, 排列, 桥架, 曲线, 水管, 提示, 天花板, 线槽, 线管, 消息, 消息框, 支吊架, 直径, 族, 族名称
- Description: TODO (hand-edit)

### AttributeAssignmentOfConduitPath
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AttributeAssignmentOfConduitPath\AttributeAssignmentOfConduitPath
- Author: 梁涛插件源代码
- Actions: "线管通路赋值"
- Dialogs: "revit", "re"
- Categories: OST_Conduit, OST_ElectricalFixtures
- Parameters: ELEM_PARTITION_PARAM, RBS_CONDUIT_DIAMETER_PARAM
- APIs: FilteredElementCollector
- Integrations: Excel interop
- Tags: assign, conduit, diameter, line, meter, partition, pipe size, set value, 分区, 赋值, 管径, 米, 设置值, 线, 线管, 写入, 直径, 直线
- Description: TODO (hand-edit)

### BatchArrangementOfHangersBetweenBeams
- Path: existingCodes\梁涛插件源代码\11.其他\BatchArrangementOfHangersBetweenBeams\BatchArrangementOfHangersBetweenBeams
- Author: 梁涛插件源代码
- Dialogs: "Revit", "提示"
- Categories: OST_MechanicalEquipment, OST_CableTray, OST_PipeCurves, OST_StructuralFraming, OST_Floors
- Parameters: RBS_START_LEVEL_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_PIPE_OUTER_DIAMETER, RBS_CABLETRAY_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, Modeless (ExternalEvent), RayCast / ReferenceIntersector
- Tags: arrange, batch, beam, bulk, cable tray, ceiling, curve, diameter, duct, floor, foundation, hanger, height, layout, level, link, linked model, message, meter, pipe, pipe size, place, prompt, slab, start offset, support, taskdialog, width, 板, 标高, 布局, 布置, 弹窗, 地板, 吊顶, 吊架, 风管, 高度, 管道, 管径, 管线, 基础, 宽度, 链接, 链接模型, 梁, 楼板, 米, 排布, 排列, 批量, 起点偏移, 桥架, 曲线, 水管, 提示, 天花板, 线槽, 消息, 消息框, 支吊架, 直径
- Description: TODO (hand-edit)

### CalculatePipeLength
- Path: existingCodes\梁涛插件源代码\3.管综\CalculatePipeLength\CalculatePipeLength
- Author: 梁涛插件源代码
- Parameters: CURVE_ELEM_LENGTH
- APIs: Pick (Selection)
- Tags: curve, length, pipe, 管道, 管线, 曲线, 水管, 长度
- Description: TODO (hand-edit)

### CEGRegister
- Path: existingCodes\梁涛插件源代码\10.CEG\CEGRegister\CEGRegister
- Author: 梁涛插件源代码
- Actions: "Add Hanger", "Add Hanger4PLXC", "创建文字注释类型", "创建吊架文字注释", "TAGHELPER"
- Dialogs: "Revit", "revit", "ll", "提示", "载入族错误"
- Categories: OST_DuctCurves, OST_PipeCurves, OST_CableTray, OST_Views, OST_MechanicalEquipment
- Parameters: TEXT_SIZE, ELEM_FAMILY_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM, RBS_PIPE_DIAMETER_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, Ribbon (IExternalApplication), TransactionGroup, RayCast / ReferenceIntersector
- UI: WinForms
- Integrations: JSON, HTTP
- Tags: annotate, cable tray, ceiling, comments, conduit, create, curve, diameter, dimension, duct, element, error, family, family name, floor, foundation, generate, hanger, height, link, linked model, mark, message, meter, new, note, offset, pipe, pipe size, prompt, sheet, slab, support, tag, taskdialog, tee, type, view, width, 板, 报错, 备注, 标记, 标签, 标注, 尺寸标注, 创建, 错误, 打标, 弹窗, 地板, 吊顶, 吊架, 风管, 高度, 构件, 管道, 管径, 管线, 基础, 建立, 宽度, 类型, 链接, 链接模型, 楼板, 米, 偏移, 偏移量, 桥架, 曲线, 三通, 生成, 视图, 水管, 提示, 天花板, 图元, 图纸, 文字注释, 线槽, 线管, 消息, 消息框, 新建, 新增, 元素, 支吊架, 直径, 注释, 族, 族名称
- Description: TODO (hand-edit)

### ConnectConduitByNode
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\ConnectConduitByNode\ConnectConduitByNode
- Author: 梁涛插件源代码
- Actions: "延长线管", "载入拓扑族"
- Dialogs: "Error", "提示"
- Categories: OST_GenericModel
- APIs: FilteredElementCollector, Pick (Selection), Element creation, TransactionGroup
- Tags: conduit, connect, error, family, join, line, message, model, prompt, taskdialog, 报错, 错误, 弹窗, 合并, 连接, 模型, 提示, 线, 线管, 消息, 消息框, 直线, 族
- Description: TODO (hand-edit)

### CopyParameterValue
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\CopyParameterValue\CopyParameterValue
- Author: 梁涛插件源代码
- Actions: "编号参数赋值"
- Dialogs: "revit", "提示"
- Categories: OST_ElectricalEquipment
- APIs: FilteredElementCollector
- Tags: assign, copy, message, meter, parameter, prompt, set value, shared parameter, taskdialog, 参数, 弹窗, 复制, 赋值, 共享参数, 米, 设置值, 提示, 消息, 消息框, 写入
- Description: TODO (hand-edit)

### CopySameParameterValue
- Path: existingCodes\梁涛插件源代码\6.不常用\CopySameParameterValue\CopySameParameterValue
- Author: 梁涛插件源代码
- Actions: "参数复制", "统一相同参数值"
- Dialogs: "e", "r"
- Categories: OST_MechanicalEquipment, OST_ElectricalEquipment, OST_PipeAccessory, OST_DuctAccessory
- APIs: FilteredElementCollector
- Tags: copy, duct, mep, meter, parameter, pipe, shared parameter, 参数, 风管, 复制, 共享参数, 管道, 管线, 机电, 米, 水电, 水管
- Description: TODO (hand-edit)

### CorrectionOfCasingAngle
- Path: existingCodes\梁涛插件源代码\10.CEG\CorrectionOfCasingAngle\CorrectionOfCasingAngle
- Author: 梁涛插件源代码
- Actions: "修正套筒角度"
- Dialogs: "sd", "qqq", "提示"
- Categories: OST_PipeFitting, OST_MechanicalEquipment, OST_PipeCurves, OST_CableTray
- APIs: FilteredElementCollector, ElementTransformUtils
- Tags: cable tray, casing, curve, degree, elbow, message, pipe, pipe fitting, prompt, sleeve, taskdialog, 弹窗, 度, 管道, 管件, 管线, 角度, 桥架, 曲线, 三通, 水管, 套管, 提示, 弯头, 线槽, 消息, 消息框
- Description: TODO (hand-edit)

### CorrectionOfJunctionBoxHeight
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\CorrectionOfJunctionBoxHeight\CorrectionOfJunctionBoxHeight
- Author: 梁涛插件源代码
- Actions: "旋转", "尺寸标注", "贴墙", "接线盒 线管 高度修正", "接线盒贴墙"
- Dialogs: "revit", "ref", "提示", "re", "ssss"
- Categories: OST_Views, OST_ElectricalFixtures, OST_Conduit, OST_CommunicationDevices, OST_DataDevices
- Parameters: FLOOR_ATTR_THICKNESS_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Ribbon (IExternalApplication), TransactionGroup, RayCast / ReferenceIntersector
- Integrations: Excel interop
- Tags: ceiling, conduit, degree, dimension, floor, foundation, height, line, link, linked model, mechanical equipment, message, millimeter, mm, prompt, rotate, slab, taskdialog, thickness, view, wall, 板, 标注, 尺寸标注, 弹窗, 地板, 吊顶, 度, 高度, 毫米, 厚度, 机械设备, 基础, 角度, 链接, 链接模型, 楼板, 墙, 墙体, 设备, 视图, 提示, 天花板, 线, 线管, 消息, 消息框, 旋转, 直线
- Description: TODO (hand-edit)

### CreateBoxByPointLocation
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\CreateBoxByPointLocation\CreateBoxByPointLocation
- Author: 梁涛插件源代码
- Actions: "创建接线盒"
- Dialogs: "提示"
- Categories: OST_CommunicationDevices, OST_SecurityDevices, OST_LightingFixtures, OST_DataDevices, OST_TelephoneDevices
- APIs: FilteredElementCollector, ElementTransformUtils, Element creation
- Integrations: Excel interop
- Tags: create, generate, line, message, millimeter, mm, new, point, prompt, taskdialog, 创建, 弹窗, 点, 毫米, 建立, 生成, 提示, 线, 消息, 消息框, 新建, 新增, 直线
- Description: TODO (hand-edit)

### CreateBoxCabletrayOrConduit
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\CreateBoxCabletrayOrConduit\CreateBoxCabletrayOrConduit
- Author: 梁涛插件源代码
- Actions: "创建竖向桥架", "创建竖向线管", "可见性设置"
- Dialogs: "revit", "Error", "error"
- Categories: OST_ElectricalEquipment, OST_CableTray, OST_Conduit
- Parameters: RBS_CTC_BOTTOM_ELEVATION, RBS_START_LEVEL_PARAM, RBS_CABLETRAY_WIDTH_PARAM, RBS_CONDUIT_DIAMETER_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, TransactionGroup
- Integrations: Excel interop
- Tags: cable tray, conduit, create, diameter, elevation, error, generate, level, line, meter, new, pipe size, start offset, width, 报错, 标高, 创建, 错误, 高程, 管径, 建立, 宽度, 米, 起点偏移, 桥架, 生成, 线, 线槽, 线管, 新建, 新增, 直径, 直线
- Description: TODO (hand-edit)

### CreateDimensionsForVerticalPoleHanger
- Path: existingCodes\梁涛插件源代码\5.吊架出图\CreateDimensionsForVerticalPoleHanger\CreateDimensionsForVerticalPoleHanger
- Author: 梁涛插件源代码
- Actions: "创建尺寸标注"
- Categories: OST_MechanicalEquipment
- APIs: FilteredElementCollector
- Tags: create, dimension, generate, hanger, new, support, 标注, 尺寸标注, 创建, 吊架, 建立, 生成, 新建, 新增, 支吊架
- Description: TODO (hand-edit)

### CreateMaskByHeight
- Path: existingCodes\饶昌锋插件源代码\266分析管线净高填色\CreateMaskByHeight
- Author: 饶昌锋插件源代码
- Actions: "Asda"
- Categories: OST_Floors, OST_DuctCurves, OST_CableTray, OST_PipeCurves, OST_Walls
- Parameters: RBS_CURVE_HEIGHT_PARAM, RBS_CURVE_DIAMETER_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CABLETRAY_HEIGHT_PARAM, RBS_CURVE_WIDTH_PARAM
- APIs: FilteredElementCollector, Pick (Selection), RayCast / ReferenceIntersector
- UI: WinForms
- Tags: cable tray, create, curve, diameter, duct, floor, generate, height, meter, new, pipe, pipe size, slab, wall, width, 板, 创建, 地板, 风管, 高度, 管道, 管径, 管线, 建立, 宽度, 楼板, 米, 墙, 墙体, 桥架, 曲线, 生成, 水管, 线槽, 新建, 新增, 直径
- Description: TODO (hand-edit)

### CreateSteelPipes
- Path: existingCodes\梁涛插件源代码\10.CEG\CreateSteelPipes\CreateSteelPipes
- Author: 梁涛插件源代码
- Actions: "Create Steel Pipe"
- Dialogs: "tips"
- Categories: OST_SpecialityEquipment
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation
- Tags: create, generate, new, pipe, tee, 创建, 管道, 管线, 建立, 三通, 生成, 水管, 新建, 新增
- Description: TODO (hand-edit)

### CreateTextAnnotationsForHangerHeight
- Path: existingCodes\梁涛插件源代码\5.吊架出图\CreateTextAnnotationsForHangerHeight\CreateTextAnnotationsForHangerHeight
- Author: 梁涛插件源代码
- Actions: "吊架增加横担标高文字注释"
- Dialogs: "Revit", "提示", "wds", "ds"
- Categories: OST_Views, OST_MechanicalEquipment, OST_Floors, OST_MechanicalEquipmentTags
- Parameters: LEADER_OFFSET_SHEET, TEXT_SIZE
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, RayCast / ReferenceIntersector
- Tags: annotate, comments, create, elevation, floor, generate, hanger, height, level, message, new, note, offset, prompt, sheet, slab, support, tag, taskdialog, view, 板, 备注, 标高, 标记, 标签, 创建, 打标, 弹窗, 地板, 吊架, 高程, 高度, 建立, 楼板, 偏移, 偏移量, 生成, 视图, 提示, 图纸, 文字注释, 消息, 消息框, 新建, 新增, 支吊架, 注释
- Description: TODO (hand-edit)

### CreateTextForBothEndsOfPipeline
- Path: existingCodes\梁涛插件源代码\5.吊架出图\CreateTextForBothEndsOfPipeline\CreateTextForBothEndsOfPipeline
- Author: 梁涛插件源代码
- Actions: "管道两端底部高程文字注释"
- Dialogs: "sd", "dd"
- Parameters: LEADER_OFFSET_SHEET
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils
- Tags: annotate, comments, create, elevation, generate, line, new, note, offset, pipe, sheet, 备注, 标高, 创建, 高程, 管道, 管线, 建立, 偏移, 偏移量, 生成, 水管, 图纸, 文字注释, 线, 新建, 新增, 直线, 注释
- Description: TODO (hand-edit)

### CreateVerticalBridges
- Path: existingCodes\饶昌锋插件源代码\256创建竖向桥架\CreateVerticalBridges
- Author: 饶昌锋插件源代码
- Actions: "创建桥架", "dimAnnotation", "对齐直线型桥架", "Move Bridge 2", "载入族"
- Dialogs: "提示", "Asda0", "revit", "asdas", "asd"
- Categories: OST_CableTrayFitting
- Parameters: RBS_CABLETRAY_WIDTH_PARAM, RBS_CABLETRAY_HEIGHT_PARAM, RBS_END_OFFSET_PARAM, RBS_CTC_TOP_ELEVATION, RBS_OFFSET_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, Modeless (ExternalEvent), TransactionGroup
- Tags: align, bend, cable tray, create, curve, elbow, elevation, family, generate, height, length, level, line, message, move, new, offset, pipe fitting, prompt, start offset, taskdialog, tee, type, width, 标高, 创建, 弹窗, 对齐, 高程, 高度, 管件, 建立, 宽度, 类型, 偏移, 偏移量, 起点偏移, 桥架, 曲线, 三通, 生成, 提示, 弯头, 线, 线槽, 消息, 消息框, 新建, 新增, 移动, 长度, 直线, 族
- Description: TODO (hand-edit)

### CreateVerticalConduitForJunctionBox
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\CreateVerticalConduitForJunctionBox\CreateVerticalConduitForJunctionBox
- Author: 梁涛插件源代码
- Actions: "墙内接线盒创建竖向线管", "可见性设置"
- Dialogs: "提示", "Revit", "revit"
- Categories: OST_Views, OST_ElectricalFixtures, OST_Floors, OST_Ceilings, OST_StructuralFoundation
- Parameters: RBS_CONDUIT_DIAMETER_PARAM, ELEM_PARTITION_PARAM
- APIs: FilteredElementCollector, RayCast / ReferenceIntersector
- Integrations: Excel interop
- Tags: ceiling, conduit, create, diameter, floor, foundation, generate, line, link, linked model, message, meter, new, partition, pipe size, prompt, slab, taskdialog, view, wall, 板, 创建, 弹窗, 地板, 吊顶, 分区, 管径, 基础, 建立, 链接, 链接模型, 楼板, 米, 墙, 墙体, 生成, 视图, 提示, 天花板, 线, 线管, 消息, 消息框, 新建, 新增, 直径, 直线
- Description: TODO (hand-edit)

### DuctAndCableTrayDetailCurve
- Path: existingCodes\品成插件源代码\机电\DuctAndCableTrayDetailCurve\DuctAndCableTrayDetailCurve
- Author: 品成插件源代码
- Actions: "详图线"
- Categories: OST_DuctCurves, OST_CableTray
- APIs: Pick (Selection)
- Tags: cable tray, curve, duct, line, 风管, 桥架, 曲线, 线, 线槽, 直线
- Description: TODO (hand-edit)

### FindBrokenCableTrays
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\FindBrokenCableTrays\FindBrokenCableTrays
- Author: 梁涛插件源代码
- Categories: OST_CableTray
- APIs: FilteredElementCollector
- Tags: cable tray, 桥架, 线槽
- Description: TODO (hand-edit)

### FindLightPath
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\FindLightPath\FindLightPath
- Author: 梁涛插件源代码
- Actions: "创建拓扑线", "test", "复制管道类型并重命名", "添加项目参数", "激活族类型"
- Dialogs: "提示", "Revit", "revitee", "revit", "reit"
- Categories: OST_LightingFixtures, OST_CableTray, OST_Conduit, OST_ElectricalEquipment, OST_GenericModel
- Parameters: RBS_START_LEVEL_PARAM, RBS_CONDUIT_DIAMETER_PARAM, ALL_MODEL_INSTANCE_COMMENTS, ELEM_TYPE_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, Modeless (ExternalEvent), TransactionGroup, RayCast / ReferenceIntersector, Shared parameters
- UI: WinForms
- Integrations: Excel interop
- Tags: assign, break, cable tray, comments, conduit, connect, copy, create, delete, diameter, elbow, error, family, family symbol, family type, foundation, generate, hide, join, level, lighting fixture, line, message, meter, millimeter, mm, model, new, parameter, pipe, pipe fitting, pipe size, point, project, project parameter, prompt, remove, rename, set value, shared parameter, split, start offset, taskdialog, tee, type, 报错, 备注, 标高, 参数, 拆分, 创建, 错误, 打断, 弹窗, 灯具, 点, 分割, 复制, 赋值, 共享参数, 管道, 管件, 管径, 管线, 毫米, 合并, 基础, 建立, 类型, 连接, 米, 模型, 起点偏移, 桥架, 三通, 删除, 设置值, 生成, 水管, 提示, 弯头, 线, 线槽, 线管, 项目, 项目参数, 消息, 消息框, 写入, 新建, 新增, 移除, 隐藏, 直径, 直线, 重命名, 注释, 族, 族符号, 族类型
- Description: TODO (hand-edit)

### GateValvePressureCorrection
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\GateValvePressureCorrection\GateValvePressureCorrection
- Author: 梁涛插件源代码
- Actions: "闸阀压力修正"
- Dialogs: "dsd", "提示"
- Categories: OST_PipeAccessory
- APIs: FilteredElementCollector
- Tags: message, pipe, pipe accessory, prompt, taskdialog, valve, 弹窗, 阀门, 管道, 管道附件, 管线, 水管, 提示, 消息, 消息框
- Description: TODO (hand-edit)

### HangerAlignment
- Path: existingCodes\饶昌锋插件源代码\257吊架对齐\HangerAlignment
- Author: 饶昌锋插件源代码
- Actions: "吊架对齐"
- Dialogs: "revit", "提示"
- Categories: OST_MechanicalEquipment
- APIs: Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: align, hanger, message, prompt, support, taskdialog, 弹窗, 吊架, 对齐, 提示, 消息, 消息框, 支吊架
- Description: TODO (hand-edit)

### HangerClassificationAnnotation
- Path: existingCodes\饶昌锋插件源代码\258吊架分类编号并标记\HangerClassificationAnnotation
- Author: 饶昌锋插件源代码
- Actions: "添加属性", "修改类别编号", "添加标记", "Move Bridge 2"
- Dialogs: "Asdas", "asd", "提示", "Asdasd"
- Categories: OST_MechanicalEquipment
- Parameters: LEADER_OFFSET_SHEET, TEXT_SIZE
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Modeless (ExternalEvent), FamilyManager (family editor)
- Tags: change, hanger, mark, message, modify, move, offset, prompt, sheet, support, tag, taskdialog, update, 标记, 标签, 打标, 弹窗, 吊架, 调整, 更改, 更新, 偏移, 偏移量, 提示, 图纸, 消息, 消息框, 修改, 移动, 支吊架
- Description: TODO (hand-edit)

### HangerUpdate
- Path: existingCodes\梁涛插件源代码\4.吊架布置\HangerUpdate\HangerUpdate
- Author: 梁涛插件源代码
- Actions: "三维视图详细程度设置", "吊架顶端对齐顶板", "调整套筒高度+吊架位置+直径", "调整吊架照明线槽套筒"
- Dialogs: "rveit", "revit", "Revit"
- Categories: OST_MechanicalEquipment, OST_PipeCurves, OST_Floors, OST_Ceilings, OST_StructuralFoundation
- Parameters: VIEW_DETAIL_LEVEL, RBS_PIPE_DIAMETER_PARAM, RBS_END_OFFSET_PARAM, RBS_START_OFFSET_PARAM
- APIs: FilteredElementCollector, TransactionGroup
- UI: WinForms
- Tags: 3d view, 3d视图, align, cable tray, ceiling, change, curve, degree, diameter, floor, foundation, hanger, height, level, line, link, linked model, meter, modify, offset, pipe, pipe size, slab, start offset, support, update, view, 板, 标高, 地板, 吊顶, 吊架, 调整, 度, 对齐, 高度, 更改, 更新, 管道, 管径, 管线, 基础, 角度, 链接, 链接模型, 楼板, 米, 偏移, 偏移量, 起点偏移, 桥架, 曲线, 三维视图, 视图, 水管, 天花板, 线, 线槽, 修改, 支吊架, 直径, 直线
- Description: TODO (hand-edit)

### HeightOFSprayPipeToTopPlate
- Path: existingCodes\饶昌锋插件源代码\259判断喷淋支管和顶板的高差\HeightOFSprayPipeToTopPlate
- Author: 饶昌锋插件源代码
- Dialogs: "sadas", "提示", "报错"
- Categories: OST_PipeCurves, OST_Floors, OST_MechanicalEquipment
- Parameters: RBS_PIPE_DIAMETER_PARAM, RBS_PIPING_SYSTEM_TYPE_PARAM
- APIs: FilteredElementCollector, Modeless (ExternalEvent), RayCast / ReferenceIntersector
- Tags: curve, diameter, error, floor, height, message, meter, pipe, pipe size, prompt, slab, system, system type, taskdialog, type, 板, 报错, 错误, 弹窗, 地板, 高度, 管道, 管径, 管线, 类型, 楼板, 米, 曲线, 水管, 提示, 系统, 系统类型, 消息, 消息框, 直径
- Description: TODO (hand-edit)

### ImproveEquipmentInformation
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\ImproveEquipmentInformation\ImproveEquipmentInformation
- Author: 梁涛插件源代码
- Actions: "补充设备信息", "可见性设置"
- Dialogs: "提示", "revit"
- Categories: OST_Views, OST_MechanicalEquipment
- APIs: FilteredElementCollector
- Integrations: Excel interop
- Tags: dialog, form, mechanical equipment, message, prompt, taskdialog, view, window, 窗口, 窗体, 弹窗, 对话框, 机械设备, 设备, 视图, 提示, 消息, 消息框
- Description: TODO (hand-edit)

### InspectionWellElevationAdjustment
- Path: existingCodes\梁涛插件源代码\2.机电建模及算量\InspectionWellElevationAdjustment\InspectionWellElevationAdjustment
- Author: 梁涛插件源代码
- Actions: "检查井标高调整"
- Dialogs: "BIMTRANS"
- Categories: OST_PipeCurves, OST_GenericModel
- APIs: FilteredElementCollector, Pick (Selection)
- Tags: adjust elevation, audit, change, check, curve, elevation, level, model, modify, pipe, update, validate, 标高, 标高调整, 调整, 高程, 更改, 更新, 管道, 管线, 检查, 模型, 曲线, 审查, 水管, 校验, 修改
- Description: TODO (hand-edit)

### MarkBothEndsOfTheRampPipeline
- Path: existingCodes\梁涛插件源代码\6.不常用\MarkBothEndsOfTheRampPipeline\MarkBothEndsOfTheRampPipeline
- Author: 梁涛插件源代码
- Actions: "坡道管线两边标注"
- Dialogs: "Revit", "提示", "ww", "ll"
- APIs: FilteredElementCollector, Pick (Selection)
- Tags: dimension, line, mark, message, pipe, prompt, taskdialog, 标记, 标注, 尺寸标注, 弹窗, 管道, 管线, 水管, 提示, 线, 消息, 消息框, 直线
- Description: TODO (hand-edit)

### MEP_3DViewCreater
- Path: existingCodes\品成插件源代码\机电\MEP_3DViewCreater\MEP_3DViewCreater
- Author: 品成插件源代码
- Actions: "SetSectionBox"
- Dialogs: "a", "提示"
- Parameters: VIEW_NAME
- APIs: FilteredElementCollector
- UI: WinForms
- Tags: create, generate, mep, message, new, prompt, taskdialog, view, 创建, 弹窗, 机电, 建立, 生成, 视图, 水电, 提示, 消息, 消息框, 新建, 新增
- Description: TODO (hand-edit)

### MEP_AddSEblow
- Path: existingCodes\品成插件源代码\机电\MEP_AddSEblow\MEP_AddSEblow
- Author: 品成插件源代码
- Actions: "Add SEblow"
- Dialogs: "revit", "Revit"
- Categories: OST_PipeAccessory
- Parameters: ELEM_FAMILY_PARAM, RBS_PIPING_SYSTEM_TYPE_PARAM
- APIs: FilteredElementCollector, Pick (Selection), Element creation
- Tags: family, family name, mep, pipe, system, system type, type, 管道, 管线, 机电, 类型, 水电, 水管, 系统, 系统类型, 族, 族名称
- Description: TODO (hand-edit)

### MEP_AlignIn3D
- Path: existingCodes\品成插件源代码\机电\MEP_AlignIn3D\MEP_AlignIn3D
- Author: 品成插件源代码
- Actions: "三维对齐AlignIn3D"
- Parameters: ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM, RBS_CABLETRAY_WIDTH_PARAM
- APIs: Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: align, cable tray, conduit, curve, diameter, height, mep, meter, partition, pipe, pipe size, width, 对齐, 分区, 高度, 管道, 管径, 管线, 机电, 宽度, 米, 桥架, 曲线, 水电, 水管, 线槽, 线管, 直径
- Description: TODO (hand-edit)

### MEP_Connecter
- Path: existingCodes\品成插件源代码\机电\MEP_Connecter\MEP_Connecter
- Author: 品成插件源代码
- Actions: "旋转三通"
- Dialogs: "a"
- Parameters: RBS_PIPE_DIAMETER_PARAM, ELEM_PARTITION_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM, RBS_CURVE_DIAMETER_PARAM
- APIs: Pick (Selection)
- Tags: cable tray, conduit, connect, curve, diameter, elbow, height, join, mep, meter, partition, pipe, pipe fitting, pipe size, rotate, tee, width, 分区, 高度, 管道, 管件, 管径, 管线, 合并, 机电, 宽度, 连接, 米, 桥架, 曲线, 三通, 水电, 水管, 弯头, 线槽, 线管, 旋转, 直径
- Description: TODO (hand-edit)

### MEP_CreateSectionViewParallelToPipe
- Path: existingCodes\品成插件源代码\机电\MEP_CreateSectionViewParallelToPipe\MEP_CreateSectionViewParallelToPipe
- Author: 品成插件源代码
- APIs: FilteredElementCollector, Pick (Selection)
- UI: WinForms
- Tags: create, generate, mep, new, pipe, view, 创建, 管道, 管线, 机电, 建立, 生成, 视图, 水电, 水管, 新建, 新增
- Description: TODO (hand-edit)

### MEP_CreateSectionViewPerpendicularToPipe
- Path: existingCodes\品成插件源代码\机电\MEP_CreateSectionViewPerpendicularToPipe\MEP_CreateSectionViewPerpendicularToPipe
- Author: 品成插件源代码
- APIs: FilteredElementCollector, Pick (Selection)
- UI: WinForms
- Tags: create, generate, mep, new, pipe, view, 创建, 管道, 管线, 机电, 建立, 生成, 视图, 水电, 水管, 新建, 新增
- Description: TODO (hand-edit)

### MEP_FittingOffset
- Path: existingCodes\品成插件源代码\机电\MEP_FittingOffset\MEP_FittingOffset
- Author: 品成插件源代码
- Actions: "机电管线避让"
- Dialogs: "警告"
- Parameters: RBS_START_LEVEL_PARAM, ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, height, level, line, mep, meter, offset, offset pipe, partition, pipe, pipe size, start offset, warning, width, 避让, 标高, 分区, 高度, 管道, 管道偏移, 管径, 管线, 机电, 警告, 宽度, 米, 偏移, 偏移量, 起点偏移, 桥架, 曲线, 水电, 水管, 线, 线槽, 线管, 直径, 直线
- Description: TODO (hand-edit)

### MEP_FittingOffset_Smart
- Path: existingCodes\品成插件源代码\机电\MEP_FittingOffset_Smart\MEP_FittingOffset_Smart
- Author: 品成插件源代码
- Actions: "机电管线避让"
- Dialogs: "提示", "a", "警告"
- Parameters: RBS_START_LEVEL_PARAM, ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: Pick (Selection), ElementTransformUtils
- Tags: cable tray, conduit, curve, diameter, height, level, line, mep, message, meter, offset, offset pipe, partition, pipe, pipe size, prompt, start offset, taskdialog, warning, width, 避让, 标高, 弹窗, 分区, 高度, 管道, 管道偏移, 管径, 管线, 机电, 警告, 宽度, 米, 偏移, 偏移量, 起点偏移, 桥架, 曲线, 水电, 水管, 提示, 线, 线槽, 线管, 消息, 消息框, 直径, 直线
- Description: TODO (hand-edit)

### MEP_FittingOffsetFour
- Path: existingCodes\品成插件源代码\机电\MEP_FittingOffsetFour\MEP_FittingOffsetFour
- Author: 品成插件源代码
- Actions: "机电管线避让"
- Dialogs: "警告"
- Parameters: RBS_START_LEVEL_PARAM, ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, height, level, line, mep, meter, offset, offset pipe, partition, pipe, pipe size, start offset, warning, width, 避让, 标高, 分区, 高度, 管道, 管道偏移, 管径, 管线, 机电, 警告, 宽度, 米, 偏移, 偏移量, 起点偏移, 桥架, 曲线, 水电, 水管, 线, 线槽, 线管, 直径, 直线
- Description: TODO (hand-edit)

### MEP_FittingOffsetSlope
- Path: existingCodes\品成插件源代码\机电\MEP_FittingOffsetSlope\MEP_FittingOffsetSlope
- Author: 品成插件源代码
- Actions: "机电管线避让"
- Dialogs: "a"
- Categories: OST_CableTray, OST_DuctCurves, OST_PipeCurves, OST_Conduit
- Parameters: RBS_START_LEVEL_PARAM, ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, duct, height, level, line, mep, meter, offset, offset pipe, partition, pipe, pipe size, slope, start offset, width, 避让, 标高, 分区, 风管, 高度, 管道, 管道偏移, 管径, 管线, 机电, 宽度, 米, 偏移, 偏移量, 坡度, 起点偏移, 桥架, 曲线, 水电, 水管, 线, 线槽, 线管, 直径, 直线
- Description: TODO (hand-edit)

### MEP_MEPCurvePlaceExchange
- Path: existingCodes\品成插件源代码\机电\MEP_MEPCurvePlaceExchange\MEP_MEPCurvePlaceExchange
- Author: 品成插件源代码
- Actions: "交换位置"
- Dialogs: "警告"
- Categories: OST_CableTray, OST_DuctCurves, OST_PipeCurves, OST_Conduit
- APIs: Pick (Selection)
- Tags: arrange, cable tray, change, conduit, curve, duct, layout, mep, modify, pipe, place, update, warning, 布局, 布置, 调整, 风管, 更改, 更新, 管道, 管线, 机电, 警告, 排布, 排列, 桥架, 曲线, 水电, 水管, 线槽, 线管, 修改
- Description: TODO (hand-edit)

### MEP_MEPNETH
- Path: existingCodes\品成插件源代码\机电\MEP_MEPNETH\MEP_MEPNETH
- Author: 品成插件源代码
- Actions: "标记管线净高"
- Dialogs: "a", "提示", "净高分析", "报错原因"
- Categories: OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks, OST_DuctCurves
- Parameters: RBS_START_OFFSET_PARAM, RBS_END_OFFSET_PARAM
- APIs: FilteredElementCollector, Pick (Selection), RayCast / ReferenceIntersector
- UI: WinForms
- Tags: cable tray, ceiling, curve, duct, error, floor, foundation, line, link, linked model, mark, mep, message, offset, pipe, prompt, slab, start offset, tag, taskdialog, 板, 报错, 标记, 标签, 错误, 打标, 弹窗, 地板, 吊顶, 风管, 管道, 管线, 机电, 基础, 链接, 链接模型, 楼板, 偏移, 偏移量, 起点偏移, 桥架, 曲线, 水电, 水管, 提示, 天花板, 线, 线槽, 消息, 消息框, 直线
- Description: TODO (hand-edit)

### MEP_Offset
- Path: existingCodes\品成插件源代码\机电\MEP_Offset\MEP_Offset
- Author: 品成插件源代码
- Actions: "机电管线避让"
- Dialogs: "警告"
- Parameters: RBS_START_LEVEL_PARAM, ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, height, level, line, mep, meter, offset, offset pipe, partition, pipe, pipe size, start offset, warning, width, 避让, 标高, 分区, 高度, 管道, 管道偏移, 管径, 管线, 机电, 警告, 宽度, 米, 偏移, 偏移量, 起点偏移, 桥架, 曲线, 水电, 水管, 线, 线槽, 线管, 直径, 直线
- Description: TODO (hand-edit)

### MEP_OffsetCanceller
- Path: existingCodes\品成插件源代码\机电\MEP_OffsetCanceller\MEP_OffsetCanceller
- Author: 品成插件源代码
- Actions: "取消翻弯", "取消水平三通翻弯", "取消垂直三通翻弯", "取消四通翻弯"
- Dialogs: "a", "提示"
- Parameters: RBS_START_LEVEL_PARAM, RBS_OFFSET_PARAM, ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM
- APIs: Pick (Selection), ElementTransformUtils
- Tags: cable tray, conduit, curve, diameter, elbow, height, level, mep, message, meter, offset, partition, pipe, pipe fitting, pipe size, prompt, start offset, taskdialog, tee, width, 标高, 弹窗, 分区, 高度, 管道, 管件, 管径, 管线, 机电, 宽度, 米, 偏移, 偏移量, 起点偏移, 桥架, 曲线, 三通, 水电, 水管, 提示, 弯头, 线槽, 线管, 消息, 消息框, 直径
- Description: TODO (hand-edit)

### MEP_OffsetOverturner
- Path: existingCodes\品成插件源代码\机电\MEP_OffsetOverturner\MEP_OffsetOverturner
- Author: 品成插件源代码
- Actions: "翻转翻弯", "翻转水平三通翻弯", "取消水平三通翻弯", "翻转四通翻弯"
- Dialogs: "提示", "a"
- Parameters: ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM, RBS_CURVE_DIAMETER_PARAM
- APIs: Pick (Selection), ElementTransformUtils
- Tags: cable tray, conduit, curve, diameter, elbow, height, mep, message, meter, offset, partition, pipe, pipe fitting, pipe size, prompt, taskdialog, tee, width, 弹窗, 分区, 高度, 管道, 管件, 管径, 管线, 机电, 宽度, 米, 偏移, 偏移量, 桥架, 曲线, 三通, 水电, 水管, 提示, 弯头, 线槽, 线管, 消息, 消息框, 直径
- Description: TODO (hand-edit)

### MEP_OffsetPro
- Path: existingCodes\品成插件源代码\机电\MEP_OffsetPro\MEP_OffsetPro
- Author: 品成插件源代码
- Actions: "单侧喷淋支管升降", "双侧喷淋支管升降"
- Dialogs: "a", "提示："
- Parameters: RBS_START_LEVEL_PARAM, RBS_PIPE_DIAMETER_PARAM, ELEM_PARTITION_PARAM
- APIs: Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: diameter, level, mep, message, meter, offset, partition, pipe, pipe size, prompt, sprinkler, start offset, taskdialog, 标高, 弹窗, 分区, 管道, 管径, 管线, 机电, 米, 喷淋, 喷头, 偏移, 偏移量, 起点偏移, 水电, 水管, 提示, 消息, 消息框, 直径
- Description: TODO (hand-edit)

### MEP_OffsetProBefore
- Path: existingCodes\品成插件源代码\机电\MEP_OffsetProBefore\MEP_OffsetProBefore
- Author: 品成插件源代码
- Actions: "喷淋升降分支"
- Parameters: RBS_START_LEVEL_PARAM, RBS_PIPE_DIAMETER_PARAM, ELEM_PARTITION_PARAM
- APIs: Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: diameter, level, mep, meter, offset, partition, pipe, pipe size, sprinkler, start offset, 标高, 分区, 管道, 管径, 管线, 机电, 米, 喷淋, 喷头, 偏移, 偏移量, 起点偏移, 水电, 水管, 直径
- Description: TODO (hand-edit)

### MEP_ParallelIn3D
- Path: existingCodes\品成插件源代码\机电\MEP_ParallelIn3D\MEP_ParallelIn3D
- Author: 品成插件源代码
- Actions: "使平行"
- Dialogs: "提示"
- Parameters: CURVE_ELEM_LENGTH
- APIs: Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: curve, length, mep, message, prompt, taskdialog, 弹窗, 机电, 曲线, 水电, 提示, 消息, 消息框, 长度
- Description: TODO (hand-edit)

### MEP_ParallelIn3DBasisOfLink
- Path: existingCodes\品成插件源代码\机电\MEP_ParallelIn3DBasisOfLink\MEP_ParallelIn3DBasisOfLink
- Author: 品成插件源代码
- Actions: "使平行"
- Dialogs: "警告", "提示"
- Categories: OST_Walls
- Parameters: CURVE_ELEM_LENGTH
- APIs: Pick (Selection)
- UI: WinForms
- Tags: curve, length, link, linked model, mep, message, prompt, taskdialog, wall, warning, 弹窗, 机电, 警告, 链接, 链接模型, 墙, 墙体, 曲线, 水电, 提示, 消息, 消息框, 长度
- Description: TODO (hand-edit)

### MEP_Replaycer
- Path: existingCodes\品成插件源代码\机电\MEP_Replaycer\MEP_Replaycer
- Author: 品成插件源代码
- Actions: "标高刷", "系统刷", "管径刷"
- Dialogs: "提示："
- Parameters: RBS_PIPING_SYSTEM_TYPE_PARAM, RBS_DUCT_SYSTEM_TYPE_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: Pick (Selection)
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, duct, elevation, height, level, mep, message, meter, partition, pipe, pipe size, prompt, system, system type, taskdialog, type, width, 标高, 弹窗, 分区, 风管, 高程, 高度, 管道, 管径, 管线, 机电, 宽度, 类型, 米, 桥架, 曲线, 水电, 水管, 提示, 系统, 系统类型, 线槽, 线管, 消息, 消息框, 直径
- Description: TODO (hand-edit)

### MEP_SectionBox
- Path: existingCodes\品成插件源代码\通用\MEP_SectionBox\MEP_SectionBox
- Author: 品成插件源代码
- Actions: "SetSectionBox"
- Parameters: ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM, RBS_CABLETRAY_WIDTH_PARAM
- APIs: FilteredElementCollector
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, height, mep, meter, partition, pipe, pipe size, width, 分区, 高度, 管道, 管径, 管线, 机电, 宽度, 米, 桥架, 曲线, 水电, 水管, 线槽, 线管, 直径
- Description: TODO (hand-edit)

### MEP_SmartMove
- Path: existingCodes\品成插件源代码\机电\MEP_SmartMove\MEP_SmartMove
- Author: 品成插件源代码
- Actions: "createModelCurve", "deleteModelCurve", "SmartMove"
- Parameters: RBS_START_LEVEL_PARAM, ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: cable tray, conduit, create, curve, delete, diameter, generate, height, level, mep, meter, model, move, new, partition, pipe, pipe size, remove, start offset, width, 标高, 创建, 分区, 高度, 管道, 管径, 管线, 机电, 建立, 宽度, 米, 模型, 起点偏移, 桥架, 曲线, 删除, 生成, 水电, 水管, 线槽, 线管, 新建, 新增, 移除, 移动, 直径
- Description: TODO (hand-edit)

### MEP_SmartOffset
- Path: existingCodes\品成插件源代码\机电\MEP_SmartOffset\MEP_SmartOffset
- Author: 品成插件源代码
- Actions: "机电管线避让"
- Dialogs: "提示：", "a"
- Parameters: RBS_START_LEVEL_PARAM, ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, height, level, line, mep, message, meter, offset, offset pipe, partition, pipe, pipe size, prompt, start offset, taskdialog, width, 避让, 标高, 弹窗, 分区, 高度, 管道, 管道偏移, 管径, 管线, 机电, 宽度, 米, 偏移, 偏移量, 起点偏移, 桥架, 曲线, 水电, 水管, 提示, 线, 线槽, 线管, 消息, 消息框, 直径, 直线
- Description: TODO (hand-edit)

### MEP_TagHelperForSlope
- Path: existingCodes\品成插件源代码\机电\MEP_TagHelperForSlope\MEP_TagHelperForSlope
- Author: 品成插件源代码
- Actions: "TAGHELPER", "设置字体大小"
- Dialogs: "Revit", "re", "提示", "a", "Error"
- Categories: OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks, OST_DuctCurves
- Parameters: RBS_PIPE_OUTER_DIAMETER, ELEM_FAMILY_PARAM, RBS_CURVE_DIAMETER_PARAM, TEXT_SIZE
- APIs: FilteredElementCollector, Pick (Selection), Element creation, RayCast / ReferenceIntersector
- Tags: cable tray, ceiling, curve, diameter, duct, error, family, family name, floor, foundation, link, linked model, mep, message, meter, pipe, pipe size, prompt, slab, slope, tag, taskdialog, 板, 报错, 标记, 标签, 错误, 打标, 弹窗, 地板, 吊顶, 风管, 管道, 管径, 管线, 机电, 基础, 链接, 链接模型, 楼板, 米, 坡度, 桥架, 曲线, 水电, 水管, 提示, 天花板, 线槽, 消息, 消息框, 直径, 族, 族名称
- Description: TODO (hand-edit)

### MEP_TagHelperForSlopeHeight
- Path: existingCodes\品成插件源代码\机电\MEP_TagHelperForSlope\MEP_TagHelperForSlopeHeight
- Author: 品成插件源代码
- Actions: "TAGHELPER"
- Dialogs: "Revit", "提示", "a", "报错原因"
- Categories: OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks, OST_DuctCurves
- Parameters: RBS_PIPE_OUTER_DIAMETER, ELEM_FAMILY_PARAM, RBS_CURVE_DIAMETER_PARAM
- APIs: FilteredElementCollector, Pick (Selection), Element creation, RayCast / ReferenceIntersector
- Tags: cable tray, ceiling, curve, diameter, duct, error, family, family name, floor, foundation, height, link, linked model, mep, message, meter, pipe, pipe size, prompt, slab, slope, tag, taskdialog, 板, 报错, 标记, 标签, 错误, 打标, 弹窗, 地板, 吊顶, 风管, 高度, 管道, 管径, 管线, 机电, 基础, 链接, 链接模型, 楼板, 米, 坡度, 桥架, 曲线, 水电, 水管, 提示, 天花板, 线槽, 消息, 消息框, 直径, 族, 族名称
- Description: TODO (hand-edit)

### MEP_TagHelperForSlopForSection
- Path: existingCodes\品成插件源代码\机电\MEP_TagHelperForSlopForSection\MEP_TagHelperForSlopForSection
- Author: 品成插件源代码
- Actions: "TAGHELPER"
- Dialogs: "Revit", "a", "提示", "报错原因"
- Categories: OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks, OST_DuctCurves
- Parameters: ELEM_FAMILY_PARAM, RBS_PIPE_OUTER_DIAMETER, RBS_CABLETRAY_HEIGHT_PARAM, RBS_CURVE_DIAMETER_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: FilteredElementCollector, Pick (Selection), Element creation, RayCast / ReferenceIntersector
- Tags: cable tray, ceiling, curve, diameter, duct, error, family, family name, floor, foundation, height, insulation, insulation thickness, link, linked model, mep, message, meter, pipe, pipe size, prompt, slab, tag, taskdialog, thickness, 板, 保温, 保温厚度, 报错, 标记, 标签, 错误, 打标, 弹窗, 地板, 吊顶, 风管, 高度, 隔热, 管道, 管径, 管线, 厚度, 机电, 基础, 绝缘, 链接, 链接模型, 楼板, 米, 桥架, 曲线, 水电, 水管, 提示, 天花板, 线槽, 消息, 消息框, 直径, 族, 族名称
- Description: TODO (hand-edit)

### MEP_TeeRoatAndMoveAndConn
- Path: existingCodes\品成插件源代码\机电\MEP_TeeRoatAndMoveAndConn\MEP_TeeRoatAndMoveAndConn
- Author: 品成插件源代码
- Actions: "旋转三通"
- Dialogs: "a", "提示", "提示："
- Parameters: RBS_START_LEVEL_PARAM, RBS_PIPE_DIAMETER_PARAM, ELEM_PARTITION_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, elbow, height, level, mep, message, meter, move, partition, pipe, pipe fitting, pipe size, prompt, rotate, start offset, taskdialog, tee, width, 标高, 弹窗, 分区, 高度, 管道, 管件, 管径, 管线, 机电, 宽度, 米, 起点偏移, 桥架, 曲线, 三通, 水电, 水管, 提示, 弯头, 线槽, 线管, 消息, 消息框, 旋转, 移动, 直径
- Description: TODO (hand-edit)

### MEP_TeeRotater
- Path: existingCodes\品成插件源代码\机电\MEP_TeeRotater\MEP_TeeRotater
- Author: 品成插件源代码
- Actions: "旋转三通"
- Parameters: RBS_START_LEVEL_PARAM, RBS_PIPE_DIAMETER_PARAM, ELEM_PARTITION_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, elbow, height, level, mep, meter, partition, pipe, pipe fitting, pipe size, rotate, start offset, tee, width, 标高, 分区, 高度, 管道, 管件, 管径, 管线, 机电, 宽度, 米, 起点偏移, 桥架, 曲线, 三通, 水电, 水管, 弯头, 线槽, 线管, 旋转, 直径
- Description: TODO (hand-edit)

### MEP_TeeRotaterAndConn
- Path: existingCodes\品成插件源代码\机电\MEP_TeeRotaterAndConn\MEP_TeeRotaterAndConn
- Author: 品成插件源代码
- Actions: "旋转三通"
- Dialogs: "a", "提示", "提示："
- Parameters: RBS_START_LEVEL_PARAM, RBS_PIPE_DIAMETER_PARAM, ELEM_PARTITION_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, elbow, height, level, mep, message, meter, partition, pipe, pipe fitting, pipe size, prompt, rotate, start offset, taskdialog, tee, width, 标高, 弹窗, 分区, 高度, 管道, 管件, 管径, 管线, 机电, 宽度, 米, 起点偏移, 桥架, 曲线, 三通, 水电, 水管, 提示, 弯头, 线槽, 线管, 消息, 消息框, 旋转, 直径
- Description: TODO (hand-edit)

### MEP_VerticalIn3D
- Path: existingCodes\品成插件源代码\机电\MEP_VerticalIn3D\MEP_VerticalIn3D
- Author: 品成插件源代码
- Actions: "使垂直"
- Dialogs: "提示", "a"
- Parameters: CURVE_ELEM_LENGTH
- APIs: Pick (Selection)
- UI: WinForms
- Tags: curve, length, mep, message, prompt, taskdialog, 弹窗, 机电, 曲线, 水电, 提示, 消息, 消息框, 长度
- Description: TODO (hand-edit)

### MEP_VerticalPipe
- Path: existingCodes\品成插件源代码\机电\MEP_VerticalPipe\MEP_VerticalPipe
- Author: 品成插件源代码
- Actions: "BimtransMEPTools.VerticalPipe"
- Categories: OST_PipingSystem
- Parameters: RBS_PIPE_DIAMETER_PARAM
- APIs: FilteredElementCollector, Pick (Selection)
- UI: WinForms
- Tags: diameter, mep, meter, pipe, pipe size, system, 管道, 管径, 管线, 机电, 米, 水电, 水管, 系统, 直径
- Description: TODO (hand-edit)

### MEPQuantities
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\MEPQuantities\MEPQuantities
- Author: 梁涛插件源代码
- Actions: "取消临时隐藏", "显示路由构件", "Zoom", "修改类型名称"
- Dialogs: "Error", "or", "re"
- Categories: OST_CableTray, OST_CableTrayFitting, OST_Conduit, OST_ConduitFitting, OST_FlexPipeCurves
- Parameters: ELEM_TYPE_PARAM, RBS_CONDUIT_DIAMETER_PARAM, CURVE_ELEM_LENGTH, RBS_DUCT_SYSTEM_TYPE_PARAM, RBS_PIPING_SYSTEM_TYPE_PARAM
- APIs: FilteredElementCollector, Pick (Selection), Ribbon (IExternalApplication), Modeless (ExternalEvent)
- UI: WinForms
- Integrations: Excel interop
- Tags: cable tray, change, conduit, curve, diameter, duct, elbow, element, error, family, family name, height, hide, length, mep, meter, millimeter, mm, modify, partition, pipe, pipe fitting, pipe size, plumbing, show, sprinkler, system, system type, type, type name, unhide, update, width, 报错, 错误, 调整, 分区, 风管, 高度, 给排水, 更改, 更新, 构件, 管道, 管件, 管径, 管线, 毫米, 机电, 宽度, 类型, 类型名称, 米, 喷淋, 喷头, 桥架, 曲线, 取消隐藏, 三通, 水电, 水管, 图元, 弯头, 系统, 系统类型, 显示, 线槽, 线管, 修改, 隐藏, 元素, 长度, 直径, 族, 族名称
- Description: TODO (hand-edit)

### MEPQuantities
- Path: existingCodes\其他插件源代码\MEPQuantities\MEPQuantities
- Author: 其他插件源代码
- Actions: "取消临时隐藏", "显示路由构件", "Zoom", "修改类型名称"
- Dialogs: "Error", "or", "re"
- Categories: OST_CableTray, OST_CableTrayFitting, OST_Conduit, OST_ConduitFitting, OST_FlexPipeCurves
- Parameters: ELEM_TYPE_PARAM, RBS_CONDUIT_DIAMETER_PARAM, CURVE_ELEM_LENGTH, RBS_DUCT_SYSTEM_TYPE_PARAM, RBS_PIPING_SYSTEM_TYPE_PARAM
- APIs: FilteredElementCollector, Pick (Selection), Ribbon (IExternalApplication), Modeless (ExternalEvent)
- UI: WinForms
- Integrations: Excel interop
- Tags: cable tray, change, conduit, curve, diameter, duct, elbow, element, error, family, family name, height, hide, length, mep, meter, millimeter, mm, modify, partition, pipe, pipe fitting, pipe size, plumbing, show, sprinkler, system, system type, type, type name, unhide, update, width, 报错, 错误, 调整, 分区, 风管, 高度, 给排水, 更改, 更新, 构件, 管道, 管件, 管径, 管线, 毫米, 机电, 宽度, 类型, 类型名称, 米, 喷淋, 喷头, 桥架, 曲线, 取消隐藏, 三通, 水电, 水管, 图元, 弯头, 系统, 系统类型, 显示, 线槽, 线管, 修改, 隐藏, 元素, 长度, 直径, 族, 族名称
- Description: TODO (hand-edit)

### MoveLR
- Path: existingCodes\品成插件源代码\机电\MoveLR\MoveLR
- Author: 品成插件源代码
- Actions: "水平移动"
- Dialogs: "警告", "a"
- Categories: OST_CableTray, OST_DuctCurves, OST_PipeCurves, OST_Conduit
- Parameters: RBS_CABLETRAY_WIDTH_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_PIPE_OUTER_DIAMETER, RBS_CONDUIT_OUTER_DIAM_PARAM
- APIs: Pick (Selection), Ribbon (IExternalApplication)
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, duct, meter, move, pipe, pipe size, warning, width, 风管, 管道, 管径, 管线, 警告, 宽度, 米, 桥架, 曲线, 水管, 线槽, 线管, 移动, 直径
- Description: TODO (hand-edit)

### MoveLR_Smart
- Path: existingCodes\品成插件源代码\机电\MoveLR_Smart\MoveLR_Smart
- Author: 品成插件源代码
- Actions: "水平移动"
- Categories: OST_CableTray, OST_DuctCurves, OST_PipeCurves, OST_Conduit
- APIs: Pick (Selection)
- UI: WinForms
- Tags: cable tray, conduit, curve, duct, move, pipe, 风管, 管道, 管线, 桥架, 曲线, 水管, 线槽, 线管, 移动
- Description: TODO (hand-edit)

### MoveLRBasisOfLink
- Path: existingCodes\品成插件源代码\机电\MoveLRBasisOfLink\MoveLRBasisOfLink
- Author: 品成插件源代码
- Actions: "水平移动"
- Dialogs: "警告"
- Categories: OST_Walls, OST_CableTray, OST_DuctCurves, OST_PipeCurves, OST_Conduit
- Parameters: WALL_ATTR_WIDTH_PARAM
- APIs: Pick (Selection), Ribbon (IExternalApplication)
- UI: WinForms
- Tags: cable tray, conduit, curve, duct, link, linked model, move, pipe, wall, warning, width, 风管, 管道, 管线, 警告, 宽度, 链接, 链接模型, 墙, 墙体, 桥架, 曲线, 水管, 线槽, 线管, 移动
- Description: TODO (hand-edit)

### MoveLRMiddle
- Path: existingCodes\品成插件源代码\机电\MoveLRMiddle\MoveLRMiddle
- Author: 品成插件源代码
- Actions: "水平移动"
- Dialogs: "警告", "a", "提示"
- Categories: OST_CableTray, OST_DuctCurves, OST_PipeCurves, OST_Conduit
- Parameters: MATERIAL_ID_PARAM
- APIs: FilteredElementCollector, Pick (Selection)
- UI: WinForms
- Tags: cable tray, conduit, curve, duct, material, message, move, pipe, prompt, taskdialog, warning, 材料, 材质, 弹窗, 风管, 管道, 管线, 警告, 桥架, 曲线, 水管, 提示, 线槽, 线管, 消息, 消息框, 移动
- Description: TODO (hand-edit)

### MoveLRMiddleBasisOfLink
- Path: existingCodes\品成插件源代码\机电\MoveLRMiddleBasisOfLink\MoveLRMiddleBasisOfLink
- Author: 品成插件源代码
- Actions: "水平移动"
- Dialogs: "警告"
- Categories: OST_Walls, OST_CableTray, OST_DuctCurves, OST_PipeCurves, OST_Conduit
- Parameters: WALL_ATTR_WIDTH_PARAM
- APIs: Pick (Selection)
- UI: WinForms
- Tags: cable tray, conduit, curve, duct, link, linked model, move, pipe, wall, warning, width, 风管, 管道, 管线, 警告, 宽度, 链接, 链接模型, 墙, 墙体, 桥架, 曲线, 水管, 线槽, 线管, 移动
- Description: TODO (hand-edit)

### MoveParkingNumber
- Path: existingCodes\梁涛插件源代码\2.机电建模及算量\MoveParkingNumber\MoveParkingNumber
- Author: 梁涛插件源代码
- Actions: "调整车位号"
- Dialogs: "提示", "revit"
- Categories: OST_RvtLinks, OST_CableTray, OST_StructuralColumns
- Parameters: ELEM_TYPE_PARAM
- APIs: FilteredElementCollector, ElementTransformUtils, RayCast / ReferenceIntersector
- Tags: cable tray, change, column, link, linked model, message, modify, move, prompt, taskdialog, type, update, 弹窗, 调整, 更改, 更新, 类型, 链接, 链接模型, 桥架, 提示, 线槽, 消息, 消息框, 修改, 移动, 柱, 柱子
- Description: TODO (hand-edit)

### MoveUD
- Path: existingCodes\品成插件源代码\机电\MoveUD\MoveUD
- Author: 品成插件源代码
- Actions: "垂直移动"
- Dialogs: "警告", "a"
- Categories: OST_CableTray, OST_DuctCurves, OST_PipeCurves, OST_Conduit
- APIs: Pick (Selection), Ribbon (IExternalApplication)
- UI: WinForms
- Tags: cable tray, conduit, curve, duct, move, pipe, warning, 风管, 管道, 管线, 警告, 桥架, 曲线, 水管, 线槽, 线管, 移动
- Description: TODO (hand-edit)

### MoveUDBasisOfLink
- Path: existingCodes\品成插件源代码\机电\MoveUDBasisOfLink\MoveUDBasisOfLink
- Author: 品成插件源代码
- Actions: "垂直移动"
- Dialogs: "警告", "提示", "i", "list"
- Categories: OST_StructuralFraming, OST_CableTray, OST_DuctCurves, OST_PipeCurves, OST_Conduit
- Parameters: RBS_START_LEVEL_PARAM
- APIs: FilteredElementCollector, Pick (Selection), Ribbon (IExternalApplication)
- UI: WinForms
- Tags: cable tray, conduit, curve, duct, level, link, linked model, message, move, pipe, prompt, start offset, taskdialog, warning, 标高, 弹窗, 风管, 管道, 管线, 警告, 链接, 链接模型, 起点偏移, 桥架, 曲线, 水管, 提示, 线槽, 线管, 消息, 消息框, 移动
- Description: TODO (hand-edit)

### NetHeightAnalysis
- Path: existingCodes\梁涛插件源代码\2.机电建模及算量\NetHeightAnalysis\NetHeightAnalysis
- Author: 梁涛插件源代码
- Actions: "填充色块颜色", "创建标注", "楼板色块", "区域填充"
- Dialogs: "revit", "提示"
- Categories: OST_DetailComponents, OST_PipeCurves, OST_PipeAccessory, OST_PipeFitting, OST_PipeInsulations
- APIs: FilteredElementCollector, Pick (Selection), Modeless (ExternalEvent)
- Tags: cable tray, create, curve, dimension, duct, elbow, floor, generate, height, insulation, message, model, new, pipe, pipe fitting, prompt, slab, sprinkler, stair, taskdialog, 板, 保温, 标注, 尺寸标注, 创建, 弹窗, 地板, 风管, 高度, 隔热, 管道, 管件, 管线, 建立, 绝缘, 楼板, 楼梯, 模型, 喷淋, 喷头, 桥架, 曲线, 三通, 生成, 水管, 提示, 弯头, 线槽, 消息, 消息框, 新建, 新增
- Description: TODO (hand-edit)

### NewHangerUpdate
- Path: existingCodes\梁涛插件源代码\4.吊架布置\NewHangerUpdate\NewHangerUpdate
- Author: 梁涛插件源代码
- Actions: "Move", "三维视图详细程度设置", "吊架顶端对齐顶板", "调整吊架位置"
- Dialogs: "revit", "提示", "Revit"
- Categories: OST_MechanicalEquipment, OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks
- Parameters: VIEW_DETAIL_LEVEL, RBS_PIPE_DIAMETER_PARAM, RBS_PIPE_OUTER_DIAMETER
- APIs: FilteredElementCollector, Pick (Selection), TransactionGroup
- UI: WinForms
- Tags: 3d view, 3d视图, align, cable tray, ceiling, change, create, curve, degree, diameter, duct, floor, foundation, generate, hanger, level, link, linked model, message, meter, modify, move, new, pipe, pipe size, prompt, slab, support, taskdialog, update, view, 板, 标高, 创建, 弹窗, 地板, 吊顶, 吊架, 调整, 度, 对齐, 风管, 更改, 更新, 管道, 管径, 管线, 基础, 建立, 角度, 链接, 链接模型, 楼板, 米, 桥架, 曲线, 三维视图, 生成, 视图, 水管, 提示, 天花板, 线槽, 消息, 消息框, 新建, 新增, 修改, 移动, 支吊架, 直径
- Description: TODO (hand-edit)

### NewMepOffset
- Path: existingCodes\梁涛插件源代码\3.管综\NewMepOffset\NewMepOffset
- Author: 梁涛插件源代码
- Actions: "Create", "管线避让"
- Dialogs: "Revit", "Error", "revit"
- APIs: Pick (Selection), ElementTransformUtils
- UI: WinForms
- Tags: create, error, generate, line, mep, new, offset, offset pipe, pipe, 报错, 避让, 创建, 错误, 管道, 管道偏移, 管线, 机电, 建立, 偏移, 偏移量, 生成, 水电, 水管, 线, 新建, 新增, 直线
- Description: TODO (hand-edit)

### NewTextNoteForSlope
- Path: existingCodes\梁涛插件源代码\5.吊架出图\NewTextNoteForSlope\NewTextNoteForSlope
- Author: 梁涛插件源代码
- Actions: "ds", "设置视图详细程度", "平面标注", "移动旋转注释", "可见性设置"
- Dialogs: "Revit", "提示", "revit", "Error", "re"
- Categories: OST_Floors, OST_Ceilings, OST_StructuralFoundation, OST_RvtLinks, OST_DuctCurves
- Parameters: VIEW_DETAIL_LEVEL, RBS_OFFSET_PARAM, RBS_PIPE_BOTTOM_ELEVATION, RBS_DUCT_PIPE_SYSTEM_ABBREVIATION_PARAM, RBS_PIPE_DIAMETER_PARAM
- APIs: FilteredElementCollector, Pick (Selection), Element creation, TransactionGroup, RayCast / ReferenceIntersector
- Tags: annotate, cable tray, ceiling, comments, create, curve, degree, diameter, dimension, duct, elevation, error, family, family name, floor, foundation, generate, height, level, link, linked model, message, meter, move, new, note, offset, pipe, pipe size, prompt, rotate, slab, slope, system, taskdialog, type, view, width, 板, 报错, 备注, 标高, 标注, 尺寸标注, 创建, 错误, 弹窗, 地板, 吊顶, 度, 风管, 高程, 高度, 管道, 管径, 管线, 基础, 建立, 角度, 宽度, 类型, 链接, 链接模型, 楼板, 米, 偏移, 偏移量, 坡度, 桥架, 曲线, 生成, 视图, 水管, 提示, 天花板, 文字注释, 系统, 线槽, 消息, 消息框, 新建, 新增, 旋转, 移动, 直径, 注释, 族, 族名称
- Description: TODO (hand-edit)

### OffsetPipeByElevationText
- Path: existingCodes\品成插件源代码\土建\OffsetPipeByElevationText\OffsetPipeByElevationText
- Author: 品成插件源代码
- Actions: "SlopePipe"
- Parameters: RBS_PIPE_DIAMETER_PARAM, ELEM_PARTITION_PARAM
- APIs: FilteredElementCollector, Pick (Selection)
- Tags: diameter, elevation, meter, offset, partition, pipe, pipe size, slope, 标高, 分区, 高程, 管道, 管径, 管线, 米, 偏移, 偏移量, 坡度, 水管, 直径
- Description: TODO (hand-edit)

### OptimalCablePathByNode
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\OptimalCablePathByNode\OptimalCablePathByNode
- Author: 梁涛插件源代码
- Actions: "激活族类型", "创建拓扑节点", "两连接管件相连", "节点参数填写", "创建拓扑线"
- Dialogs: "错误", "Error", "DateTime总共花费", "revit", "findPath"
- Categories: OST_ElectricalEquipment, OST_Conduit, OST_GenericModel, OST_CableTrayFitting, OST_CableTray
- Parameters: ALL_MODEL_INSTANCE_COMMENTS, RBS_CONDUIT_DIAMETER_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, Ribbon (IExternalApplication), Modeless (ExternalEvent), TransactionGroup, RayCast / ReferenceIntersector, Shared parameters
- UI: WinForms
- Integrations: Excel interop, HTTP
- Tags: assign, break, cable tray, comments, conduit, connect, copy, create, delete, diameter, elbow, element, error, family, family symbol, family type, foundation, generate, hide, isolate, join, line, message, meter, millimeter, mm, model, new, parameter, pipe, pipe fitting, pipe size, point, project, project parameter, prompt, remove, rename, set value, shared parameter, split, taskdialog, type, 报错, 备注, 参数, 拆分, 创建, 错误, 打断, 弹窗, 点, 分割, 复制, 赋值, 隔离, 共享参数, 构件, 管道, 管件, 管径, 管线, 毫米, 合并, 基础, 建立, 类型, 连接, 米, 模型, 桥架, 三通, 删除, 设置值, 生成, 水管, 提示, 图元, 弯头, 线, 线槽, 线管, 项目, 项目参数, 消息, 消息框, 写入, 新建, 新增, 移除, 隐藏, 元素, 直径, 直线, 重命名, 注释, 族, 族符号, 族类型
- Description: TODO (hand-edit)

### ParameterizedMEPCurveLayout
- Path: existingCodes\饶昌锋插件源代码\264参数化管线排布\ParameterizedMEPCurveLayout
- Author: 饶昌锋插件源代码
- Actions: "调整高度间距及下对齐", "打断管线", "管线换行", "管线排序", "Hide and Show Elements"
- Dialogs: "Ada", "sda", "asda", "asd", "Asda"
- Categories: OST_StructuralColumns, OST_Floors, OST_StructuralFraming, OST_DuctCurves, OST_PipeCurves
- Parameters: RBS_CABLETRAY_WIDTH_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_PIPE_OUTER_DIAMETER, RBS_PIPING_SYSTEM_TYPE_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Modeless (ExternalEvent), RayCast / ReferenceIntersector
- Integrations: Excel interop
- Tags: align, arrange, break, cable tray, change, column, connect, create, curve, degree, diameter, duct, element, floor, generate, height, hide, join, layout, line, mep, message, meter, modify, new, parameter, pipe, pipe size, place, prompt, section view, shared parameter, show, slab, split, system, system type, taskdialog, type, unhide, update, width, 板, 布局, 布置, 参数, 拆分, 创建, 打断, 弹窗, 地板, 调整, 度, 对齐, 分割, 风管, 高度, 更改, 更新, 共享参数, 构件, 管道, 管径, 管线, 合并, 机电, 建立, 角度, 宽度, 类型, 连接, 楼板, 米, 排布, 排列, 剖面, 剖面视图, 桥架, 曲线, 取消隐藏, 生成, 水电, 水管, 提示, 图元, 系统, 系统类型, 显示, 线, 线槽, 消息, 消息框, 新建, 新增, 修改, 隐藏, 元素, 直径, 直线, 柱, 柱子
- Description: TODO (hand-edit)

### PipeFittingParameterInputHanger
- Path: existingCodes\梁涛插件源代码\5.吊架出图\PipeFittingParameterInputHanger\PipeFittingParameterInputHanger
- Author: 梁涛插件源代码
- Actions: "创建文字注释类型", "创建吊架文字注释"
- Dialogs: "ll", "提示"
- Categories: OST_DuctCurves, OST_PipeCurves, OST_CableTray
- Parameters: RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CABLETRAY_WIDTH_PARAM, LEADER_OFFSET_SHEET
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, TransactionGroup
- Tags: annotate, cable tray, comments, create, curve, diameter, duct, elbow, generate, hanger, height, message, meter, new, note, offset, parameter, pipe, pipe fitting, pipe size, prompt, shared parameter, sheet, support, taskdialog, type, width, 备注, 参数, 创建, 弹窗, 吊架, 风管, 高度, 共享参数, 管道, 管件, 管径, 管线, 建立, 宽度, 类型, 米, 偏移, 偏移量, 桥架, 曲线, 三通, 生成, 水管, 提示, 图纸, 弯头, 文字注释, 线槽, 消息, 消息框, 新建, 新增, 支吊架, 直径, 注释
- Description: TODO (hand-edit)

### PipelineAlignment
- Path: existingCodes\梁涛插件源代码\3.管综\PipelineAlignment\PipelineAlignment
- Author: 梁涛插件源代码
- Actions: "对齐", "中间高程取整", "横管对齐"
- Dialogs: "revit"
- Parameters: RBS_DUCT_TOP_ELEVATION, RBS_PIPE_TOP_ELEVATION, RBS_CTC_TOP_ELEVATION, RBS_REFERENCE_INSULATION_THICKNESS, RBS_OFFSET_PARAM
- APIs: Pick (Selection), Modeless (ExternalEvent), TransactionGroup
- Tags: align, duct, elevation, insulation, insulation thickness, line, offset, pipe, thickness, 保温, 保温厚度, 标高, 对齐, 风管, 高程, 隔热, 管道, 管线, 厚度, 绝缘, 偏移, 偏移量, 水管, 线, 直线
- Description: TODO (hand-edit)

### PipelineIntervalSort
- Path: existingCodes\梁涛插件源代码\3.管综\PipelineIntervalSort\PipelineIntervalSort
- Author: 梁涛插件源代码
- Actions: "管线等间距排列"
- Dialogs: "re"
- Parameters: RBS_PIPE_OUTER_DIAMETER
- APIs: Pick (Selection)
- Tags: arrange, diameter, layout, line, meter, pipe, pipe size, place, 布局, 布置, 管道, 管径, 管线, 米, 排布, 排列, 水管, 线, 直径, 直线
- Description: TODO (hand-edit)

### PipelineOffset
- Path: existingCodes\梁涛插件源代码\3.管综\PipelineOffset（管道偏移）\PipelineOffset
- Author: 梁涛插件源代码
- Actions: "打断管道", "判断正确旋转方向", "旋转管道", "创建连接件"
- Dialogs: "22", "错误", "lll"
- APIs: Pick (Selection), ElementTransformUtils, TransactionGroup
- Tags: break, connect, connector, create, error, generate, join, line, new, offset, pipe, rotate, split, 报错, 拆分, 创建, 错误, 打断, 分割, 管道, 管线, 合并, 建立, 接口, 连接, 连接件, 偏移, 偏移量, 生成, 水管, 线, 新建, 新增, 旋转, 直线
- Description: TODO (hand-edit)

### PositioningMarkingOfCShapedSteelHanger
- Path: existingCodes\梁涛插件源代码\5.吊架出图\PositioningMarkingOfCShapedSteelHanger\PositioningMarkingOfCShapedSteelHanger
- Author: 梁涛插件源代码
- Actions: "C型钢吊架定位标注(文字注释)", "C型钢吊架定位标注(标记)", "品茗吊架定位标注(文字注释)"
- Dialogs: "Revit"
- Categories: OST_Views, OST_MechanicalEquipment, OST_MechanicalEquipmentTags
- Parameters: LEADER_OFFSET_SHEET
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils
- Tags: annotate, comments, dimension, hanger, mark, note, offset, sheet, support, tag, tee, view, 备注, 标记, 标签, 标注, 尺寸标注, 打标, 吊架, 偏移, 偏移量, 三通, 视图, 图纸, 文字注释, 支吊架, 注释
- Description: TODO (hand-edit)

### QuantityTools
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\QuantityTools\QuantityTools
- Author: 梁涛插件源代码
- Actions: "ss", "线管通路赋值", "修改线管通路直径", "贴墙", "接线盒 线管 高度修正"
- Dialogs: "revit", "re", "Revit", "提示", "ssss"
- Categories: OST_Conduit, OST_ConduitFitting, OST_ElectricalFixtures, OST_Walls, OST_StructuralColumns
- Parameters: RBS_CONDUIT_DIAMETER_PARAM, ELEM_PARTITION_PARAM, FLOOR_ATTR_THICKNESS_PARAM, RBS_CTC_BOTTOM_ELEVATION, RBS_START_LEVEL_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, Ribbon (IExternalApplication), Modeless (ExternalEvent), TransactionGroup, RayCast / ReferenceIntersector, Shared parameters
- UI: WinForms
- Integrations: Excel interop, HTTP
- Tags: adjust elevation, annotate, assign, audit, break, cable tray, casing, ceiling, change, check, column, comments, conduit, connect, copy, create, curve, degree, delete, diameter, drainage, elbow, element, elevation, error, family, family symbol, family type, floor, foundation, generate, height, hide, isolate, join, length, level, lighting fixture, line, link, linked model, mark, mechanical equipment, message, meter, millimeter, mm, model, modify, new, note, parameter, partition, pipe, pipe fitting, pipe size, point, project, project parameter, prompt, remove, rename, riser, room, rotate, sanitary, set value, shared parameter, show, slab, sleeve, split, start offset, system, system type, tag, taskdialog, tee, thickness, type, unhide, update, validate, vertical pipe, view, wall, width, 板, 报错, 备注, 标高, 标高调整, 标记, 标签, 参数, 拆分, 创建, 错误, 打标, 打断, 弹窗, 地板, 灯具, 点, 吊顶, 调整, 度, 房间, 分割, 分区, 复制, 赋值, 高程, 高度, 隔离, 更改, 更新, 共享参数, 构件, 管道, 管件, 管径, 管线, 毫米, 合并, 厚度, 机械设备, 基础, 检查, 建立, 角度, 宽度, 类型, 立管, 连接, 链接, 链接模型, 楼板, 米, 模型, 排水, 起点偏移, 墙, 墙体, 桥架, 曲线, 取消隐藏, 三通, 删除, 设备, 设置值, 审查, 生成, 视图, 水管, 套管, 提示, 天花板, 图元, 弯头, 文字注释, 污水, 系统, 系统类型, 显示, 线, 线槽, 线管, 项目, 项目参数, 消息, 消息框, 校验, 写入, 新建, 新增, 修改, 旋转, 移除, 隐藏, 元素, 长度, 直径, 直线, 重命名, 注释, 柱, 柱子, 族, 族符号, 族类型
- Description: TODO (hand-edit)

### ResetPipeSlope
- Path: existingCodes\梁涛插件源代码\1.土建\ResetPipeSlope\ResetPipeSlope
- Author: 梁涛插件源代码
- Actions: "批量重置管道坡度"
- APIs: Pick (Selection)
- UI: WinForms
- Integrations: HTTP
- Tags: batch, bulk, degree, pipe, slope, 度, 管道, 管线, 角度, 批量, 坡度, 水管
- Description: TODO (hand-edit)

### RevitUtils
- Path: existingCodes\梁涛插件源代码\11.其他\RevitUtils\RevitUtils
- Author: 梁涛插件源代码
- Actions: "修改板厚", "修改墙底部偏移"
- Dialogs: "revit", "er", "revt"
- Categories: OST_CableTray, OST_Views, OST_Floors, OST_Walls
- Parameters: LEADER_OFFSET_SHEET, TEXT_SIZE, FLOOR_HEIGHTABOVELEVEL_PARAM, WALL_BASE_OFFSET, VIEW_DISCIPLINE
- APIs: FilteredElementCollector, ElementTransformUtils, RayCast / ReferenceIntersector
- UI: WinForms
- Tags: cable tray, change, floor, height, level, line, modify, offset, sheet, slab, update, view, wall, 板, 标高, 地板, 调整, 高度, 更改, 更新, 楼板, 偏移, 偏移量, 墙, 墙体, 桥架, 视图, 图纸, 线, 线槽, 修改, 直线
- Description: TODO (hand-edit)

### RoomComponentInformationAssignment
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\RoomComponentInformationAssignment\RoomComponentInformationAssignment
- Author: 梁涛插件源代码
- Actions: "构件安装位置赋值"
- Categories: OST_Rooms, OST_PipeCurves
- APIs: FilteredElementCollector, TransactionGroup
- Tags: assign, curve, dialog, element, form, pipe, room, set value, window, 窗口, 窗体, 对话框, 房间, 赋值, 构件, 管道, 管线, 曲线, 设置值, 水管, 图元, 写入, 元素
- Description: TODO (hand-edit)

### SetFitting
- Path: existingCodes\其他插件源代码\SetFitting
- Author: 其他插件源代码
- Dialogs: "最近点", "交点坐标为:"
- Categories: OST_DuctFitting
- APIs: FilteredElementCollector, Pick (Selection), Element creation
- Tags: duct, point, 点, 风管
- Description: TODO (hand-edit)

### SystemHide
- Path: existingCodes\品成插件源代码\机电\SystemHide\SystemHide
- Author: 品成插件源代码
- Actions: "关闭系统"
- Categories: OST_CableTray, OST_CableTrayFitting, OST_Conduit, OST_ConduitFitting, OST_DuctCurves
- Parameters: RBS_DUCT_SYSTEM_TYPE_PARAM, RBS_PIPING_SYSTEM_TYPE_PARAM
- APIs: FilteredElementCollector, Pick (Selection), Ribbon (IExternalApplication)
- UI: WinForms
- Tags: cable tray, conduit, curve, duct, elbow, hide, pipe, pipe fitting, system, system type, type, 风管, 管道, 管件, 管线, 类型, 桥架, 曲线, 三通, 水管, 弯头, 系统, 系统类型, 线槽, 线管, 隐藏
- Description: TODO (hand-edit)

### SystemIsolate
- Path: existingCodes\品成插件源代码\机电\SystemIsolate\SystemIsolate
- Author: 品成插件源代码
- Actions: "关闭系统"
- Categories: OST_CableTray, OST_CableTrayFitting, OST_Conduit, OST_ConduitFitting, OST_DuctCurves
- Parameters: RBS_DUCT_SYSTEM_TYPE_PARAM, RBS_PIPING_SYSTEM_TYPE_PARAM
- APIs: FilteredElementCollector, Pick (Selection), Ribbon (IExternalApplication)
- UI: WinForms
- Tags: cable tray, conduit, curve, duct, elbow, isolate, pipe, pipe fitting, system, system type, type, 风管, 隔离, 管道, 管件, 管线, 类型, 桥架, 曲线, 三通, 水管, 弯头, 系统, 系统类型, 线槽, 线管
- Description: TODO (hand-edit)

### TextNoteForSleeveToTopFloor
- Path: existingCodes\梁涛插件源代码\5.吊架出图\TextNoteForSleeveToTopFloor\TextNoteForSleeveToTopFloor
- Author: 梁涛插件源代码
- Actions: "创建文字注释"
- Categories: OST_PipeAccessory, OST_MechanicalEquipment, OST_PipeFitting, OST_Views, OST_Floors
- Parameters: LEADER_OFFSET_SHEET, TEXT_SIZE
- APIs: FilteredElementCollector, ElementTransformUtils, RayCast / ReferenceIntersector
- UI: WinForms
- Tags: annotate, casing, ceiling, comments, create, elbow, floor, foundation, generate, link, linked model, new, note, offset, pipe, pipe fitting, sheet, slab, sleeve, view, 板, 备注, 创建, 地板, 吊顶, 管道, 管件, 管线, 基础, 建立, 链接, 链接模型, 楼板, 偏移, 偏移量, 三通, 生成, 视图, 水管, 套管, 天花板, 图纸, 弯头, 文字注释, 新建, 新增, 注释
- Description: TODO (hand-edit)

### VerticalWaterPipeIdentify
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\VerticalWaterPipeIdentify\VerticalWaterPipeIdentify
- Author: 梁涛插件源代码
- Actions: "排水立管标识"
- Dialogs: "revit", "提示"
- Categories: OST_PipeCurves
- Parameters: RBS_PIPE_DIAMETER_PARAM, CURVE_ELEM_LENGTH
- APIs: FilteredElementCollector
- Integrations: Database
- Tags: curve, diameter, drainage, length, message, meter, pipe, pipe size, prompt, riser, sanitary, taskdialog, vertical pipe, 弹窗, 管道, 管径, 管线, 立管, 米, 排水, 曲线, 水管, 提示, 污水, 消息, 消息框, 长度, 直径
- Description: TODO (hand-edit)

## Export/IO (3)

### ExportSchedule
- Path: existingCodes\品成插件源代码\通用\ExportSchedule\ExportSchedule
- Author: 品成插件源代码
- Categories: OST_Schedules
- APIs: FilteredElementCollector
- UI: WinForms
- Integrations: Excel interop
- Tags: export, schedule, 导出, 明细表, 输出
- Description: TODO (hand-edit)

### LayoutByDwg
- Path: existingCodes\品成插件源代码\通用\LayoutByDwg\LayoutByDwg
- Author: 品成插件源代码
- Actions: "批量布置构件"
- APIs: Pick (Selection), ElementTransformUtils, Element creation
- UI: WinForms
- Tags: arrange, batch, bulk, dwg, element, layout, place, 布局, 布置, 构件, 排布, 排列, 批量, 图元, 元素
- Description: TODO (hand-edit)

### ModifyingASchedule
- Path: existingCodes\梁涛插件源代码\10.CEG\ModifyingASchedule\ModifyingASchedule
- Author: 梁涛插件源代码
- Actions: "修改参数"
- Dialogs: "dd"
- Tags: change, gas, modify, parameter, schedule, shared parameter, update, 参数, 调整, 更改, 更新, 共享参数, 明细表, 燃气, 修改
- Description: TODO (hand-edit)

## Utilities (14)

### CEGShopTicketHelper
- Path: existingCodes\梁涛插件源代码\10.CEG\CEGShopTicketHelper\CEGShopTicketHelper
- Author: 梁涛插件源代码
- Actions: "adjust control mark", "1", "CopyTicket", "copyView", "copy dim"
- Dialogs: "r", "R", "Revit", "r1", "r2"
- Categories: OST_StructuralFraming, OST_TitleBlocks, OST_ScheduleGraphics, OST_TextNotes, OST_GenericAnnotation
- Parameters: BUILDING_CURVE_GSTYLE, SHEET_NAME, SHEET_NUMBER, SHEET_DRAWN_BY, SHEET_CHECKED_BY
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, TransactionGroup
- UI: WinForms
- Tags: annotate, area, audit, change, check, column, comments, copy, create, curve, dimension, error, generate, height, insulation, length, line, mark, millimeter, mm, model, modify, new, note, offset, rebar, schedule, sheet, tag, type, update, validate, view, volume, width, 保温, 报错, 备注, 标记, 标签, 标注, 尺寸标注, 创建, 错误, 打标, 调整, 复制, 钢筋, 高度, 隔热, 更改, 更新, 毫米, 检查, 建立, 绝缘, 宽度, 类型, 面积, 面积区域, 明细表, 模型, 配筋, 偏移, 偏移量, 曲线, 审查, 生成, 视图, 体积, 图纸, 文字注释, 线, 校验, 新建, 新增, 修改, 长度, 直线, 注释, 柱, 柱子
- Description: TODO (hand-edit)

### DimensionChecker
- Path: existingCodes\品成插件源代码\通用\DimensionChecker
- Author: 品成插件源代码
- Actions: "检查Dimension"
- Dialogs: "Revit", "a", "结果提示：", "/i2", "i3"
- Categories: OST_Dimensions
- Parameters: DIM_TOTAL_LENGTH
- APIs: Pick (Selection)
- Tags: audit, check, dimension, length, message, prompt, taskdialog, validate, 标注, 尺寸标注, 弹窗, 检查, 审查, 提示, 消息, 消息框, 校验, 长度
- Description: TODO (hand-edit)

### DimensionChecking
- Path: existingCodes\梁涛插件源代码\10.CEG\DimensionChecking\DimensionChecking
- Author: 梁涛插件源代码
- Actions: "TicketChecker-Dimension"
- Dialogs: "ll", "tip", "r", "a", "/i2"
- Categories: OST_TitleBlocks
- Parameters: DIM_TOTAL_LENGTH
- APIs: FilteredElementCollector
- UI: WinForms
- Tags: audit, check, dimension, length, validate, 标注, 尺寸标注, 检查, 审查, 校验, 长度
- Description: TODO (hand-edit)

### DWGTools
- Path: existingCodes\梁涛插件源代码\7.CAD插件\DWGTools\DWGTools
- Author: 梁涛插件源代码
- Tags: dwg
- Description: TODO (hand-edit)

### MEP_SmartConnect
- Path: existingCodes\品成插件源代码\机电\MEP_SmartConnect\MEP_SmartConnect
- Author: 品成插件源代码
- Actions: "BimtransMEPTools.SmartConnect"
- Parameters: ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM, RBS_CABLETRAY_WIDTH_PARAM
- APIs: Pick (Selection)
- UI: WinForms
- Tags: cable tray, conduit, connect, curve, diameter, height, join, mep, meter, partition, pipe, pipe size, width, 分区, 高度, 管道, 管径, 管线, 合并, 机电, 宽度, 连接, 米, 桥架, 曲线, 水电, 水管, 线槽, 线管, 直径
- Description: TODO (hand-edit)

### MEP_SmartSplit
- Path: existingCodes\品成插件源代码\机电\MEP_SmartSplit\MEP_SmartSplit
- Author: 品成插件源代码
- Actions: "BimtransMEPTools.SmartSplit"
- Parameters: ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM, RBS_CURVE_DIAMETER_PARAM
- APIs: Pick (Selection)
- UI: WinForms
- Tags: break, cable tray, conduit, curve, diameter, height, mep, meter, partition, pipe, pipe size, split, width, 拆分, 打断, 分割, 分区, 高度, 管道, 管径, 管线, 机电, 宽度, 米, 桥架, 曲线, 水电, 水管, 线槽, 线管, 直径
- Description: TODO (hand-edit)

### MEP_SmartSplitTwo
- Path: existingCodes\品成插件源代码\机电\MEP_SmartSplitTwo\MEP_SmartSplitTwo
- Author: 品成插件源代码
- Actions: "BimtransMEPTools.SmartSplit"
- Parameters: ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM, RBS_CURVE_DIAMETER_PARAM
- APIs: Pick (Selection)
- UI: WinForms
- Tags: break, cable tray, conduit, curve, diameter, height, mep, meter, partition, pipe, pipe size, split, width, 拆分, 打断, 分割, 分区, 高度, 管道, 管径, 管线, 机电, 宽度, 米, 桥架, 曲线, 水电, 水管, 线槽, 线管, 直径
- Description: TODO (hand-edit)

### MEP_SmartTrim
- Path: existingCodes\品成插件源代码\机电\MEP_SmartTrim\MEP_SmartTrim
- Author: 品成插件源代码
- Actions: "BimtransMEPTools.SmartTrim"
- Parameters: RBS_PIPE_DIAMETER_PARAM, RBS_START_LEVEL_PARAM, ELEM_PARTITION_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: Pick (Selection), ElementTransformUtils, TransactionGroup
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, height, level, mep, meter, partition, pipe, pipe size, start offset, trim, width, 标高, 分区, 高度, 管道, 管径, 管线, 机电, 宽度, 米, 起点偏移, 桥架, 曲线, 水电, 水管, 线槽, 线管, 修剪, 直径
- Description: TODO (hand-edit)

### MEP_SmartTrim90
- Path: existingCodes\品成插件源代码\机电\MEP_SmartTrim90\MEP_SmartTrim90
- Author: 品成插件源代码
- Actions: "BimtransMEPTools.SmartTrim"
- Parameters: RBS_PIPE_DIAMETER_PARAM, RBS_START_LEVEL_PARAM, ELEM_PARTITION_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: Pick (Selection)
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, height, level, mep, meter, partition, pipe, pipe size, start offset, trim, width, 标高, 分区, 高度, 管道, 管径, 管线, 机电, 宽度, 米, 起点偏移, 桥架, 曲线, 水电, 水管, 线槽, 线管, 修剪, 直径
- Description: TODO (hand-edit)

### MEP_SplitByLine
- Path: existingCodes\品成插件源代码\机电\MEP_SplitByLine\MEP_SplitByLine
- Author: 品成插件源代码
- Actions: "BimtransMEPTools.SplitByLine"
- Parameters: ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM, RBS_CABLETRAY_WIDTH_PARAM
- UI: WinForms
- Tags: break, cable tray, conduit, curve, diameter, height, line, mep, meter, partition, pipe, pipe size, split, width, 拆分, 打断, 分割, 分区, 高度, 管道, 管径, 管线, 机电, 宽度, 米, 桥架, 曲线, 水电, 水管, 线, 线槽, 线管, 直径, 直线
- Description: TODO (hand-edit)

### MEP_TagHelper
- Path: existingCodes\品成插件源代码\机电\MEP_TagHelper\MEP_TagHelper
- Author: 品成插件源代码
- Actions: "TAGHELPER"
- Dialogs: "Revit", "提示"
- APIs: FilteredElementCollector, Pick (Selection), Element creation
- Tags: mep, message, prompt, tag, taskdialog, 标记, 标签, 打标, 弹窗, 机电, 水电, 提示, 消息, 消息框
- Description: TODO (hand-edit)

### MEP_TagHelperForCT
- Path: existingCodes\品成插件源代码\机电\MEP_TagHelperForCT\MEP_TagHelperForCT
- Author: 品成插件源代码
- Actions: "TAGHELPER"
- Dialogs: "Revit", "提示"
- APIs: FilteredElementCollector, Pick (Selection), Element creation
- Tags: mep, message, prompt, tag, taskdialog, 标记, 标签, 打标, 弹窗, 机电, 水电, 提示, 消息, 消息框
- Description: TODO (hand-edit)

### Remark
- Path: existingCodes\品成插件源代码\通用\Remark\Remark\Remark
- Author: 品成插件源代码
- Actions: "BimtransArchiTools.Remark"
- Dialogs: "Revit"
- APIs: FilteredElementCollector, Pick (Selection)
- Tags: arc, mark, 标记, 弧, 圆弧
- Description: TODO (hand-edit)

### TagHelper
- Path: existingCodes\品成插件源代码\机电\TagHelper\TagHelper
- Author: 品成插件源代码
- Actions: "TAGHELPER"
- Dialogs: "Revit"
- APIs: FilteredElementCollector, Pick (Selection), Element creation
- Tags: tag, 标记, 标签, 打标
- Description: TODO (hand-edit)

## Uncategorized (26)

### AdjustLineLayerByLineType
- Path: existingCodes\梁涛插件源代码\7.CAD插件\AdjustLineLayerByLineType\AdjustLineLayerByLineType
- Author: 梁涛插件源代码
- Tags: line, type, 类型, 线, 直线
- Description: TODO (hand-edit)

### AssemblyViewCreater
- Path: existingCodes\品成插件源代码\通用\AssemblyViewCreater\AssemblyViewCreater
- Author: 品成插件源代码
- Actions: "View", "修改参数", "Sheet Name", "Sheet Creater"
- Dialogs: "r", "提示", "a"
- Categories: OST_TitleBlocks
- Parameters: SHEET_NAME, SHEET_NUMBER
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation
- UI: WinForms
- Tags: change, create, generate, message, modify, new, parameter, prompt, shared parameter, sheet, taskdialog, update, view, 参数, 创建, 弹窗, 调整, 更改, 更新, 共享参数, 建立, 生成, 视图, 提示, 图纸, 消息, 消息框, 新建, 新增, 修改
- Description: TODO (hand-edit)

### Batchlink
- Path: existingCodes\饶昌锋插件源代码\322批量添加链接\Batchlink
- Author: 饶昌锋插件源代码
- Dialogs: "已选择文件："
- UI: WinForms
- Tags: batch, bulk, document, link, linked model, pick, select, 链接, 链接模型, 批量, 拾取, 文档, 文件, 选取, 选择
- Description: TODO (hand-edit)

### BatchUnJoin
- Path: existingCodes\梁涛插件源代码\1.土建\BatchUnJoin\BatchUnJoin
- Author: 梁涛插件源代码
- Actions: "取消连接"
- APIs: FilteredElementCollector, Pick (Selection), TransactionGroup
- Tags: batch, bulk, connect, join, 合并, 连接, 批量
- Description: TODO (hand-edit)

### BrickBuilder
- Path: existingCodes\品成插件源代码\土建\BrickBuilder\BrickBuilder
- Author: 品成插件源代码
- Actions: "Bimtrans-BuildBrick", "t", "Isloate"
- Parameters: ELEM_FAMILY_PARAM, WALL_USER_HEIGHT_PARAM, WALL_BASE_OFFSET, ALL_MODEL_INSTANCE_COMMENTS, WALL_STRUCTURAL_USAGE_PARAM
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation, RayCast / ReferenceIntersector
- UI: WinForms
- Tags: comments, family, family name, height, millimeter, mm, model, offset, wall, 备注, 高度, 毫米, 模型, 偏移, 偏移量, 墙, 墙体, 注释, 族, 族名称
- Description: TODO (hand-edit)

### BrickPrintBuilder
- Path: existingCodes\品成插件源代码\土建\BrickPrintBuilder\BrickPrintBuilder
- Author: 品成插件源代码
- Actions: "砖翻模"
- Categories: OST_DataDevices
- Parameters: WALL_BASE_OFFSET
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils, Element creation
- UI: WinForms
- Tags: offset, wall, 偏移, 偏移量, 墙, 墙体
- Description: TODO (hand-edit)

### ChangeDimensionText
- Path: existingCodes\梁涛插件源代码\10.CEG\ChangeDimensionText\ChangeDimensionText
- Author: 梁涛插件源代码
- Actions: "change dimension text"
- Categories: OST_Dimensions
- APIs: FilteredElementCollector
- Tags: change, dimension, modify, update, 标注, 尺寸标注, 调整, 更改, 更新, 修改
- Description: TODO (hand-edit)

### ChangeLayerText2
- Path: existingCodes\梁涛插件源代码\7.CAD插件\ChangeLayerText2\ChangeLayerText2
- Author: 梁涛插件源代码
- Tags: change, modify, update, 调整, 更改, 更新, 修改
- Description: TODO (hand-edit)

### Com_EndPointOffsetTag
- Path: existingCodes\品成插件源代码\通用\Com_EndPointOffsetTag\Com_EndPointOffsetTag
- Author: 品成插件源代码
- Actions: "Creat IndependentTag"
- Parameters: RBS_START_OFFSET_PARAM, RBS_END_OFFSET_PARAM
- APIs: Pick (Selection)
- Tags: offset, point, start offset, tag, 标记, 标签, 打标, 点, 偏移, 偏移量, 起点偏移
- Description: TODO (hand-edit)

### Com_PointGridLocation
- Path: existingCodes\品成插件源代码\通用\Com_PointGridLocation\Com_PointGridLocation
- Author: 品成插件源代码
- Dialogs: "提示"
- Categories: OST_Grids
- Parameters: DATUM_TEXT, ELEM_PARTITION_PARAM, RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_WIDTH_PARAM, RBS_CURVE_HEIGHT_PARAM
- APIs: FilteredElementCollector, Pick (Selection)
- UI: WinForms
- Tags: cable tray, conduit, curve, diameter, grid, height, message, meter, partition, pipe, pipe size, point, prompt, taskdialog, width, 弹窗, 点, 分区, 高度, 管道, 管径, 管线, 宽度, 米, 桥架, 曲线, 水管, 提示, 线槽, 线管, 消息, 消息框, 直径, 轴网
- Description: TODO (hand-edit)

### Com_ShowElement
- Path: existingCodes\品成插件源代码\通用\Com_ShowElement\Com_ShowElement
- Author: 品成插件源代码
- Dialogs: "提示"
- UI: WinForms
- Tags: element, message, prompt, show, taskdialog, unhide, 弹窗, 构件, 取消隐藏, 提示, 图元, 显示, 消息, 消息框, 元素
- Description: TODO (hand-edit)

### Com_StartPointOffsetTag
- Path: existingCodes\品成插件源代码\通用\Com_StartPointOffsetTag\Com_StartPointOffsetTag
- Author: 品成插件源代码
- Actions: "Creat IndependentTag"
- Parameters: RBS_START_OFFSET_PARAM, RBS_END_OFFSET_PARAM
- APIs: Pick (Selection)
- Tags: offset, point, start offset, tag, 标记, 标签, 打标, 点, 偏移, 偏移量, 起点偏移
- Description: TODO (hand-edit)

### ConvertToTianzheng
- Path: existingCodes\梁涛插件源代码\7.CAD插件\ConvertToTianzheng\ConvertToTianzheng
- Author: 梁涛插件源代码
- Description: TODO (hand-edit)

### CopyUUID
- Path: existingCodes\品成插件源代码\通用\CopyUUID\CopyUUID
- Author: 品成插件源代码
- APIs: Pick (Selection)
- UI: WinForms
- Tags: copy, 复制
- Description: TODO (hand-edit)

### CreateFakeConnectBridge
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\CreateFakeConnectBridge\CreateFakeConnectBridge
- Author: 梁涛插件源代码
- Actions: "生成连接桥架"
- Dialogs: "Revit"
- APIs: Pick (Selection), ElementTransformUtils
- Tags: cable tray, connect, create, generate, join, new, 创建, 合并, 建立, 连接, 桥架, 生成, 线槽, 新建, 新增
- Description: TODO (hand-edit)

### DynamicModelUpdate
- Path: existingCodes\饶昌锋插件源代码\258吊架分类编号并标记\HangerClassificationAnnotation\DynamicModelUpdate
- Author: 饶昌锋插件源代码
- Actions: "Move Bridge 2"
- Dialogs: "提示", "Asdasd"
- APIs: Pick (Selection), ElementTransformUtils, Modeless (ExternalEvent)
- Tags: change, message, model, modify, move, prompt, taskdialog, update, 弹窗, 调整, 更改, 更新, 模型, 提示, 消息, 消息框, 修改, 移动
- Description: TODO (hand-edit)

### FillRoute
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\FillRoute\FillRoute
- Author: 梁涛插件源代码
- Actions: "填充路由"
- APIs: Pick (Selection)
- Description: TODO (hand-edit)

### HangerQuantity
- Path: existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\HangerQuantity\HangerQuantity
- Author: 梁涛插件源代码
- Dialogs: "error"
- Categories: OST_Views, OST_TextNotes
- APIs: FilteredElementCollector
- UI: WinForms
- Integrations: Excel interop
- Tags: annotate, error, hanger, note, support, view, 报错, 错误, 吊架, 视图, 文字注释, 支吊架, 注释
- Description: TODO (hand-edit)

### MovePointElement
- Path: existingCodes\梁涛插件源代码\2.机电建模及算量\MovePointElement\MovePointElement
- Author: 梁涛插件源代码
- Actions: "重设", "重设2", "移动点元素", "临时隐藏"
- Dialogs: "revit"
- APIs: FilteredElementCollector, ElementTransformUtils, Modeless (ExternalEvent)
- Tags: element, hide, move, point, 点, 构件, 图元, 移动, 隐藏, 元素
- Description: TODO (hand-edit)

### MulitLink
- Path: existingCodes\品成插件源代码\通用\MulitLink\MulitLink
- Author: 品成插件源代码
- Actions: "链接模型"
- UI: WinForms
- Tags: link, linked model, model, 链接, 链接模型, 模型
- Description: TODO (hand-edit)

### NewBTStore
- Path: existingCodes\梁涛插件源代码\9.新品成插件商店\NewBTStore\NewBTStore
- Author: 梁涛插件源代码
- Actions: "调用管道命令"
- Dialogs: "rveit", "rr", "revit", "idno", "error"
- APIs: Ribbon (IExternalApplication)
- UI: WinForms
- Integrations: JSON, HTTP
- Tags: create, error, generate, new, pipe, 报错, 创建, 错误, 管道, 管线, 建立, 生成, 水管, 新建, 新增
- Description: TODO (hand-edit)

### NewBTStoreUpdater
- Path: existingCodes\梁涛插件源代码\9.新品成插件商店\NewBTStoreUpdater\NewBTStoreUpdater
- Author: 梁涛插件源代码
- Tags: change, create, generate, modify, new, update, 创建, 调整, 更改, 更新, 建立, 生成, 新建, 新增, 修改
- Description: TODO (hand-edit)

### PlaceByCurve
- Path: existingCodes\品成插件源代码\通用\PlaceByCurve\PlaceByCurve
- Author: 品成插件源代码
- Actions: "按路径线布置"
- APIs: Pick (Selection), ElementTransformUtils, Element creation
- UI: WinForms
- Tags: arrange, curve, layout, line, place, 布局, 布置, 排布, 排列, 曲线, 线, 直线
- Description: TODO (hand-edit)

### SectionBoxController
- Path: existingCodes\品成插件源代码\通用\SectionBoxController\SectionBoxController
- Author: 品成插件源代码
- Actions: "SectionBoxController"
- Dialogs: "Error"
- APIs: Modeless (ExternalEvent)
- UI: WinForms
- Tags: error, 报错, 错误
- Description: TODO (hand-edit)

### SingleTubeHangerNotes
- Path: existingCodes\饶昌锋插件源代码\270单管吊架注释\SingleTubeHangerNotes
- Author: 饶昌锋插件源代码
- Actions: "添加标记"
- Dialogs: "Asdas"
- Parameters: LEADER_OFFSET_SHEET, TEXT_SIZE
- APIs: FilteredElementCollector, Pick (Selection), ElementTransformUtils
- Tags: annotate, hanger, mark, note, offset, sheet, support, tag, 标记, 标签, 打标, 吊架, 偏移, 偏移量, 图纸, 文字注释, 支吊架, 注释
- Description: TODO (hand-edit)

### TextRecognitionInCAD
- Path: existingCodes\梁涛插件源代码\7.CAD插件\TextRecognitionInCAD\TextRecognitionInCAD
- Author: 梁涛插件源代码
- Dialogs: "error"
- UI: WinForms
- Integrations: Excel interop
- Tags: error, 报错, 错误
- Description: TODO (hand-edit)

