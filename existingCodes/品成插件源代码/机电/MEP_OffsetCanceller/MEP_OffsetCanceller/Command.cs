using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.IO;

namespace MEP_OffsetCanceller
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }
            #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            try
            {
                while (true)
                {

                    //拾取翻起部分的水平管线
                    Reference r = sel.PickObject(ObjectType.Element, "拾取翻弯部分的水平管线");
                    Element elem = doc.GetElement(r);
                    if (elem is MEPCurve)
                    {
                        Resolver resolver = new Resolver(commandData);
                        using (Transaction t = new Transaction(doc, "取消翻弯"))
                        {
                            t.Start();
                            resolver.Resolve(r);
                            t.Commit();

                        }
                    }
                    else if (elem is FamilyInstance)
                    {
                        ConnectorSet connSet =Utils.GetConSet(elem);
                        List<Connector> connList = Utils.GetConList(connSet);
                       
                        if (connList.Count==3)//三通
                        {
                            bool b1 = Utils.IsAlmostEqual(connList[0].Origin.Z, connList[1].Origin.Z);
                            bool b2 = Utils.IsAlmostEqual(connList[0].Origin.Z, connList[2].Origin.Z);
                            if (b1 == true && b2 == true)//水平三通
                            {
                                ResolverForHorTee resolverForHorTee = new ResolverForHorTee(commandData);
                                using (Transaction t = new Transaction(doc, "取消水平三通翻弯"))
                                {
                                    t.Start();
                                    resolverForHorTee.Resolver(r);
                                    t.Commit();
                                }
                            }
                            else//垂直三通
                            {
                                ResolverForVerTee resolverForVerTee = new ResolverForVerTee(commandData);
                                using (Transaction t = new Transaction(doc, "取消垂直三通翻弯"))
                                {
                                    t.Start();
                                    resolverForVerTee.Resolver(r);
                                    t.Commit();
                                }
                                
                            }
                        }
                        if (connList.Count == 4)//四通
                        {
                            ResolverForCross resolverForCross = new ResolverForCross(commandData);
                            using (Transaction t = new Transaction(doc, "取消四通翻弯"))
                            {
                                t.Start();
                                resolverForCross.Resolver(r);
                                t.Commit();
                            }
                        }
                       

                    }


                }
            }
            catch
            {
            }


            return Result.Succeeded;
        }
    }
}
