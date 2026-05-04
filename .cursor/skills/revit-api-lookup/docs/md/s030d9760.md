---
kind: event
id: E:Autodesk.Revit.ApplicationServices.ControlledApplication.DocumentClosed
source: html/b089cc05-ba85-03c2-e256-9f18ca7affc9.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.DocumentClosed Event

Subscribe to the DocumentClosing event to be notified when Revit is just about to close a document.

## Syntax (C#)
```csharp
public event EventHandler<DocumentClosedEventArgs> DocumentClosed
```

## Remarks
This event is raised immediately after Revit has finished closing a document.
 It is raised even when document closing failed or was cancelled (during DocumentClosing event). This event is not cancellable, for the process of closing document has already been finished. The document cannot be modified because the corresponding object does not exist anymore.

