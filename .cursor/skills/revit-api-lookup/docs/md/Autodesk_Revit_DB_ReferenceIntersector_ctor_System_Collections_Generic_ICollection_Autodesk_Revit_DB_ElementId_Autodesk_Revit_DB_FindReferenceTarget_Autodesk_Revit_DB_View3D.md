---
kind: method
id: M:Autodesk.Revit.DB.ReferenceIntersector.#ctor(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.FindReferenceTarget,Autodesk.Revit.DB.View3D)
zh: 射线、射线相交
source: html/4b624cc1-fc7f-62dd-3593-22861c991afd.htm
---
# Autodesk.Revit.DB.ReferenceIntersector.#ctor Method

**中文**: 射线、射线相交

Constructs a ReferenceIntersector which is set to return intersections from any of a set of target elements.

## Syntax (C#)
```csharp
public ReferenceIntersector(
	ICollection<ElementId> targetElementIds,
	FindReferenceTarget targetType,
	View3D view3d
)
```

## Parameters
- **targetElementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The target element ids.
- **targetType** (`Autodesk.Revit.DB.FindReferenceTarget`) - The target type of references to return.
- **view3d** (`Autodesk.Revit.DB.View3D`) - The view in which to find references.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Returns true if the view is not a view template.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

