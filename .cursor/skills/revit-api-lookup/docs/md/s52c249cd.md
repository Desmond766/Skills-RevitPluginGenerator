---
kind: enumMember
id: F:Autodesk.Revit.DB.FailureProcessingResult.Continue
enum: Autodesk.Revit.DB.FailureProcessingResult
source: html/f147e6e6-4b2e-d61c-df9b-8b8e5ebe3fcb.htm
---
# Autodesk.Revit.DB.FailureProcessingResult.Continue

This value should be used if no action was taken and/or caller should continue with default failure processing for the
 open transaction. In the absence of any other available handlers, this means that the Revit user interface will
 display any errors to the user for resolution. (Warnings will not be displayed if they have been deleted already
 by the failure handler).
 If a FailuresProcessor returns Continue with unresolved failures, Revit will instead act as if ProceedWithRollBack was returned.

