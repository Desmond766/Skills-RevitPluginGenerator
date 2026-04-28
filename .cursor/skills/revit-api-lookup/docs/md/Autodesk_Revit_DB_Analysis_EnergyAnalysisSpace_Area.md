---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisSpace.Area
zh: 面积区域
source: html/48a1a8b2-aba4-2c2b-a034-aa6ff514f70d.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisSpace.Area Property

**中文**: 面积区域

The area for this space.

## Syntax (C#)
```csharp
public double Area { get; }
```

## Remarks
If the space is created with the mode 'Use Rooms or Spaces', this value is the enclosed area measured by interior bounding surfaces.
 Otherwise, this value is measured by the center plane of walls and the top plane of roofs and floors.

