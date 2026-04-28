---
kind: method
id: M:Autodesk.Revit.DB.Plane.CreateByThreePoints(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/a18aa7a2-71b6-5fa2-8ca8-abadedb638d7.htm
---
# Autodesk.Revit.DB.Plane.CreateByThreePoints Method

Creates a Plane object passing through three points supplied as arguments.

## Syntax (C#)
```csharp
public static Plane CreateByThreePoints(
	XYZ point1,
	XYZ point2,
	XYZ point3
)
```

## Parameters
- **point1** (`Autodesk.Revit.DB.XYZ`) - First of the three points that define a unique plane. The created Plane object will pass through these points.
- **point2** (`Autodesk.Revit.DB.XYZ`) - Second of the three points that define a unique plane.
- **point3** (`Autodesk.Revit.DB.XYZ`) - Third of the three points that define a unique plane.

## Remarks
The points supplied as arguments must fully define a plane: they may not lie on a straight line or be too close to each other. The points must lie within the Revit design limits.
 This function does not guarantee a specific parameterization of the created Plane. Use Plane.Create(Frame) to enforce a specific parameterization of the created Plane object.
 All three points are expected to lie within the Revit design limits IsWithinLengthLimits(XYZ) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input point lies outside of Revit design limits.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Throws if the input points do not define a unique plane.
 This is typically caused by points being too close to each other, or all three points being on or close to a straight line.

