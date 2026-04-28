---
kind: type
id: T:Autodesk.Revit.DB.Events.FailuresProcessingEventArgs
source: html/a35dc3de-c8a4-8af0-6a3c-706716e5f885.htm
---
# Autodesk.Revit.DB.Events.FailuresProcessingEventArgs

The event arguments used by the FailuresProcessing event.

## Syntax (C#)
```csharp
public class FailuresProcessingEventArgs : RevitAPISingleEventArgs
```

## Remarks
The event arguments provide access to the FailuresAccessor via GetFailuresAccessor () () () 
 which contains the details of the errors and/or warnings that caused the event to trigger. The arguments also allow you to set a processing result
 via SetProcessingResult(FailureProcessingResult) . The processing result determines if Revit will attempt to
 recommit the currently failing transaction, roll it back, or continue. If you are explicitly
 dismissing warnings from the event callback, a processing result of Continue is sufficient. But if you
 are explicitly resolving errors from the event callback, you must change the processing result to ProceedWithCommit
 to ensure that the user is not shown the dismissed errors. If you wish to cancel the transaction
 silently without showing the errors to the user, set the processing result to ProceedWithRollback, however
 you must also call SetClearAfterRollback(Boolean) in
 order to dismiss the errors and silently cancel the transaction.

