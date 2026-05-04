---
kind: type
id: T:Autodesk.Revit.DB.PointClouds.IPointCloudAccess
source: html/d5e8d1d7-9375-ce6b-ff4f-6d4764c92736.htm
---
# Autodesk.Revit.DB.PointClouds.IPointCloudAccess

An interface that provides functionality for working with an individual
 Point Cloud.

## Syntax (C#)
```csharp
public interface IPointCloudAccess
```

## Remarks
An instance of this interface is obtained from the associated point cloud
 engine when the engine's CreatePointCloudAccess method is called. An instance of this class will be requested by Revit when drawing the point cloud in the view. For performance reasons,
 when rendering every frame Revit asks the engine to fetch the necessary points split into multiple batches.
 The number of batches requested depends on the view: the smaller the projection of the cloud bounding box on the screen
 the fewer batches Revit requests. Revit assumes that each batch contains points uniformly distributed over the visible part of
 the cloud ("visible" as defined by the filter). Thus, the points supplied by the engine should not be geometrically distinct (e.g.
 divided into multiple independent volumes, because at distant zoom levels Revit will only request a few batches and only part
 of the cloud will be displayed.

