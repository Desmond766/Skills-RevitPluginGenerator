using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicModelUpdate
{
    public class MyUpdater : IUpdater
    {

       private readonly AddInId _addInId;
        public MyUpdater(AddInId addInId)
        {
            this._addInId = addInId;
        }

        public void Execute(UpdaterData data)
        {
            var modifiedIds=data.GetModifiedElementIds();
            if(modifiedIds.Count>0 )
            {
                var element = data.GetDocument().GetElement(modifiedIds.First());
                using (SubTransaction sub = new SubTransaction(data.GetDocument()))
                {
                    sub.Start();
                    sub.Commit();
                }
            }
            throw new NotImplementedException();
        }

        public string GetAdditionalInformation() => "";

        public ChangePriority GetChangePriority() => ChangePriority.GridsLevelsReferencePlanes;

        public UpdaterId GetUpdaterId() => new UpdaterId(_addInId,new Guid("1D6A97F4-FCD8-4F6C-8706-991D931BC873"));

        public string GetUpdaterName() => "";
    }
}
