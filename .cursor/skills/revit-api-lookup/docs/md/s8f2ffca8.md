---
kind: property
id: P:Autodesk.Revit.DB.SunAndShadowSettings.ActiveFrame
source: html/dbf75176-4862-b20f-81e2-e948934a193e.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.ActiveFrame Property

Identifies the active animation frame for a single-day or multi-day study,
 starting at 1.0 for the first frame and incrementing in intervals of 1.0.

## Syntax (C#)
```csharp
public double ActiveFrame { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: the frame value frame is not valid.

