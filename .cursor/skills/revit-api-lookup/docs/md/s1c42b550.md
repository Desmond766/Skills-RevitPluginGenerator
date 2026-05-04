---
kind: property
id: P:Autodesk.Revit.DB.HomeCamera.ViewId
source: html/305e7397-71c4-8e01-2ece-06c0d7453873.htm
---
# Autodesk.Revit.DB.HomeCamera.ViewId Property

The id of the view which is associated to this document's Home view orientation.

## Syntax (C#)
```csharp
public ElementId ViewId { get; }
```

## Remarks
A view can be associated to the document's Home view orientation by the View Cube menu option "Set Current View as Home".
 Only one view is associated to the Home view orientation at any given time in the document.

