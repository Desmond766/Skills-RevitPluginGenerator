---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.FailuresProcessing
source: html/446796ca-d8f5-0f8a-7b82-a4ec6e5aa7a0.htm
---
# Autodesk.Revit.ApplicationServices.Application.FailuresProcessing Event

Subscribe to the FailuresProcessing event to be notified when failures are being processed at the end of transaction.

## Syntax (C#)
```csharp
public event EventHandler<FailuresProcessingEventArgs> FailuresProcessing
```

## Remarks
This event is raised when failures are being processed during transaction commit or rollback operations.
 Handlers of this event have a limited ability to modify the document and/or failures in it, using the provided
 restricted failures accessor interface. The event arguments provide access to the FailuresAccessor via
 [!:Autodesk::Revit::DB::FailuresProcessingEventArgs::GetFailuresAccessor()] 
 which contains the details of the errors and/or warnings that caused the event to trigger. The arguments also allow you to set a processing result via
 [!:Autodesk::Revit::DB::FailuresProcessingEventArgs::SetProcessingResult()] . The processing
 result determines if Revit will attempt to recommit the currently failing transaction, roll it back, or continue.
 If you are explicitly dismissing warnings from the event callback, a processing result of Continue
 is sufficient. But if you are explicitly resolving errors from the event callback, you must change the
 processing result to ProceedWithCommit to ensure that the user is not shown the dismissed errors. If you
 wish to cancel the transaction silently without showing the errors to the user, set the processing result to
 ProceedWithRollback, however you must also call
 SetClearAfterRollback(Boolean) in
 order to dismiss the errors and silently cancel the transaction.

