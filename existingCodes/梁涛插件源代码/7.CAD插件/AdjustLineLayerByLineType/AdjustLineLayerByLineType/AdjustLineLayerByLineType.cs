using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustLineLayerByLineType
{
    public class AdjustLineLayerByLineType
    {
        [CommandMethod("ALBLT")]
        public void ChangeLineLayerByLineType()
        {
            // 活动文档
            Document doc = Application.DocumentManager.MdiActiveDocument;
            // 数据库
            Database db = doc.Database;
            // 编辑器
            Editor ed = doc.Editor;

            PromptEntityOptions entityOptions = new PromptEntityOptions("\n选择一条线段");
            entityOptions.AllowNone = false;
            entityOptions.SetRejectMessage("\n只能选择一条线段");
            entityOptions.AddAllowedClass(typeof(Line), true);
            entityOptions.AddAllowedClass(typeof(Polyline), true);
            var eResult = ed.GetEntity(entityOptions);
            if (eResult.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n用户取消操作");
                return;
            }
            //

            // 提示用户框选范围
            //PromptSelectionOptions options = new PromptSelectionOptions
            //{
            //    MessageForAdding = "选择一条线段: "
            //};

            //// 捕获用户的选择
            //PromptSelectionResult result = ed.GetSelection(options);

            //if (result.Status != PromptStatus.OK)
            //{
            //    ed.WriteMessage("\n未选择任何线段或操作取消.");
            //    return;
            //}

            //// 获取选择的对象
            //SelectionSet selectionSet = result.Value;

            // 打开数据库进行处理
            using (Transaction tr = doc.Database.TransactionManager.StartTransaction())
            {
                Entity selectedEntity = tr.GetObject(eResult.ObjectId, OpenMode.ForRead) as Entity;
                //ed.WriteMessage($"\n图层名称:{selectedEntity.Layer}线型:{selectedEntity.Linetype}");

                string lineType = selectedEntity.Linetype;
                //foreach (SelectedObject selObj in selectionSet)
                //{
                //    if (selObj != null)
                //    {
                //        Entity entity = tr.GetObject(selObj.ObjectId, OpenMode.ForRead) as Entity;

                //        if (entity != null && (entity is Polyline || entity is Line))
                //        {
                //            lineType = entity.Linetype;
                //            break;
                //        }
                //        else
                //        {
                //            ed.WriteMessage("\n所选对象不是线段");
                //            return;
                //        }
                //    }
                //}
                ed.WriteMessage($"\n所选线段线型为：{lineType}");

                // 新图层的名称
                PromptStringOptions stringOptions = new PromptStringOptions("\n输入一个新的图层名称");
                stringOptions.AllowSpaces = true;
                var inputString = ed.GetString(stringOptions);
                if (inputString.Status != PromptStatus.OK)
                {
                    ed.WriteMessage("\n已取消操作");
                    return;
                }


                string newLayerName = inputString.StringResult;
                if (string.IsNullOrEmpty(newLayerName))
                {
                    ed.WriteMessage("\n新图层名称不能为空");
                }
                else
                {
                    ed.WriteMessage($"\n新图层名称为:{newLayerName}");
                }

                //打开块表
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                //打开块记录表
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                // 记录成功修改的个数
                int adjustCount = 0;

                // 判断cad图纸中是否已存在该图层名称，若无则新建
                LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                if (!lt.Has(newLayerName))
                {
                    lt.UpgradeOpen();
                    LayerTableRecord ltr = new LayerTableRecord();
                    ltr.Name = newLayerName;
                    lt.Add(ltr);
                    tr.AddNewlyCreatedDBObject(ltr, true);
                }

                // 调整同线型的线段图层
                foreach (ObjectId objId in btr)
                {
                    var obj = tr.GetObject(objId, OpenMode.ForRead);
                    if (obj != null && obj is Entity entity && entity.Linetype == lineType && (entity is Polyline || entity is Line))
                    {
                        entity.UpgradeOpen();
                        entity.Layer = newLayerName;
                        adjustCount++;
                    }
                }

                ed.WriteMessage($"\n图层修改完成！修改的直线/多段线数量为：{adjustCount}条");
                tr.Commit();
            }
        }
    }
}
