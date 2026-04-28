---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudFilterFactory.CreateMultiPlaneFilter(System.Collections.Generic.IList{Autodesk.Revit.DB.Plane},System.Int32)
source: html/889dd57c-8913-706f-6039-af3c15672a09.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudFilterFactory.CreateMultiPlaneFilter Method

Creates a new point cloud filter based upon planar boundaries.

## Syntax (C#)
```csharp
public static PointCloudFilter CreateMultiPlaneFilter(
	IList<Plane> planes,
	int exactPlaneCount
)
```

## Parameters
- **planes** (`System.Collections.Generic.IList < Plane >`) - All planes used for filtering; positive direction of the normal should point inside the volume of interest.
- **exactPlaneCount** (`System.Int32`) - This value represents the number of planes (taken in order of their addition) which will be used
 for exact filtering of individual points. Other planes in the filter will be used for faster,
 but inexact filtering based on cells.

## Returns
Filter object; can be used to get representative set of cloud points passing through the filter.

## Remarks
The filter will check whether a point is located on the "positive" side of each plane,
 as indicated by the positive direction of the plane normal. Therefore, such filter implicitly defines a volume,
 which is the intersection of the positive half-spaces corresponding to all the planes.
 This volume does not have to be closed, but it will always be convex.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

