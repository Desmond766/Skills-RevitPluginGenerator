---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewBlend(System.Boolean,Autodesk.Revit.DB.CurveArray,Autodesk.Revit.DB.CurveArray,Autodesk.Revit.DB.SketchPlane)
source: html/00173a0d-6075-0270-fd7e-080da420d339.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewBlend Method

Add a new Blend instance into the Autodesk Revit family document.

## Syntax (C#)
```csharp
public Blend NewBlend(
	bool isSolid,
	CurveArray profile1,
	CurveArray profile2,
	SketchPlane sketchPlane
)
```

## Parameters
- **isSolid** (`System.Boolean`) - Indicates if the Blend is Solid or Void.
- **profile1** (`Autodesk.Revit.DB.CurveArray`) - The first blend section. It should represent a single, planar curve loop.
- **profile2** (`Autodesk.Revit.DB.CurveArray`) - The second blend section. It should represent a single, planar curve loop
lying in a plane parallel to that of the first blend section.
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plane for the first profile. Use this to associate the 
"base" of the blend to geometry from another element. Optional, it can be Nothing nullptr a null reference ( Nothing in Visual Basic) if you want Revit
to derive a new sketch plane from the geometry of the base profile.

## Returns
If creation was successful the new blend is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
This method creates a blend in a family document. Revit will determine an appropriate 
default mapping for the vertices of the two profiles.
A profile loop cannot contain just one closed curve - in such a case, the curve must be
split into at least two segments, so that Revit can find vertices to use for mapping the blend.
Caution: several aspects of the Blend are not (easily) predictable from the input arguments.
For example, the Blend's TopOffset may be less than its BottomOffset in some cases,
depending on the orientations of the profile loops and the orientation of the sketch plane
(if a sketch plane is provided). Also, such orientations can affect whether the first or
second profile lies in the sketch plane (if a sketch plane is provided).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the argument is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when creation is attempted in Conceptual Mass, 2D, or other family where blends cannot be created.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

