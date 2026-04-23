using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWGTools
{
    public class LayerCmd
    {
        // 根据选择图层对图层中的块参照按块参照名称分组到新图层中
        [CommandMethod("GLBR")]
        public void GroupLayerByReferenceName()
        {
            // 获取当前文档和编辑器
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;

            string selLayer = "";
            List<BlockReference> blockReferences = new List<BlockReference>();

            PromptEntityResult result1 = ed.GetEntity("\n请选择图层");
            if (result1.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n结束");
                return;//如果选择对象不为空
            }
            
            ObjectId objectId = result1.ObjectId;//获得实体类对象的ObjectId

            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                Entity selEntity = tr.GetObject(objectId, OpenMode.ForRead) as Entity;
                //if (selEntity is BlockReference blockReference) ed.WriteMessage($"\n{selEntity.BlockName}\n{blockReference.Name}\n{blockReference.BlockName}");
                selLayer = selEntity.Layer;
                tr.Commit();
            }
            //return;
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                foreach (ObjectId objId in btr)
                {
                    try
                    {
                        var obj = tr.GetObject(objId, OpenMode.ForRead);
                        if (obj is BlockReference blockReference && blockReference.Layer.Equals(selLayer))
                        {
                            blockReferences.Add(blockReference);
                        }
                    }
                    catch (System.Exception)
                    {
                        continue;
                    }
                }
                tr.Commit();
            }
            
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var referenceGroup = blockReferences.GroupBy(bf => bf.Name);
                int i = 0;
                foreach (var blocks in referenceGroup)
                {
                    i++;
                    //string newLayerName = selLayer + "-" + blocks.Key;
                    string newLayerName = selLayer + "-" + i.ToString();
                    LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                    if (!lt.Has(newLayerName))
                    {
                        lt.UpgradeOpen();
                        LayerTableRecord ltr = new LayerTableRecord();
                        ltr.Name = newLayerName;
                        lt.Add(ltr);
                        tr.AddNewlyCreatedDBObject(ltr, true);
                    }

                    foreach (var block in blocks.ToList())
                    {
                        try
                        {
                            BlockReference blockReference = (BlockReference)tr.GetObject(block.ObjectId, OpenMode.ForRead);
                            blockReference.UpgradeOpen();
                            blockReference.Layer = newLayerName;
                        }
                        catch (System.Exception ex)
                        {
                            ed.WriteMessage("\n" + ex.Message);
                        }
                    }
                }
                tr.Commit();
            }
            return;
            using (Transaction tr = doc.TransactionManager.StartTransaction())
            {
                var referenceGroup = blockReferences.GroupBy(bf => bf.Name);
                foreach (var blocks in referenceGroup)
                {
                    string newLayerName = selLayer + "-" + blocks.Key;
                    foreach (var block in blocks.ToList())
                    {
                        //if (!block.IsWriteEnabled) block.UpgradeOpen();
                        try
                        {
                            BlockReference blockReference = (BlockReference)tr.GetObject(block.ObjectId, OpenMode.ForRead);
                            blockReference.UpgradeOpen();
                            blockReference.Layer = newLayerName;
                        }
                        catch (System.Exception ex)
                        {
                            ed.WriteMessage("\n" + ex.Message);
                        }
                        
                        //block.Layer = newLayerName;
                    }
                }
                tr.Commit();
            }

        }
    }
}
