# Sample Snippet: ChangeLayerText2

Source project: `existingCodes\梁涛插件源代码\7.CAD插件\ChangeLayerText2\ChangeLayerText2`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Class1.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
using Autodesk.AutoCAD.EditorInput;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using Autodesk.AutoCAD.GraphicsInterface;
using Polyline = Autodesk.AutoCAD.DatabaseServices.Polyline;

namespace ChangeLayerText2
{
    //修改文本信息至正确的图层（根据线段相交点的管道图层来判断）
    public class Class1
    {
        string layerName;
        int c;
        Editor ed;
        [CommandMethod("ChangeTextLayer")]
        public void ChangeTextLayer()
        {
            //活动文档
            Document doc = Application.DocumentManager.MdiActiveDocument;
            //数据库
            Database db = doc.Database;
            //编辑器
            ed = doc.Editor;

            //// 定义搜索范围
            //double range = 1000.0;

            PromptStringOptions pso = new PromptStringOptions("输入图层名称:");
            PromptResult pr = ed.GetString(pso);
            if (pr.Status != PromptStatus.OK)
                return;

            layerName = pr.StringResult;
            List<EntityInfo> entityInfos = new List<EntityInfo>();
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                //打开块表
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                //打开块记录表
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                //获取所有多段线
                List<Polyline> polylines = new List<Polyline>();
                // 遍历模型空间中的所有对象
                foreach (ObjectId objId in btr)
                {
                    Entity ent = tr.GetObject(objId, OpenMode.ForRead) as Entity;
                    if (ent != null && ent is Polyline)
                    {
                        Polyline polyline = ent as Polyline;

                        polylines.Add(polyline);
                    }
                }
                List<Entity> entitiesInRange = new List<Entity>();
                List<ObjectId> hasAddObjId = new List<ObjectId>();
                //1.将选择图层的线段和文本进行分组
                // 遍历同图层的实体
                foreach (ObjectId objId in btr)
                {
                    if (hasAddObjId.Contains(objId) || !((tr.GetObject(objId, OpenMode.ForRead) as Entity) is Line)) continue;
                    List<Line> lines = new List<Line>();
                    List<DBText> dBTexts = new List<DBText>();
                    Entity ent = tr.GetObject(objId, OpenMode.ForRead) as Entity;
                    if (ent != null && ent.Layer == layerName)
                    {
                        if (ent is Line line) { lines.Add(line); FindNearest(line, btr, tr, lines, dBTexts, hasAddObjId); }
                        //if (ent is DBText dText) dBTexts.Add(dText);
                        //FindNearest(ent, btr);
                        if (lines.Count() > 2 * dBTexts.Count())
                        {
                            EntityInfo entityInfo = new EntityInfo() { Lines = lines, DBTexts = dBTexts };
                            entityInfos.Add(entityInfo);
                        }
                    }
                }
                //ed.WriteMessage($"\n在范围内找到 {entitiesInRange.Count} 个实体.");
                //ed.WriteMessage(entityInfos.Count().ToString()+"\n");
// ... truncated ...
```

## Properties\AssemblyInfo.cs

```csharp
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("ChangeLayerText2")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ChangeLayerText2")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("62d85242-63e3-4f0c-b756-07ca2e474bf8")]

// 程序集的版本信息由下列四个值组成: 
//
//      主版本
//      次版本
//      生成号
//      修订号
//
//可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值
//通过使用 "*"，如下所示:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

```

