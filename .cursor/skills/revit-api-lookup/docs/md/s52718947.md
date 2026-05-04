---
kind: method
id: M:Autodesk.Revit.DB.ReferenceIntersector.Find(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 射线、射线相交
source: html/6abd0586-5d7e-68c6-2e64-46199f457499.htm
---
# Autodesk.Revit.DB.ReferenceIntersector.Find Method

**中文**: 射线、射线相交

Projects a ray from the origin along the given direction, and returns all references from intersected elements which match the ReferenceIntersector's criteria.

## Syntax (C#)
```csharp
public IList<ReferenceWithContext> Find(
	XYZ origin,
	XYZ direction
)
```

## Parameters
- **origin** (`Autodesk.Revit.DB.XYZ`) - The origin of the ray.
- **direction** (`Autodesk.Revit.DB.XYZ`) - The direction of the ray.

## Returns
A collection containing the intersected references.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

