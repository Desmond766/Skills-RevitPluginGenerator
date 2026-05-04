---
kind: method
id: M:Autodesk.Revit.DB.ReferenceIntersector.FindNearest(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 射线、射线相交
source: html/866e1f2b-c79a-4d9f-1db1-9e386dd42941.htm
---
# Autodesk.Revit.DB.ReferenceIntersector.FindNearest Method

**中文**: 射线、射线相交

Projects a ray from the origin along the given direction, and returns the nearest reference from intersected elements which match the ReferenceIntersector's criteria.

## Syntax (C#)
```csharp
public ReferenceWithContext FindNearest(
	XYZ origin,
	XYZ direction
)
```

## Parameters
- **origin** (`Autodesk.Revit.DB.XYZ`) - The origin of the ray.
- **direction** (`Autodesk.Revit.DB.XYZ`) - The direction of the ray.

## Returns
The intersected reference nearest to the ray origin, Nothing nullptr a null reference ( Nothing in Visual Basic) if none is found

## Remarks
Note that FindNearest() is a convenience method, and other references that may be nearly the same distance from the origin can be obtained from Find(XYZ, XYZ) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

