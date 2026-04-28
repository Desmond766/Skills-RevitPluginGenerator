---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.IPointCloudAccess.ReadPoints(Autodesk.Revit.DB.PointClouds.PointCloudFilter,Autodesk.Revit.DB.ElementId,System.IntPtr,System.Int32)
source: html/6179b595-b765-c575-c456-2eabb742418f.htm
---
# Autodesk.Revit.DB.PointClouds.IPointCloudAccess.ReadPoints Method

Implement this method so that on successive invocations it will return distinct subsets of
 points which meet the criterion.

## Syntax (C#)
```csharp
int ReadPoints(
	PointCloudFilter rFilter,
	ElementId viewId,
	IntPtr buffer,
	int nBufferSize
)
```

## Parameters
- **rFilter** (`Autodesk.Revit.DB.PointClouds.PointCloudFilter`) - The filter used to process cloud points and determine which ones lie with the target volume.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view id for the current view passed as auxiliary information to allow the
 engine to optimize retrieval of points. If viewId == InvalidElementId, the
 query is not for a view display operation.
- **buffer** (`System.IntPtr`) - Memory buffer into which the points should be written. The buffer was allocated
 by Revit and it is guaranteed to be valid for the duration of the call.
- **nBufferSize** (`System.Int32`) - The maximum number of CloudPoint objects that may be copied into the buffer.

## Returns
The actual number of CloudPoint objects placed in the buffer (can be less than the
 length of the buffer). If there are no points available that match the filter criteria, return 0.

