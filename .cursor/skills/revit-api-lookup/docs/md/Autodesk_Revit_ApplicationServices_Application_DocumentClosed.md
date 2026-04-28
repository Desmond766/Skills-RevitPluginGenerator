---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.DocumentClosed
source: html/d6c0ea53-175c-75b5-4e0e-9b3d5ba92f06.htm
---
# Autodesk.Revit.ApplicationServices.Application.DocumentClosed Event

Subscribe to the DocumentClosing event to be notified when Revit is just about to close a document.

## Syntax (C#)
```csharp
public event EventHandler<DocumentClosedEventArgs> DocumentClosed
```

## Remarks
This event is raised immediately after Revit has finished closing a document.
 It is raised even when document closing failed or was cancelled (during DocumentClosing event). This event is not cancellable, for the process of closing document has already been finished. The document cannot be modified because the corresponding object does not exist anymore.

