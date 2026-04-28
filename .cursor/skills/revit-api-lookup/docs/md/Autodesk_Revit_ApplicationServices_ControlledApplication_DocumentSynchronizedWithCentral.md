---
kind: event
id: E:Autodesk.Revit.ApplicationServices.ControlledApplication.DocumentSynchronizedWithCentral
source: html/5cb6e92e-80b0-24e3-943c-a246566e4318.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.DocumentSynchronizedWithCentral Event

Subscribe to the DocumentSynchronizedWithCentral event to be notified immediately after Revit has finished synchronizing a document with central model.

## Syntax (C#)
```csharp
public event EventHandler<DocumentSynchronizedWithCentralEventArgs> DocumentSynchronizedWithCentral
```

## Remarks
This event is raised immediately after Revit has finished synchronizing a document with central model.
 It is raised even when document synchronizing with central model failed or was cancelled (during DocumentSynchronizingWithCentral event). 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Check the 'Status' field in event's argument to see whether the action itself was successful or not. This event is not cancellable, for the process of synchronizing a document with central model has already been finished. If the action was not successful, the document may not be modified and new transactions may not be started. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event.

