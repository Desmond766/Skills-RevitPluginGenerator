---
kind: method
id: M:Autodesk.Revit.DB.ReferenceIntersector.#ctor(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.FindReferenceTarget,Autodesk.Revit.DB.View3D)
zh: 射线、射线相交
source: html/80392f86-eab8-7485-6e5a-28d4e40f7528.htm
---
# Autodesk.Revit.DB.ReferenceIntersector.#ctor Method

**中文**: 射线、射线相交

Constructs a ReferenceIntersector which is set to return intersections from a single target element only.

## Syntax (C#)
```csharp
public ReferenceIntersector(
	ElementId targetElementId,
	FindReferenceTarget targetType,
	View3D view3d
)
```

## Parameters
- **targetElementId** (`Autodesk.Revit.DB.ElementId`) - The target element id.
- **targetType** (`Autodesk.Revit.DB.FindReferenceTarget`) - The target type of references to return.
- **view3d** (`Autodesk.Revit.DB.View3D`) - The view in which to find references.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Returns true if the view is not a view template.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

