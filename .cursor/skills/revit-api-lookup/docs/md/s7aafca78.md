---
kind: property
id: P:Autodesk.Revit.DB.CurveElement.SketchPlane
source: html/e8c6a9e9-e048-d750-2951-6f45ac7f350d.htm
---
# Autodesk.Revit.DB.CurveElement.SketchPlane Property

The sketch plane the curve element lies in.

## Syntax (C#)
```csharp
public virtual SketchPlane SketchPlane { get; set; }
```

## Remarks
The new sketch plane must be parallel to the existing sketch plane. Setting this property
is not permitted for detail curves because they must be placed only on view-specific planes.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown if the argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the CurveElement is CurveByPoints or belongs to a Path3d element. -- or --
Thrown if the sketch plane is set on a DetailCurve. --or--
Thrown if the sketch plane is not parallel to the existing plane. -- or --
Thrown if the sketch plane is not suitable. -- or --
Thrown if the CurveElement belongs to a sketch-based element. -- or --
Thrown if modifying the sketch plane is not allowed. -- or --
Thrown if the CurveElement cannot be moved out of its sketch plane.

