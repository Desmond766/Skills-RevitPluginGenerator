---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.IPointCloudAccess.CreatePointSetIterator(Autodesk.Revit.DB.PointClouds.PointCloudFilter,System.Double,Autodesk.Revit.DB.ElementId)
source: html/c548e4cd-086b-f207-ab9e-349e9d4a161a.htm
---
# Autodesk.Revit.DB.PointClouds.IPointCloudAccess.CreatePointSetIterator Method

Implement this method to return an iterator for iterating over blocks of this point cloud.

## Syntax (C#)
```csharp
IPointSetIterator CreatePointSetIterator(
	PointCloudFilter rFilter,
	double density,
	ElementId viewId
)
```

## Parameters
- **rFilter** (`Autodesk.Revit.DB.PointClouds.PointCloudFilter`) - The filter used to process cloud points and determine which ones lie with the target volume.
- **density** (`System.Double`) - Desired number of points per unit area. Area is computed in native units of the point cloud.
 Another iterator, created with the same density and a more restrictive
 filter, should return a subset of the points returned by this iterator.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view id for the current view passed as auxiliary information to allow the
 engine to optimize retrieval of points. If viewId == InvalidElementId, the
 query is not for a view display operation.

## Returns
The newly created iterator.

