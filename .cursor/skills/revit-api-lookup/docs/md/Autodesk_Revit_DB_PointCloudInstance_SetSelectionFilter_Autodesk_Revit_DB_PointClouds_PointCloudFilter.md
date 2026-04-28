---
kind: method
id: M:Autodesk.Revit.DB.PointCloudInstance.SetSelectionFilter(Autodesk.Revit.DB.PointClouds.PointCloudFilter)
source: html/780c480f-88dc-54b4-0b89-b7448dc741b0.htm
---
# Autodesk.Revit.DB.PointCloudInstance.SetSelectionFilter Method

Sets active selection filter by cloning of the one passed to it.

## Syntax (C#)
```csharp
public void SetSelectionFilter(
	PointCloudFilter pFilter
)
```

## Parameters
- **pFilter** (`Autodesk.Revit.DB.PointClouds.PointCloudFilter`) - The filter object to be made active. If Nothing nullptr a null reference ( Nothing in Visual Basic) is supplied, the
 active filter is removed.

## Remarks
The filter is provided in the coordinates of the Revit model. If the point cloud is
 altered (e.g. by moving, rotating, scaling or other modifications) the point cloud
 filter is not modified and the set of highlighted or isolated points will change.
 The selection filter is not preserved when the Revit document is saved.

