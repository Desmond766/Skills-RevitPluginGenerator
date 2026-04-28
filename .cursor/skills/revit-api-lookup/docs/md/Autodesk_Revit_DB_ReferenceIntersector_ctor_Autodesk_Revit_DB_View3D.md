---
kind: method
id: M:Autodesk.Revit.DB.ReferenceIntersector.#ctor(Autodesk.Revit.DB.View3D)
zh: 射线、射线相交
source: html/ba15191c-61f4-bf9e-72d7-d0f4976fd3f3.htm
---
# Autodesk.Revit.DB.ReferenceIntersector.#ctor Method

**中文**: 射线、射线相交

Constructs a ReferenceIntersector which is set to return intersections from all elements and representing all reference target types.

## Syntax (C#)
```csharp
public ReferenceIntersector(
	View3D view3d
)
```

## Parameters
- **view3d** (`Autodesk.Revit.DB.View3D`) - The view in which to find references.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Returns true if the view is not a view template.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

