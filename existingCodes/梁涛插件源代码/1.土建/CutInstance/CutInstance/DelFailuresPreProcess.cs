using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutInstance
{
    public class DelFailuresPreProcess : IFailuresPreprocessor
    {
        public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
        {
            var failureMessages = failuresAccessor.GetFailureMessages();
            foreach (var failure in failureMessages)
            {
                if (failure.GetSeverity() == FailureSeverity.Error)
                {
                    //if (failuresAccessor.IsElementsDeletionPermitted(failure.GetFailingElementIds().ToList()))
                    //{
                    //    failuresAccessor.DeleteElements(new ElementId[] { failure.GetFailingElementIds().OrderByDescending(x => x.IntegerValue).First() });
                    //    TaskDialog.Show("revit", failure.GetFailingElementIds().Count.ToString());
                    //}
                    failuresAccessor.RollBackPendingTransaction();
                    failuresAccessor.ResolveFailure(failure);
                }
            }
            return FailureProcessingResult.Continue;
        }

        [Description("这个方法用在事务开始前，在FailureHandler初始化后调用")]
        /// <summary>
        /// 这个方法用在事务开始前，在FailureHandler初始化后调用
        /// </summary>
        public static void SetFailedHandlerBeforeTransaction(IFailuresPreprocessor failureHandler, Transaction transaction)
        {
            FailureHandlingOptions failureHandlingOptions = transaction.GetFailureHandlingOptions();
            failureHandlingOptions.SetFailuresPreprocessor(failureHandler);
            // 这句话是关键  
            transaction.SetFailureHandlingOptions(failureHandlingOptions);
        }
    }
}
