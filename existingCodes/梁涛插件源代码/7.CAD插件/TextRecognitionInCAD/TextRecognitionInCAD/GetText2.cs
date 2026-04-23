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

    public class GetText2 // 测试用
    {
        [CommandMethod("GetText2")]
        public void SelectEntitiesInArea()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;

            // 提示用户框选范围
            PromptSelectionOptions options = new PromptSelectionOptions
            {
                MessageForAdding = "请框选一个范围以选择实体: "
            };

            // 捕获用户的选择
            PromptSelectionResult result = ed.GetSelection(options);

            if (result.Status != PromptStatus.OK)
            {
                ed.WriteMessage("\n未选择任何实体或操作取消.");
                return;
            }

            // 获取选择的对象
            SelectionSet selectionSet = result.Value;

            // 打开数据库进行处理
            using (Transaction tr = doc.Database.TransactionManager.StartTransaction())
            {
                foreach (SelectedObject selObj in selectionSet)
                {
                    if (selObj != null)
                    {
                        Entity entity = tr.GetObject(selObj.ObjectId, OpenMode.ForRead) as Entity;

                        if (entity != null && entity is DBText text)
                        {
                            // 输出实体的信息（例如类型、位置等）
                            ed.WriteMessage($"\n已选实体: {entity.GetType().Name}, 对象ID: {entity.ObjectId},文本: {text.TextString},坐标: {text.Position}");
                        }
                    }
                }
                tr.Commit();
            }
        }
    }
}
