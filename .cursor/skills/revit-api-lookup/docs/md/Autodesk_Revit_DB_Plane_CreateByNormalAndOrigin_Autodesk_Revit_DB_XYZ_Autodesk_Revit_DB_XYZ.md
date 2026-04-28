---
kind: method
id: M:Autodesk.Revit.DB.Plane.CreateByNormalAndOrigin(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/ab735815-f6bc-aae1-8afc-8505bba18cb5.htm
---
# Autodesk.Revit.DB.Plane.CreateByNormalAndOrigin Method

Constructs a Plane object from a normal and an origin represented as XYZ objects. Follows the standard conventions for a planar surface.
 The constructed Plane object will pass through origin and be perpendicular to normal. The X and Y axes of the plane will be defined arbitrarily.

## Syntax (C#)
```csharp
public static Plane CreateByNormalAndOrigin(
	XYZ normal,
	XYZ origin
)
```

## Parameters
- **normal** (`Autodesk.Revit.DB.XYZ`) - Plane normal. Expected to be a valid non-zero length vector. Doesn't need to be a unit vector.
- **origin** (`Autodesk.Revit.DB.XYZ`) - Plane origin. Expected to lie within the Revit design limits IsWithinLengthLimits(XYZ) .

## Remarks
This function does not guarantee a specific parameterization of the created Plane. Use Plane.Create(Frame) to enforce a specific parameterization of the created Plane object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input point lies outside of Revit design limits.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - normal has zero length.

