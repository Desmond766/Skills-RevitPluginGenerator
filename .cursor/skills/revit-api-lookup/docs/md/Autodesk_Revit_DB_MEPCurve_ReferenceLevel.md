---
kind: property
id: P:Autodesk.Revit.DB.MEPCurve.ReferenceLevel
source: html/3d7248c5-558d-60ba-42da-c3b46d35f1cd.htm
---
# Autodesk.Revit.DB.MEPCurve.ReferenceLevel Property

The reference level of the MEP curve.

## Syntax (C#)
```csharp
public Level ReferenceLevel { get; set; }
```

## Remarks
This property is used to retrieve the reference level of the MEP curve.
If the curve is not in a horizontal plane, this value will be the start point's reference level.

