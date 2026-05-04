---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyAnalysisSpace.Volume
zh: 体积
source: html/36257f80-cd3d-c85d-8e9d-af6c298fee77.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisSpace.Volume Property

**中文**: 体积

The volume for this space.

## Syntax (C#)
```csharp
public double Volume { get; }
```

## Remarks
If the space is created with the mode 'Use Rooms or Spaces', this value is the enclosed volume measured by interior bounding surfaces.
 Otherwise, this value is the average of the analytical volume and the voxel volume. Note that the analytical volume is measured by
 the center plane of walls and the top plane of roofs and floors, and the voxel volume is measured by the number of enclosed unit cubes.

