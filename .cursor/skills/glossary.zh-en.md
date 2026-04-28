# Revit Bilingual Glossary (EN ↔ ZH ↔ API)

Shared source of truth for Chinese / English parity across all three skills
(`revit-addin-scaffold`, `revit-api-lookup`, `revit-addin-build-deploy`).

Every `en`, `zh`, and `api` cell may list **multiple synonyms separated by `,`
or `、`** — the indexer and the search script accept any of them.

Extending this file is the primary way to improve bilingual retrieval. When you
hit a term the system missed, add a row and re-run `build-index.ps1` to refresh
the packaged scaffold `samples-index/`. Maintainers should also re-run
`build-api-index.ps1` if the new term maps to an API symbol and should appear in
the packaged API index.

**Format rules:**
- `api` = the exact C# identifier(s) from the Revit API: class name, `OST_*`
  category, `RBS_*` / `WALL_*` parameter, etc. Use `n/a` if no 1-to-1 symbol.
- Separators inside a cell: `,` (ASCII comma) or `、` (CJK comma).
- Case in `en` is lowercase canonical. Case in `api` matches the API exactly.

## Categories / element kinds

| en | zh | api |
|---|---|---|
| wall | 墙、墙体 | Wall, OST_Walls |
| floor, slab | 楼板、板、地板 | Floor, OST_Floors |
| ceiling | 天花板、吊顶 | Ceiling, OST_Ceilings |
| roof | 屋顶 | Roof, OST_Roofs |
| door | 门 | Door, OST_Doors |
| window | 窗、窗户 | Window, OST_Windows |
| room | 房间 | Room, OST_Rooms |
| area | 面积区域 | Area, OST_Areas |
| stair | 楼梯 | Stairs, OST_Stairs |
| railing | 栏杆 | Railing, OST_StairsRailing |
| curtain wall | 幕墙 | OST_CurtainWallPanels |
| column | 柱、柱子 | Column, OST_Columns |
| structural column | 结构柱 | OST_StructuralColumns |
| beam | 梁 | OST_StructuralFraming |
| brace | 支撑 | OST_StructuralFraming |
| foundation | 基础 | OST_StructuralFoundation |
| rebar | 钢筋、配筋 | Rebar, OST_Rebar |
| truss | 桁架 | OST_StructuralTruss |
| pipe | 管道、水管、管线 | Pipe, OST_PipeCurves |
| pipe fitting, elbow | 管件、弯头、三通 | PipeFitting, OST_PipeFitting |
| pipe accessory, valve | 管道附件、阀门 | OST_PipeAccessory |
| pipe insulation | 管道保温、保温层 | OST_PipeInsulations |
| duct | 风管 | Duct, OST_DuctCurves |
| duct fitting | 风管管件 | OST_DuctFitting |
| duct accessory | 风管附件 | OST_DuctAccessory |
| duct insulation | 风管保温 | OST_DuctInsulations |
| cable tray | 桥架、线槽 | CableTray, OST_CableTray |
| cable tray fitting | 桥架管件 | OST_CableTrayFitting |
| conduit | 线管 | Conduit, OST_Conduit |
| mechanical equipment | 机械设备、设备 | OST_MechanicalEquipment |
| electrical equipment | 电气设备 | OST_ElectricalEquipment |
| electrical fixture | 电气装置 | OST_ElectricalFixtures |
| plumbing fixture | 卫浴装置、洁具 | OST_PlumbingFixtures |
| sprinkler | 喷头、喷淋 | OST_Sprinklers |
| lighting fixture | 灯具 | OST_LightingFixtures |
| furniture | 家具 | OST_Furniture |
| generic model | 常规模型、通用模型 | OST_GenericModel |
| family | 族 | Family |
| family instance | 族实例 | FamilyInstance |
| family symbol, family type | 族类型、族符号 | FamilySymbol |
| level | 标高 | Level, OST_Levels |
| grid | 轴网 | Grid, OST_Grids |
| view | 视图 | View, OST_Views |
| sheet | 图纸 | ViewSheet |
| schedule | 明细表 | ViewSchedule |
| section view | 剖面视图、剖面 | ViewSection |
| plan view | 平面视图、平面图 | ViewPlan |
| elevation view | 立面视图、立面图 | ViewElevation |
| 3d view | 三维视图、3d视图 | View3D |
| drafting view | 绘图视图 | ViewDrafting |
| element | 构件、图元、元素 | Element |
| linked model, link | 链接模型、链接 | RevitLinkInstance, OST_RvtLinks |
| workset | 工作集 | Workset |
| material | 材质、材料 | Material, OST_Materials |

## MEP system classifications

| en | zh | api |
|---|---|---|
| mep | 机电、水电 | MEP |
| hvac | 暖通 | HVAC |
| plumbing | 给排水 | Plumbing |
| supply air | 送风 | SupplyAir |
| return air | 回风 | ReturnAir |
| exhaust air | 排风 | ExhaustAir |
| cold water, domestic cold water | 冷水、生活冷水 | DomesticColdWater |
| hot water, domestic hot water | 热水、生活热水 | DomesticHotWater |
| drainage, sanitary | 排水、污水 | SanitaryDrain |
| fire protection, fire sprinkler | 消防、消防喷淋 | FireProtect, FireProtectWet |
| condensate | 冷凝水 | CondensateDrain |
| chilled water | 冷冻水 | ChilledWater |
| storm drain | 雨水 | Storm |
| vent | 通气 | Vent |
| gas | 燃气 | OtherPipe |

## MEP concepts / components

| en | zh | api |
|---|---|---|
| hanger, support | 吊架、支吊架 | n/a |
| sleeve, casing | 套管 | n/a |
| clash, conflict, collision | 碰撞、冲突 | n/a |
| slope | 坡度 | n/a |
| connector | 连接件、接口 | Connector |
| system | 系统 | MEPSystem |
| elbow, bend | 弯头 | n/a |
| tee | 三通 | n/a |
| reducer | 变径 | n/a |
| insulation | 保温、绝缘、隔热 | n/a |
| riser, vertical pipe | 立管 | n/a |

## Parameters / properties

| en | zh | api |
|---|---|---|
| length | 长度 | CURVE_ELEM_LENGTH |
| area | 面积 | HOST_AREA_COMPUTED |
| volume | 体积 | HOST_VOLUME_COMPUTED |
| thickness | 厚度 | FLOOR_ATTR_THICKNESS_PARAM, FLOOR_ATTR_DEFAULT_THICKNESS_PARAM |
| height | 高度 | WALL_USER_HEIGHT_PARAM, RBS_CURVE_HEIGHT_PARAM |
| width | 宽度 | RBS_CURVE_WIDTH_PARAM |
| diameter, pipe size | 直径、管径 | RBS_PIPE_DIAMETER_PARAM, RBS_CURVE_DIAMETER_PARAM, RBS_PIPE_OUTER_DIAMETER |
| elevation | 标高、高程 | LEVEL_ELEV, BASEPOINT_ELEVATION_PARAM |
| offset | 偏移、偏移量 | WALL_BASE_OFFSET, RBS_OFFSET_PARAM, INSTANCE_FREE_HOST_OFFSET_PARAM |
| start offset | 起点偏移 | RBS_START_LEVEL_PARAM, RBS_END_OFFSET_PARAM |
| comments | 注释、备注 | ALL_MODEL_INSTANCE_COMMENTS |
| mark | 标记 | ALL_MODEL_MARK |
| type name | 类型名称 | SYMBOL_NAME_PARAM |
| family and type | 族与类型 | ELEM_FAMILY_AND_TYPE_PARAM |
| family name | 族名称 | ELEM_FAMILY_PARAM |
| type | 类型 | ELEM_TYPE_PARAM |
| base constraint | 底部限制条件 | WALL_BASE_CONSTRAINT |
| top constraint | 顶部限制条件 | WALL_HEIGHT_TYPE |
| insulation thickness | 保温厚度 | RBS_REFERENCE_INSULATION_THICKNESS |
| system classification | 系统分类 | RBS_SYSTEM_CLASSIFICATION_PARAM |
| system type | 系统类型 | RBS_PIPING_SYSTEM_TYPE_PARAM |
| partition | 分区 | ELEM_PARTITION_PARAM |
| level name | 标高名称 | LEVEL_NAME |

## Actions / verbs

| en | zh | api |
|---|---|---|
| create, new, generate | 创建、新建、生成、建立、新增 | Create |
| delete, remove | 删除、移除 | Delete |
| move | 移动 | MoveElement, MoveElements |
| copy | 复制 | CopyElement, CopyElements |
| rotate | 旋转 | RotateElement, RotateElements |
| mirror | 镜像 | MirrorElement, MirrorElements |
| align | 对齐 | n/a |
| offset | 偏移 | n/a |
| connect, join | 连接、合并 | JoinGeometry |
| split, break | 拆分、打断、分割 | n/a |
| trim | 修剪 | n/a |
| pick, select | 选择、拾取、选取 | PickObject, PickObjects |
| rectangle pick, box pick | 框选、框选拾取 | PickElementsByRectangle |
| rename | 重命名 | n/a |
| tag | 标记、打标、标签 | IndependentTag, NewTag |
| annotate, note | 注释、文字注释 | TextNote |
| dimension | 尺寸标注、标注 | Dimension |
| export | 导出、输出 | Export |
| import | 导入 | Import |
| filter | 筛选、过滤 | FilteredElementCollector |
| modify, change, update | 修改、更改、更新、调整 | n/a |
| batch, bulk | 批量 | n/a |
| arrange, layout, place | 布置、排布、布局、排列 | n/a |
| assign, set value | 赋值、设置值、写入 | Parameter.Set |
| merge | 合并 | n/a |
| check, validate, audit | 检查、审查、校验 | n/a |
| color, colour, paint | 着色、上色、染色、填色 | n/a |
| isolate | 隔离 | TemporaryHideIsolate |
| hide | 隐藏 | Hide |
| unhide, show | 取消隐藏、显示 | Unhide |
| ray cast, ray intersect | 射线、射线相交 | ReferenceIntersector |
| offset pipe | 管道偏移、避让 | n/a |
| align pipe, pipe alignment | 管线对齐 | n/a |
| align fitting | 弯头对齐 | n/a |
| adjust elevation | 标高调整 | n/a |

## UI / dialog / integration

| en | zh | api |
|---|---|---|
| ribbon | 功能区 | RibbonPanel |
| panel | 面板 | n/a |
| button | 按钮 | PushButton, PushButtonData |
| dialog, window, form | 对话框、窗口、窗体 | n/a |
| taskdialog, prompt | 提示、弹窗、消息框 | TaskDialog |
| error | 错误、报错 | n/a |
| warning | 警告 | n/a |
| message | 消息、提示 | n/a |
| excel | excel、表格、电子表格 | n/a |
| csv | csv | n/a |
| dwg | dwg | n/a |
| ifc | ifc | n/a |
| json | json | n/a |
| http, web | http、网络 | n/a |
| database | 数据库 | n/a |

## Geometry / miscellaneous

| en | zh | api |
|---|---|---|
| point | 点 | XYZ |
| line | 线、直线 | Line |
| curve | 曲线 | Curve |
| arc | 弧、圆弧 | Arc |
| polyline | 多段线、折线 | PolyLine |
| bounding box | 包围盒 | BoundingBoxXYZ |
| transform | 变换 | Transform |
| transaction | 事务 | Transaction |
| parameter, shared parameter | 参数、共享参数 | Parameter, SharedParameter |
| project parameter | 项目参数 | n/a |
| template | 模板 | n/a |
| project | 项目 | Project |
| document | 文档、文件 | Document |
| model | 模型 | n/a |
| axis, x-axis, y-axis, z-axis | 轴、x轴、y轴、z轴 | XYZ |
| origin | 原点 | n/a |
| millimeter, mm | 毫米 | UnitTypeId.Millimeters |
| meter, m | 米 | UnitTypeId.Meters |
| feet | 英尺 | UnitTypeId.Feet |
| degree | 度、角度 | UnitTypeId.Degrees |
| radian | 弧度 | UnitTypeId.Radians |
