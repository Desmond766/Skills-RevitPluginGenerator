---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.IPointCloudAccess.CreatePointSetIterator(Autodesk.Revit.DB.PointClouds.PointCloudFilter,Autodesk.Revit.DB.ElementId)
source: html/3e5c8c80-64ae-77f0-90de-c3b61a78b9f3.htm
---
# Autodesk.Revit.DB.PointClouds.IPointCloudAccess.CreatePointSetIterator Method

Implement this method to return an iterator for iterating over blocks of this point cloud.

## Syntax (C#)
```csharp
IPointSetIterator CreatePointSetIterator(
	PointCloudFilter rFilter,
	ElementId viewId
)
```

## Parameters
- **rFilter** (`Autodesk.Revit.DB.PointClouds.PointCloudFilter`) - The filter used to process cloud points and determine which ones lie with the target volume.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view id for the current view passed as auxiliary information to allow the
 engine to optimize retrieval of points. If viewId == InvalidElementId, the
 query is not for a view display operation.

## Returns
The newly created iterator.

