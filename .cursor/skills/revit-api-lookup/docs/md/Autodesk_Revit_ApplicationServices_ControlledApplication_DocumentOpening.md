---
kind: event
id: E:Autodesk.Revit.ApplicationServices.ControlledApplication.DocumentOpening
source: html/99a0bcc4-fede-b66b-198d-a53f46ecf149.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.DocumentOpening Event

Subscribe to the DocumentOpening event to be notified when Revit is just about to open a document.

## Syntax (C#)
```csharp
public event EventHandler<DocumentOpeningEventArgs> DocumentOpening
```

## Remarks
This event is raised when Revit is just about to open a document. Event is cancellable. To cancel it, call the 'Cancel()' method in event's argument to True.
 Your application is responsible for providing feedback to the user about the reason for the cancellation. The document cannot be modified, for it is not opened yet at the time of the event. Another DocumentOpened event will be raised immediately after document
 is opened.

