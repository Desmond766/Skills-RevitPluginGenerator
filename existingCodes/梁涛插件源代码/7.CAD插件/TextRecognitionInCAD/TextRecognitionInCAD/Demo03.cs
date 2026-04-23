using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRecognitionInCAD
{
    public class Demo03 // 测试用 显示鼠标框选范围
    {
        [CommandMethod("DRAWR")]
        public void DrawRect()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = acDoc.Editor;
            Database acCurDb = acDoc.Database;
            PromptPointResult pPtRes;
            PromptPointOptions pPtOpts = new PromptPointOptions("");

            pPtOpts.Message = "\n框选一个范围: ";
            pPtRes = acDoc.Editor.GetPoint(pPtOpts);
            Point3d ptStart = pPtRes.Value;

            if (pPtRes.Status == PromptStatus.OK)
            {
                RectJig rectJig = new RectJig(ptStart);
                PromptResult PR = acDoc.Editor.Drag(rectJig);
                if (PR.Status == PromptStatus.OK)
                {
                    //CADDraw.AddEntity(acCurDb, rectJig.line_1);
                    //CADDraw.AddEntity(acCurDb, rectJig.line_2);
                    //CADDraw.AddEntity(acCurDb, rectJig.line_3);
                    //CADDraw.AddEntity(acCurDb, rectJig.line_4);
                    ed.WriteMessage($"\n起点坐标：{rectJig.BasePnt}\n终点坐标：{rectJig.AcquirePnt}");
                }

            }
        }
    }
}
