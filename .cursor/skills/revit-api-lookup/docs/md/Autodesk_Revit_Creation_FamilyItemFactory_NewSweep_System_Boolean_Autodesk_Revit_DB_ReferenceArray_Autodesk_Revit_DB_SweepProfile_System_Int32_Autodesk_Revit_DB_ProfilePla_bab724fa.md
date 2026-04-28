---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewSweep(System.Boolean,Autodesk.Revit.DB.ReferenceArray,Autodesk.Revit.DB.SweepProfile,System.Int32,Autodesk.Revit.DB.ProfilePlaneLocation)
source: html/4f1527ca-5b2b-633c-c3b6-ff863340ab51.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewSweep Method

Adds a new sweep form into the family document, using an array of selected references as a 3D path.

## Syntax (C#)
```csharp
public Sweep NewSweep(
	bool isSolid,
	ReferenceArray path,
	SweepProfile profile,
	int profileLocationCurveIndex,
	ProfilePlaneLocation profilePlaneLocation
)
```

## Parameters
- **isSolid** (`System.Boolean`) - Indicates if the Sweep is Solid or Void.
- **path** (`Autodesk.Revit.DB.ReferenceArray`) - The path of the sweep. The path should be reference of curve or edge obtained from existing geometry.
- **profile** (`Autodesk.Revit.DB.SweepProfile`) - The profile to create the new Sweep. The profile must lie in the XY plane, and it will be 
transformed to the profile plane automatically. This may contain more than one curve loop or a profile family. 
Each loop must be a fully closed curve loop and the loops must not intersect.
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
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-path-is Nothing nullptr a null reference ( Nothing in Visual Basic) or empty or an unsupported curve type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-profile-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the input argument-profileLocationCurveIndex-is out of index bounds.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the input argument-profilePlaneLocation-does not exist in the ProfilePlaneLocation enumeration.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

