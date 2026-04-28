---
kind: method
id: M:Autodesk.Revit.DB.GeometryCreationUtilities.CreateExtrusionGeometry(System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop},Autodesk.Revit.DB.XYZ,System.Double,Autodesk.Revit.DB.SolidOptions)
source: html/f72829bc-7108-1e8a-01e1-09c43bc275a9.htm
---
# Autodesk.Revit.DB.GeometryCreationUtilities.CreateExtrusionGeometry Method

Creates a solid by linearly extruding one or more closed coplanar curve loops.

## Syntax (C#)
```csharp
public static Solid CreateExtrusionGeometry(
	IList<CurveLoop> profileLoops,
	XYZ extrusionDir,
	double extrusionDist,
	SolidOptions solidOptions
)
```

## Parameters
- **profileLoops** (`System.Collections.Generic.IList < CurveLoop >`) - The profile loops to be extruded. The loops must be closed, coplanar, and without intersections, self-intersections, or degeneracies. No loop may contain just one closed curve - split such loops into two or more curves beforehand.
 No conditions are imposed on the orientations of the loops: this function will use copies of the input loops that have been oriented as necessary to conform to Revit's orientation conventions.
- **extrusionDir** (`Autodesk.Revit.DB.XYZ`) - The direction in which to extrude the profile loops. This vector must be non-zero and transverse
 (i.e., not parallel) to the plane of the profile loops. Its length is irrelevant; only its direction is used.
- **extrusionDist** (`System.Double`) - The positive distance by which the loops are to be extruded in the direction of the input extrusionDir.
- **solidOptions** (`Autodesk.Revit.DB.SolidOptions`) - The optional information to control the properties of the Solid.

## Returns
The requested solid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The profile CurveLoops do not satisfy the input requirements.
 -or-
 The Input extrusionDir must be a non-zero vector.
 The normal of the loop plane should not be perpendicular to the given extrusionDir.
 -or-
 The input argument extrusionDist must be positive.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

