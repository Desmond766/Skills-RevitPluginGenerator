---
kind: property
id: P:Autodesk.Revit.DB.Sweep.IsTrajectorySegmentationEnabled
source: html/f39d045a-7f14-f30a-0114-bbeaecf73c13.htm
---
# Autodesk.Revit.DB.Sweep.IsTrajectorySegmentationEnabled Property

The trajectory segmentation option for the sweep.

## Syntax (C#)
```csharp
public bool IsTrajectorySegmentationEnabled { get; set; }
```

## Remarks
This property is used to retrieve/set the trajectory segmentation state of the sweep.
if return is true, means user can control the MaxSegmentAngle, otherwise is disable.

