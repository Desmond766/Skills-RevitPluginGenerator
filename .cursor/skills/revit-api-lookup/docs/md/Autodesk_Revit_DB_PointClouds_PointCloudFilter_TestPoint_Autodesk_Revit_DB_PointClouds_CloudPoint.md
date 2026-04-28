---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudFilter.TestPoint(Autodesk.Revit.DB.PointClouds.CloudPoint)
source: html/3f952c67-35da-eec2-1ae5-01502b4563b9.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudFilter.TestPoint Method

Checks if a point is inside the volume of interest.

## Syntax (C#)
```csharp
public virtual bool TestPoint(
	CloudPoint point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.PointClouds.CloudPoint`) - The point to be tested.

## Returns
If true, the point is accepted, if false, the point is not accepted.

