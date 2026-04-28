---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.IPointCloudAccess.GetExtent
source: html/4b6ac759-a92f-6812-8451-027725654e61.htm
---
# Autodesk.Revit.DB.PointClouds.IPointCloudAccess.GetExtent Method

Implement this method to returns an object that contains the bounding box of the entire
 point cloud, aligned to the point cloud coordinate system.

## Syntax (C#)
```csharp
Outline GetExtent()
```

## Returns
The bounding box of the point cloud.

## Remarks
The extents should reflect the maximum and minimum coordinates of the stored points, and
 not incorporate the offset.

