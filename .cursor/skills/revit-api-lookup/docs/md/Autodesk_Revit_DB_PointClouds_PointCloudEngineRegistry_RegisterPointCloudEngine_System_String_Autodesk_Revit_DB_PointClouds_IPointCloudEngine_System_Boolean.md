---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudEngineRegistry.RegisterPointCloudEngine(System.String,Autodesk.Revit.DB.PointClouds.IPointCloudEngine,System.Boolean)
source: html/a8c37523-8178-fb66-e0be-719f94b770ec.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudEngineRegistry.RegisterPointCloudEngine Method

Registers a new point cloud engine and associates it to a particular file extension.

## Syntax (C#)
```csharp
public static void RegisterPointCloudEngine(
	string identifier,
	IPointCloudEngine engine,
	bool isFileBased
)
```

## Parameters
- **identifier** (`System.String`) - A string that distinguishes the engine being registered. If isFileBased is true,
 this should be the file extension (e.g. "rcs" or "rcp"). If isFileBased is false, this
 identifier is used only by API calls and should be unique.
- **engine** (`Autodesk.Revit.DB.PointClouds.IPointCloudEngine`) - The point cloud engine that governs point clouds matching the input identifier.
- **isFileBased** (`System.Boolean`) - Indicates to Revit if a single Point Cloud corresponds to a single file on disk.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The same identifier has already been registered by another engine.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

