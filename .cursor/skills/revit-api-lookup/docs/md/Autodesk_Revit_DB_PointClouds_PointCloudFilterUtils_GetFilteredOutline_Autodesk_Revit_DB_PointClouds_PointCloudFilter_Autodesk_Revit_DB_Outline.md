---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudFilterUtils.GetFilteredOutline(Autodesk.Revit.DB.PointClouds.PointCloudFilter,Autodesk.Revit.DB.Outline)
source: html/a9203036-709c-e2b0-aac1-d9432a778952.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudFilterUtils.GetFilteredOutline Method

Computes outline of a part of a box that satisfies given PointCloudFilter.

## Syntax (C#)
```csharp
public static Outline GetFilteredOutline(
	PointCloudFilter filter,
	Outline box
)
```

## Parameters
- **filter** (`Autodesk.Revit.DB.PointClouds.PointCloudFilter`) - Point cloud filter.
- **box** (`Autodesk.Revit.DB.Outline`) - A box aligned with coordinate axes.

## Returns
The bounding box of the set of all points within the original box that satisfy the filter.
 Not every point within the resulting outline satisfies the filter, but any point that is contained
 in the original box and satisfies the filter is guaranteed to be within the resulting outline.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

