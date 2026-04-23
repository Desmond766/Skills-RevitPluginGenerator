using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batchlink
{
    public static class DocumentExtension
    {
        public static void NewTransaction(this Document doc, string name, Action action)
        {
            using (Transaction tran = new Transaction(doc, name))
            {
                tran.Start();
                action();
                tran.Commit();
            }
        }
    }
}
