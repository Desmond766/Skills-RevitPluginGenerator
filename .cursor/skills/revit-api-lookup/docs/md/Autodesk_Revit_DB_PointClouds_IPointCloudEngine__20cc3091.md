---
kind: type
id: T:Autodesk.Revit.DB.PointClouds.IPointCloudEngine
source: html/c444fe12-e214-eac3-e934-bd3aa84b70ca.htm
---
# Autodesk.Revit.DB.PointClouds.IPointCloudEngine

An interface that controls the behavior of the link from Revit to a custom Point Cloud Engine.

## Syntax (C#)
```csharp
public interface IPointCloudEngine
```

## Remarks
An instance of this interface should be created by the engine provider
 and registered with the PointCloudEnginesRegistry. The engine may associated
 with a particular file name extension during registration (for example,
 Revit supplies a built-in engine for working with files with the extension "rcs" or "rcp").
 Alternatively, the engine may be associated with an identifier which is not expected
 to the be the extension of a particular file.

