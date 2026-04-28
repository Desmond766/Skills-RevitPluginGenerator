---
kind: method
id: M:Autodesk.Revit.DB.PointCloudInstance.GetPoints(Autodesk.Revit.DB.PointClouds.PointCloudFilter,System.Double,System.Int32)
source: html/6761fd71-e38e-d60f-90f7-9e034bf2d5c0.htm
---
# Autodesk.Revit.DB.PointCloudInstance.GetPoints Method

Extracts a collection of points based on a filter.

## Syntax (C#)
```csharp
public PointCollection GetPoints(
	PointCloudFilter filter,
	double averageDistance,
	int numPoints
)
```

## Parameters
- **filter** (`Autodesk.Revit.DB.PointClouds.PointCloudFilter`) - The filter to control which points are extracted. The filter should be passed in the coordinates
 of the Revit model.
- **averageDistance** (`System.Double`) - Desired average distance between "adjacent" cloud points (Revit units of length).
 The smaller the averageDistance the larger number of points will be returned up to the numPoints limit.
 Specifying this parameter makes actual number of points returned for a given filter independent of the
 density of coverage produced by the scanner.
- **numPoints** (`System.Int32`) - The maximum number of points requested.

## Returns
A collection object containing points that pass the filter, but no more than the maximum number requested.

## Remarks
If there are more points in the cloud passing the filter than the number requested in this function,
 the results may not be consistent if the same call is made again.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The number of points read must range from 1 to 1000000.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for averageDistance must be no more than 30000 feet in absolute value.

