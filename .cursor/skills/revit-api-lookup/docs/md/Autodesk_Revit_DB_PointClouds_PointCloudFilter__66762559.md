---
kind: type
id: T:Autodesk.Revit.DB.PointClouds.PointCloudFilter
source: html/ca6f916b-2eba-f8e5-8939-1c063330c886.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudFilter

A class used to describe the criteria an application desires when obtaining members of a point cloud.

## Syntax (C#)
```csharp
public class PointCloudFilter : IDisposable
```

## Remarks
Client applications which wish to obtain points from a point cloud will have to create a
 PointCloudFilter to define the volume of interest (see PointCloudFilterFactory).
 Engine implementations will need to use the methods contained within the point cloud to determine
 which points to return to Revit.

