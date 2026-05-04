---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.IPointCloudEngine.CreatePointCloudAccess(System.String)
source: html/b21e1c72-b93d-0449-ae86-b77edf1e3e0c.htm
---
# Autodesk.Revit.DB.PointClouds.IPointCloudEngine.CreatePointCloudAccess Method

Implement this method to construct the IPointCloudAccess interface for the point cloud designated by
 the identifier. This method is called once during the creation of a PointCloudType.

## Syntax (C#)
```csharp
IPointCloudAccess CreatePointCloudAccess(
	string identifier
)
```

## Parameters
- **identifier** (`System.String`) - An identifier unique to the point cloud. This will be a file name if the
 engine was registered as file-based, or an arbitrary identifier if the engine is not file-based.

## Returns
The object that can be used to create iterators and interrogate the
 point cloud for its features.

## Remarks
The instance of the returned IPointCloudAccess is then used by Revit to
 display instances of the point cloud in Revit graphics and in the user interface.

