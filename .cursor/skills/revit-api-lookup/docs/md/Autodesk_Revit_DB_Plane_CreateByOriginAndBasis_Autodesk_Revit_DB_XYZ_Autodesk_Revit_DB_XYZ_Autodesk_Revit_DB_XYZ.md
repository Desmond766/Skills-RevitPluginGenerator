---
kind: method
id: M:Autodesk.Revit.DB.Plane.CreateByOriginAndBasis(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/425db4fe-1368-0a48-6fb0-9c458035ea6a.htm
---
# Autodesk.Revit.DB.Plane.CreateByOriginAndBasis Method

Creates a Plane object defined by the two orthogonal unit vectors and passing through the origin point supplied as arguments.

## Syntax (C#)
```csharp
public static Plane CreateByOriginAndBasis(
	XYZ origin,
	XYZ basisX,
	XYZ basisY
)
```

## Parameters
- **origin** (`Autodesk.Revit.DB.XYZ`) - Plane origin. Expected to lie within the Revit design limits IsWithinLengthLimits(XYZ) .
- **basisX** (`Autodesk.Revit.DB.XYZ`) - First of the two unit vectors that define the plane. Must be orthogonal to the second one.
- **basisY** (`Autodesk.Revit.DB.XYZ`) - Second of the two unit vectors that define the plane. Must be orthogonal to the first one.

## Remarks
The parametric equation of the plane is S(u, v) = origin + u*basisX + v*basisY. The plane's normal is defined as basisX.Cross(basisY).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input point lies outside of Revit design limits.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - basisX is not length 1.0.
 -or-
 basisY is not length 1.0.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The vectors basisX and basisY are not perpendicular.

