---
kind: property
id: P:Autodesk.Revit.DB.CurveByPoints.SketchPlane
source: html/94ff6c7e-7596-0ee9-357a-fc91e1ba8547.htm
---
# Autodesk.Revit.DB.CurveByPoints.SketchPlane Property

Override the SketchPlane property of CurveElement.

## Syntax (C#)
```csharp
public override SketchPlane SketchPlane { get; set; }
```

## Remarks
CurveByPoints has no associated SketchPlane. Getting this
property returns Nothing nullptr a null reference ( Nothing in Visual Basic) . Setting it causes an InvalidOperationException.

