---
kind: method
id: M:Autodesk.Revit.DB.BooleanOperationsUtils.CutWithHalfSpaceModifyingOriginalSolid(Autodesk.Revit.DB.Solid,Autodesk.Revit.DB.Plane)
source: html/ba309158-59c7-465a-1d50-985cf74b3918.htm
---
# Autodesk.Revit.DB.BooleanOperationsUtils.CutWithHalfSpaceModifyingOriginalSolid Method

Modifies the input Solid preserving only the volume on the positive side of the given Plane. The positive side of the plane is the side to which Plane.Normal points.

## Syntax (C#)
```csharp
public static void CutWithHalfSpaceModifyingOriginalSolid(
	Solid solid,
	Plane plane
)
```

## Parameters
- **solid** (`Autodesk.Revit.DB.Solid`) - The input Solid to be cut. This object cannot be obtained directly from a Revit element.
 This means that IsElementGeometry cannot be true.
- **plane** (`Autodesk.Revit.DB.Plane`) - The cut plane. The space on the positive side of the normal of the plane will be intersected with the input Solid.

## Remarks
This operation modifies the original input Geometry objects.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the original solid object is the geometry of the Revit model.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

