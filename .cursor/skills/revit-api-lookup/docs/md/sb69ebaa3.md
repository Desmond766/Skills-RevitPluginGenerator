---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.DocumentSynchronizingWithCentral
source: html/3587a871-b667-7a2a-89e9-8601460c2cec.htm
---
# Autodesk.Revit.ApplicationServices.Application.DocumentSynchronizingWithCentral Event

Subscribe to the DocumentSynchronizingWithCentral event to be notified when Revit is just about to synchronize a document with central model.

## Syntax (C#)
```csharp
public event EventHandler<DocumentSynchronizingWithCentralEventArgs> DocumentSynchronizingWithCentral
```

## Remarks
This event is raised when Revit is just about to synchronize a document with central model. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.
 Event is cancellable. To cancel it, call the 'Cancel()' method in event's argument to True.
 Your application is responsible for providing feedback to the user about the reason for the cancellation. The following API functions are not available for the current document during this event:
 Close () () () and similar overloads. Save () () () . SaveAs(String) and similar overloads. Exception InvalidOperationException will be thrown if any of the above methods is called during this event. Another DocumentSynchronizedWithCentral event will be raised immediately after document synchronizing with central model
 is finished.

