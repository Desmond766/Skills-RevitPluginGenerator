---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.DocumentWorksharingEnabled
source: html/51879d12-03fd-0360-d6e1-ce1dcbccbe2d.htm
---
# Autodesk.Revit.ApplicationServices.Application.DocumentWorksharingEnabled Event

Subscribe to the DocumentWorksharingEnabled event to be notified when a document has become workshared.

## Syntax (C#)
```csharp
public event EventHandler<DocumentWorksharingEnabledEventArgs> DocumentWorksharingEnabled
```

## Remarks
This event is raised when Revit has just enabled worksharing in the document. 
 Handlers of this event are permitted to make modifications to any document (including the active document),
 except for documents that are currently in read-only mode.

