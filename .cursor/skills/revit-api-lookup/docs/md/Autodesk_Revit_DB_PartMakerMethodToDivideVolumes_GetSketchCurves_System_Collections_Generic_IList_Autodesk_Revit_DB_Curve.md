---
kind: method
id: M:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.GetSketchCurves(System.Collections.Generic.IList{Autodesk.Revit.DB.Curve}@)
source: html/aea3a812-42f4-6aa3-6574-646ad8e662a6.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.GetSketchCurves Method

Populates the array with copies of curves in the sketch.

## Syntax (C#)
```csharp
public void GetSketchCurves(
	out IList<Curve> curveArray
)
```

## Parameters
- **curveArray** (`System.Collections.Generic.IList < Curve > %`) - Curves in the sketch. Tags of the curves are consistent with the curve tags
 used in part keys.

