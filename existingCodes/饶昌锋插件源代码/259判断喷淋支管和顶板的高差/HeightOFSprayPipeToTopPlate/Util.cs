using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeightOFSprayPipeToTopPlate
{
    public static class Util
    {
        /// <summary>
        /// 获取中心点
        /// </summary>
        /// <param name="mEPCurve"></param>
        /// <returns></returns>
        public static XYZ GetMEPCurveCentrePoint(MEPCurve mEPCurve)
        {
            LocationCurve locationCurve = mEPCurve.Location as LocationCurve;
            Curve curve = locationCurve.Curve;
            XYZ centerPoint = curve.Evaluate(0.5, true);
            return centerPoint;
        }

        public static Transform CoordinateTransformation(Document doc)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(RevitLinkInstance));
            IEnumerable<RevitLinkInstance> linkInstances = collector.Cast<RevitLinkInstance>();
            RevitLinkInstance linkInstance = linkInstances.First();
            Transform linkTransform = linkInstance.GetTotalTransform();
            XYZ linkPosition = linkTransform.Origin;

            ProjectPosition projectPosition = doc.ActiveProjectLocation.GetProjectPosition(XYZ.Zero);

            XYZ currentPosition = new XYZ(projectPosition.EastWest, projectPosition.NorthSouth, projectPosition.Elevation);

            Transform transformFromLinkedModelToCurrentModel = Transform.CreateTranslation(currentPosition - linkPosition);

            return transformFromLinkedModelToCurrentModel;
        }

        /// <summary>
        /// 判断MEPCurve垂直或水平
        /// </summary>
        /// <param name="mEPCurve"></param>
        /// <returns> true垂直 false水平</returns>
        public static bool VerticalOHorizontal(MEPCurve mEPCurve)
        {
            Curve curve = (mEPCurve.Location as LocationCurve).Curve;
            if (curve == null) return true;
            XYZ startPoint = curve.GetEndPoint(0);
            XYZ endPoint = curve.GetEndPoint(1);
            if (Math.Abs(startPoint.Z-endPoint.Z)<0.001)
            {
                return false;
            }
            if (Math.Abs(startPoint.X-endPoint.X)<0.001 && Math.Abs(startPoint.Y - endPoint.Y) < 0.001)
            {
                return true;
            }
            return false;
        }
    }
}
