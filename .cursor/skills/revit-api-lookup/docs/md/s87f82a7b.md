---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.IsReversed
source: html/e58025cb-84de-5dd2-afe6-92d811500f16.htm
---
# Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.IsReversed Property

Used to store the state of the bar refering to the direction of the bars.
 This is useful when using face intersection to calculate bars.
 After mirroring, curves created from intersecting faces may be reversed,
 so we use this to store the state and keep the rebar pointing in the correct direction.

## Syntax (C#)
```csharp
public bool IsReversed { get; set; }
```

