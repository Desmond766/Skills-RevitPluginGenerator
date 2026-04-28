---
kind: enumMember
id: F:Autodesk.Revit.DB.FailureProcessingResult.WaitForUserInput
enum: Autodesk.Revit.DB.FailureProcessingResult
source: html/f147e6e6-4b2e-d61c-df9b-8b8e5ebe3fcb.htm
---
# Autodesk.Revit.DB.FailureProcessingResult.WaitForUserInput

This value should only be returned by a FailuresProcessor - and only if it is waiting for something to happen externally.
 Typically this would be some sort of user input needed to complete failures processing.
 If this value is set from any other processor, it will be treated as ProceedWithRollback.

