---
kind: enumMember
id: F:Autodesk.Revit.DB.FailureProcessingResult.ProceedWithRollBack
enum: Autodesk.Revit.DB.FailureProcessingResult
source: html/f147e6e6-4b2e-d61c-df9b-8b8e5ebe3fcb.htm
---
# Autodesk.Revit.DB.FailureProcessingResult.ProceedWithRollBack

This value should be returned if the transaction was originally requested to be committed and
 the failure handler requires it to be rolled back instead.
 In order to rollback silently, before ProceedWithRollBack is returned the failure handler should
 set the FailureHandlingOptions to clear errors after rollback. This will cause all failures
 to be deleted. If this is not set, default failure processing will continue, and
 failures may be delivered to the user even though the transaction will be rolled back.

