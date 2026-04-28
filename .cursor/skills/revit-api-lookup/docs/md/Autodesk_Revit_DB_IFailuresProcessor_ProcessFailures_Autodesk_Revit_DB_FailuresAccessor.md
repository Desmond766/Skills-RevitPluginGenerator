---
kind: method
id: M:Autodesk.Revit.DB.IFailuresProcessor.ProcessFailures(Autodesk.Revit.DB.FailuresAccessor)
source: html/99bd820d-03a3-e434-f780-656a37e62f57.htm
---
# Autodesk.Revit.DB.IFailuresProcessor.ProcessFailures Method

Method that Revit will invoke to process failures at the end of transaction.

## Syntax (C#)
```csharp
FailureProcessingResult ProcessFailures(
	FailuresAccessor data
)
```

## Parameters
- **data** (`Autodesk.Revit.DB.FailuresAccessor`) - Provides all necessary data to perform the resolution of failures.

## Returns
The result of the failures processing.
 Continue - Should be returned if there were no failures or highest failure severity was "Warning" and all warnings were deleted.
 If some failures are still present and "Continue" is returned, it will be treated as "ProceedWithRollback".
 Note: If this method has attempted to resolve failures, it should return "ProceedWithCommit"
 to repeat end of transaction checks and failures processing. ProceedWithCommit - End of transaction checks and failure processing will restart from the beginning.
 If some failures were resolved, they will be removed and not delivered to the user.
 ProceedWithCommit cannot be returned if transaction is being rolled back. ProceedWithRollBack - Transaction will be rolled back even if Commit was originally requested. WaitForUserInput - Should be returned if method has activated modeless user interaction and is waiting for an external event
 (typically user input) to complete failures processing.

## Remarks
This method is invoked after some failures may have been handled by any FailuresPreprocessor
 and/or FailureProcessing event subscribers.

