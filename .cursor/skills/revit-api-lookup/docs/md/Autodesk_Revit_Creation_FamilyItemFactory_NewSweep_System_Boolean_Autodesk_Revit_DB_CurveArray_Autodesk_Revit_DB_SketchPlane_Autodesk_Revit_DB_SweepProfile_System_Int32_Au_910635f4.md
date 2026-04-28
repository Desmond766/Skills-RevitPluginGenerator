---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewSweep(System.Boolean,Autodesk.Revit.DB.CurveArray,Autodesk.Revit.DB.SketchPlane,Autodesk.Revit.DB.SweepProfile,System.Int32,Autodesk.Revit.DB.ProfilePlaneLocation)
source: html/66fbaa58-1394-df12-7b50-f0ef50b2be44.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewSweep Method

Adds a new sweep form to the family document, using a path of curve elements.

## Syntax (C#)
```csharp
public Sweep NewSweep(
	bool isSolid,
	CurveArray path,
	SketchPlane pathPlane,
	SweepProfile profile,
	int profileLocationCurveIndex,
	ProfilePlaneLocation profilePlaneLocation
)
```

## Parameters
- **isSolid** (`System.Boolean`) - Indicates if the Sweep is Solid or Void.
- **path** (`Autodesk.Revit.DB.CurveArray`) - The path of the sweep. The path should be 2D, where all input curves lie in one plane, and the curves are not 
required to reference existing geometry.
- **pathPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plane for the path. Use this when you want to create 
a 2D path that resides on an existing planar face. Optional, can be Nothing nullptr a null reference ( Nothing in Visual Basic) for 3D paths or 
for 2D paths where the path should not reference an existing face.
- **profile** (`Autodesk.Revit.DB.SweepProfile`) - The profile of the newly created Sweep. This may contain
more than one curve loop or a profile family. The profile must lie in the XY plane, and it will be 
transformed to the profile plane automatically. Each loop must be a fully closed curve loop and the loops 
must not intersect.
The loop can be a unbound circle or ellipse, but its geometry will be split in two in 
order to satisfy requirements for sketches used in extrusions.
- **profileLocationCurveIndex** (`System.Int32`) - The index of the path curves. The curve upon which the profile
plane will be determined.
- **profilePlaneLocation** (`Autodesk.Revit.DB.ProfilePlaneLocation`) - The location on the profileLocationCurve where the profile
plane will be determined.

## Returns
If creation was successful the new Sweep is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
This method creates a sweep in a family document. The sweep will trace the profile along the path.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-path-is Nothing nullptr a null reference ( Nothing in Visual Basic) or empty.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-profile-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the input argument-profileLocationCurveIndex-is out of index bounds.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the input argument-profilePlaneLocation-does not exist in the ProfilePlaneLocation enumeration.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when creation is attempted in Conceptual Mass, 2D, or other family where sweeps cannot be created.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

