---
kind: type
id: T:Autodesk.Revit.DB.PointClouds.PointCloudEngineRegistry
source: html/d5a45f31-3bc0-9eeb-53c1-fe0fce4d7f42.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudEngineRegistry

This class supports registration of custom Point Cloud Engines in a Revit session.

## Syntax (C#)
```csharp
public static class PointCloudEngineRegistry
```

## Remarks
This class is the start point for engine providers. A custom engine implementation consists of the following:
 An implementation of IPointCloudEngine registered to Revit via the PointCloudEngineRegistry. An implementation of IPointCloudAccess coded to respond to inquiries from Revit regarding the
 properties of a single point cloud. An implementation of IPointSetIterator code to return sets of points to Revit when requested. Engine implementations may be file-based or non-file-based:
 File-based implementations require that
 each point cloud be mapped to a single file on disk. Revit will allow users to create new point
 cloud instances in a document directly by selecting point cloud files whose extension matches
 the engine identifier. These files are treated as external links in Revit and may be reloaded and remapped
 when necessary from the Manage Links dialog. Non-file-based engine implementations may obtain point clouds from anywhere (e.g. from a database,
 from a server, or from one part of a larger aggregate file). Because there is no file that the user may select,
 Revit's user interface will not allow a user to create a point cloud of this type. The engine provider should supply
 a custom command using PointCloudType.Create() and PointCloudInstance.Create() to create and place point clouds of
 this type. The Manage Links dialog will show the point clouds of this type, but since there is no file
 associated to the point cloud, the user cannot manage, reload or remap point clouds of this type. Regardless of the type of engine used, the implementation must supply enough information to Revit to
 display the contents of the point cloud. There are two ReadPoints methods which must be implemented:
 IPointCloudAccess.ReadPoints() - this provides a single set of points in a one-time call from Revit. Revit uses
 this during some display activities including selection prehighlighting. It is also possible for API clients
 to call this method directly (via PointCloudInstance.GetPoints()). IPointSetIterator.ReadPoints() - this provides a subset of points as a part of a larger iteration of points
 in the cloud. Revit uses this method during normal display of the point cloud; quantities of points will be
 requested repeatedly until it obtains enough points or until something in the display changes. The engine
 implementation must keep track of which points have been returned to Revit during any given point set iteration.

