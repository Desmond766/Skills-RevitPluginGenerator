---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewExtrusion(System.Boolean,Autodesk.Revit.DB.CurveArrArray,Autodesk.Revit.DB.SketchPlane,System.Double)
source: html/425e8577-ba2a-ba19-ac24-069078f97209.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewExtrusion Method

Add a new Extrusion instance into the Autodesk Revit family document.

## Syntax (C#)
```csharp
public Extrusion NewExtrusion(
	bool isSolid,
	CurveArrArray profile,
	SketchPlane sketchPlane,
	double end
)
```

## Parameters
- **isSolid** (`System.Boolean`) - Indicates if the Extrusion is Solid or Void.
- **profile** (`Autodesk.Revit.DB.CurveArrArray`) - The profile of the newly created Extrusion. This may contain more 
than one curve loop. Each loop must be a fully closed curve loop and the loops may not 
intersect. All input curves must lie in the same plane.
The loop can be a unbound circle or ellipse, but its geometry will be split in two in 
order to satisfy requirements for sketches used in extrusions.
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plane for the extrusion. The direction of extrusion
is determined by the normal for the sketch plane. To extrude in the other direction set 
the end value to negative.
- **end** (`System.Double`) - The length of the extrusion.

## Returns
If creation was successful the new Extrusion is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
This method creates an extrusion in a family document. The extrusion will be 
extended perpendicular to the sketch plane of the extrusion profile.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-profile-is Nothing nullptr a null reference ( Nothing in Visual Basic) or empty array.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-sketchPlane-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-sketchPlane-is an invalid sketch plane.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

