---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewSweptBlend(System.Boolean,Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.SketchPlane,Autodesk.Revit.DB.SweepProfile,Autodesk.Revit.DB.SweepProfile)
source: html/a2c58574-95a4-594d-d47b-a07db91d9621.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewSweptBlend Method

Add a new swept blend into the family document, using a curve as the path.

## Syntax (C#)
```csharp
public SweptBlend NewSweptBlend(
	bool isSolid,
	Curve path,
	SketchPlane pathPlane,
	SweepProfile bottomProfile,
	SweepProfile topProfile
)
```

## Parameters
- **isSolid** (`System.Boolean`) - Indicates if the swept blend is Solid or Void.
- **path** (`Autodesk.Revit.DB.Curve`) - The path of the swept blend. The path should be a single curve.
Or the path can be a single sketched curve, and the curve is not required to reference existing geometry.
- **pathPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plane for the path. Use this when you want to create 
a 2D path that resides on an existing planar face. Optional, can be Nothing nullptr a null reference ( Nothing in Visual Basic) for a path curve obtained from geometry or 
for 2D paths where the path should not reference an existing edge.
- **bottomProfile** (`Autodesk.Revit.DB.SweepProfile`) - The bottom profile of the newly created Swept blend. It should consist of only one curve loop.
The profile must lie in the XY plane, and it will be transformed to the profile plane automatically.
- **topProfile** (`Autodesk.Revit.DB.SweepProfile`) - The top profile of the newly created Swept blend. It should consist of only one curve loop.
The profile must lie in the XY plane, and it will be transformed to the profile plane automatically.

## Returns
If creation was successful the new Swept blend is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
This method creates a swept blend in a family document. The swept blend will trace from bottom profile 
to the top along the path. Revit will determine an appropriate default mapping for the vertices of the 
two profiles. If the input profile is to be a cyclic profile (curve or ellipse) it must be split into at
least two segments, so that Revit can find vertices to use for mapping the swept blend.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input arguments-path/bottomProfile/topProfile-are Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-bottomProfile/topProfile-is a curve based profile and the profile
is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-bottomProfile/topProfile-is a curve based profile and the profile
contains Nothing nullptr a null reference ( Nothing in Visual Basic) or more than one curve loops.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-bottomProfile/topProfile-is a family symbol based profile and the 
family symbol profile is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when creation is attempted in Conceptual Mass, 2D, or other family where swept blends cannot be created.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

