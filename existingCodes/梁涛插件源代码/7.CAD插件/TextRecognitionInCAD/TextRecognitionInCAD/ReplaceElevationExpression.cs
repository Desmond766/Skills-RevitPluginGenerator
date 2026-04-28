using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextRecognitionInCAD
{
    // 更改标高的表达方式
    public class ReplaceElevationExpression
    {
        [CommandMethod("REE")]
        public void ReplaceText()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    // 获取模型空间中的所有实体
                    BlockTable bt = trans.GetObject(db.BlockTableId, OpenMode.ForWrite) as BlockTable;
                    BlockTableRecord modelSpace = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    List<MText> targetTexts = new List<MText>();
                    HashSet<ObjectId> processedBlocks = new HashSet<ObjectId>();

                    // 1.获取用户输入的新数字
                    double newNumber = GetUserNumber(ed);
                    if (double.IsNaN(newNumber))
                    {
                        ed.WriteMessage("\n已取消操作。");
                        return;
                    }

                    // 2.炸开块中有CL+或BL+多行文字的块参照
                    ExplodeBlockReference(trans, modelSpace);

                    // 3.收集所有符合条件的多行文字
                    CollectTargetTexts(modelSpace, targetTexts, processedBlocks, trans);

                    if (targetTexts.Count == 0)
                    {
                        ed.WriteMessage("\n未找到包含CL+或BL+的多行文字。");
                        return;
                    }

                    // 4.处理所有找到的文字
                    ProcessAllTexts(targetTexts, newNumber, trans);

                    trans.Commit();
                    ed.WriteMessage($"\n成功处理{targetTexts.Count}个文字对象。");
                }
                catch (System.Exception ex)
                {
                    //throw;
                    ed.WriteMessage($"\n错误: {ex.Message}");
                }
            }
        }

        private void ExplodeBlockReference(Transaction tr, BlockTableRecord modelSpace)
        {
            foreach (var objId in modelSpace)
            {
                Entity entity = tr.GetObject(objId, OpenMode.ForWrite) as Entity;
                if (entity is BlockReference blockRef)
                {
                    BlockTableRecord blockDef = (BlockTableRecord)tr.GetObject(blockRef.BlockTableRecord, OpenMode.ForWrite);
                    foreach (var objIdInBlock in blockDef)
                    {
                        Entity be = tr.GetObject(objIdInBlock, OpenMode.ForRead) as Entity;
                        if (be is MText mText && (mText.Contents.Contains("CL+") || mText.Contents.Contains("BL+")))
                        {
                            // 炸开块参照
                            blockRef.ExplodeToOwnerSpace();
                            blockRef.Erase();
                            break;
                        }
                    }
                }
            }
        }

        private void CollectTargetTexts(BlockTableRecord btr, List<MText> targetTexts, HashSet<ObjectId> processedBlocks, Transaction trans)
        {
            foreach (ObjectId id in btr)
            {
                Entity entity = trans.GetObject(id, OpenMode.ForWrite) as Entity;
                if (entity == null) continue;

                if (entity is MText mtext)
                {
                    // 检查是否包含CL+或BL+
                    string content = mtext.Contents;
                    if (content.StartsWith("CL+") || content.StartsWith("BL+"))
                    {
                        targetTexts.Add(mtext);
                    }
                }
                //else if (entity is BlockReference blockRef)
                //{
                //    // 防止无限递归
                //    if (processedBlocks.Contains(blockRef.ObjectId)) continue;
                //    processedBlocks.Add(blockRef.ObjectId);

                //    // 炸开块参照获取其中的文字
                //    DBObjectCollection explodedEntities = new DBObjectCollection();
                //    blockRef.Explode(explodedEntities);

                //    // 遍历炸开后的实体
                //    foreach (DBObject explodedObj in explodedEntities)
                //    {
                //        Entity explodedEntity = explodedObj as Entity;
                //        if (explodedEntity is MText explodedMText)
                //        {
                //            string content = explodedMText.Contents;
                //            if (content.StartsWith("CL+") || content.StartsWith("BL+"))
                //            {
                //                targetTexts.Add(explodedMText);
                //            }
                //        }

                //        // 递归处理嵌套块参照
                //        if (explodedEntity is BlockReference nestedBlockRef)
                //        {
                //            BlockTableRecord nestedBtr = trans.GetObject(nestedBlockRef.BlockTableRecord, OpenMode.ForWrite) as BlockTableRecord;
                //            CollectTargetTexts(nestedBtr, targetTexts, processedBlocks, trans);
                //        }
                //    }
                //}
            }
        }
        private double GetUserNumber(Editor ed)
        {
            PromptDoubleOptions opt = new PromptDoubleOptions("\n请输入层高: ");
            PromptDoubleResult res = ed.GetDouble(opt);

            if (res.Status == PromptStatus.OK)
                return res.Value;
            else
                return double.NaN;
        }

        private void ProcessAllTexts(List<MText> targetTexts, double newNumber, Transaction trans)
        {
            foreach (MText mtext in targetTexts)
            {
                // 以写方式打开文字对象
                mtext.UpgradeOpen();

                string originalContent = mtext.Contents;
                string prefix = originalContent.Substring(0, 3); // "CL+"或"BL+"
                string numberPart = originalContent.Substring(3);

                // 使用正则表达式匹配 BL+数字 或 CL+数字 的模式
                Match match = Regex.Match(originalContent, @"(BL|CL)\+([-+]?\d*\.?\d+)");

                // 提取数字部分
                if (match.Success)
                {
                    double oldNumber = Convert.ToDouble(match.Groups[2].Value);
                    // 计算新值
                    double result = oldNumber - newNumber;

                    string newText = originalContent.Replace(match.Groups[2].Value, result.ToString());
                    if (result < 0) newText = newText.Replace("+", ""); 
                    // 更新文字内容
                    mtext.Contents = newText;
                }
                else
                {
                    // 处理数字解析失败的情况
                    System.Diagnostics.Debug.WriteLine($"无法解析数字: {numberPart}");
                }
            }
        }
    }
}
