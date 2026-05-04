---
kind: property
id: P:Autodesk.Revit.DB.GeometryObject.Visibility
source: html/b504868c-1588-3488-8cdf-d8e45ef23fa0.htm
---
# Autodesk.Revit.DB.GeometryObject.Visibility Property

The visibility.

## Syntax (C#)
```csharp
public Visibility Visibility { get; set; }
```

## Remarks
The visibility of this object has no effect on the visibility of objects contained within this object.
For example, the visibility of a Solid may be Contextual but the faces within that solid may still be Visible.

