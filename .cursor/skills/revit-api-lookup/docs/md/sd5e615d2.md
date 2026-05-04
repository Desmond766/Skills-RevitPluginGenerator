---
kind: enumMember
id: F:Autodesk.Revit.DB.FailureProcessingResult.ProceedWithCommit
enum: Autodesk.Revit.DB.FailureProcessingResult
source: html/f147e6e6-4b2e-d61c-df9b-8b8e5ebe3fcb.htm
---
# Autodesk.Revit.DB.FailureProcessingResult.ProceedWithCommit

This value should be used if some or all failures were resolved by the handler. It instructs the Revit
 failure processing/transaction mechanism to try to repeat the transaction committing process.
 Despite the request to commit to the transaction, there is no guarantee that the commit will succeed.
 If errors remain unresolved the handler will likely be called again. Handler
 code should be careful not to try to repeatedly commit if it is unable to deal with all the errors.
 ProceedWithCommit cannot be used if the transaction is already being rolled back, and will be treated as ProceedWithRollBack in this case.

