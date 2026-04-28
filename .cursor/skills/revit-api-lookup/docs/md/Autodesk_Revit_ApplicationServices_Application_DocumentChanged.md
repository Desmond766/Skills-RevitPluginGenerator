---
kind: event
id: E:Autodesk.Revit.ApplicationServices.Application.DocumentChanged
source: html/988dd6cf-fcaa-85d2-622d-c50f13917a13.htm
---
# Autodesk.Revit.ApplicationServices.Application.DocumentChanged Event

Subscribe to the DocumentChanged event to be notified when Revit document has changed.

## Syntax (C#)
```csharp
public event EventHandler<DocumentChangedEventArgs> DocumentChanged
```

## Remarks
This event is raised whenever a Revit transaction is either committed, undone or redone.
 This is a readonly event, designed to allow you to keep external data in synch with the state of the
 Revit database.
 To update the Revit database in response to changes in elements, use the IUpdater framework.

