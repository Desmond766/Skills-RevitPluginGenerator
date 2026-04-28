using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRecognitionInCAD
{
    public class Demo // 测试用
    {
        [CommandMethod("Demo01")]
        public void GetEntitiesFromBlockReference()
        {
            // 获取当前文档和编辑器
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;

            // 提示用户选择一个块参照
            PromptEntityOptions promptOptions = new PromptEntityOptions("\n请选择一个块参照:");
            /*promptOptions.AddAllowedClass(typeof(BlockReference), true);*/  // 限制选择为块参照

            PromptEntityResult result = ed.GetEntity(promptOptions);

            if (result.Status == PromptStatus.OK)
            {
                // 获取选中的块参照
                ObjectId blockRefId = result.ObjectId;

                // 开始事务，获取块定义中的实体
                using (Transaction tr = doc.TransactionManager.StartTransaction())
                {
                    // 获取块参照实体
                    BlockReference blockRef = (BlockReference)tr.GetObject(blockRefId, OpenMode.ForRead);

                    // 获取块参照的块定义（BlockTableRecord）
                    BlockTableRecord blockDef = (BlockTableRecord)tr.GetObject(blockRef.BlockTableRecord, OpenMode.ForRead);

                    // 遍历块定义中的所有实体
                    foreach (ObjectId blockEntityId in blockDef)
                    {
                        Entity blockEntity = (Entity)tr.GetObject(blockEntityId, OpenMode.ForRead);

                        // 输出实体类型和其他相关信息
                        ed.WriteMessage($"\n块定义中的实体类型: {blockEntity.GetType().Name}");

                        // 你可以根据需要进一步处理这些实体
                        if (blockEntity is DBText textEntity)
                        {
                            // 如果是文本实体，输出文本内容
                            ed.WriteMessage($"\n文本内容: {textEntity.TextString}");
                        }
                        else if (blockEntity is MText mTextEntity)
                        {
                            // 如果是多行文本实体，输出多行文本内容
                            ed.WriteMessage($"\n多行文本内容: {mTextEntity.Text}");
                        }
                        // 这里可以继续添加其他类型实体的处理逻辑
                    }

                    // 提交事务
                    tr.Commit();
                }
            }
            else
            {
                ed.WriteMessage("\n没有选择任何块参照或选择操作被取消");
            }
        }

    }
}
