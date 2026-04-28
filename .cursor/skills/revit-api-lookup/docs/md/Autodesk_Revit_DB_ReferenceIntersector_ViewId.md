---
kind: property
id: P:Autodesk.Revit.DB.ReferenceIntersector.ViewId
zh: 射线、射线相交
source: html/502978f2-9efb-02a9-ab6e-f54eafbe6c10.htm
---
# Autodesk.Revit.DB.ReferenceIntersector.ViewId Property

**中文**: 射线、射线相交

The id of the 3D view used for evaluation.

## Syntax (C#)
```csharp
public ElementId ViewId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: viewId is not the id of a 3D view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

