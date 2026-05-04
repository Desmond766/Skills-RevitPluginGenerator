---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudFilterFactory.CreateMultiPlaneFilter(System.Collections.Generic.IList{Autodesk.Revit.DB.Plane})
source: html/fcb723de-befe-864d-9d4a-3084aea596b1.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudFilterFactory.CreateMultiPlaneFilter Method

Creates a new point cloud filter based upon planar boundaries.

## Syntax (C#)
```csharp
public static PointCloudFilter CreateMultiPlaneFilter(
	IList<Plane> planes
)
```

## Parameters
- **planes** (`System.Collections.Generic.IList < Plane >`) - All planes used for filtering; positive direction of the normal should point inside the volume of interest.
 Only points on the "positive" side of all planes will pass the filter.

## Returns
Filter object; can be used to get representative set of cloud points passing through the filter.

## Remarks
The filter will check whether a point is located on the "positive" side of each plane,
 as indicated by the positive direction of the plane normal. Therefore, such filter implicitly defines a volume,
 which is the intersection of the positive half-spaces corresponding to all the planes.
 This volume does not have to be closed, but it will always be convex.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

