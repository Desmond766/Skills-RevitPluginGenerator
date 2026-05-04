---
kind: method
id: M:Autodesk.Revit.DB.PointCloudType.GetReCapProject
source: html/d309db9b-b523-7dcb-9b76-69d540c1a362.htm
---
# Autodesk.Revit.DB.PointCloudType.GetReCapProject Method

This method provides a direct entry point to get access to an object from the ReCap SDK (ReCapWrapper.RCProject) from Revit. This object represents the point cloud from the RC file path stored in PointCloudType. The ReCap assembly AdskRcManaged.dll will need to be included into code using this method.

## Syntax (C#)
```csharp
public RCProject GetReCapProject()
```

## Remarks
The coordinate system in RCProject is defined by Point Cloud. Please refer to ReCap SDK document for RCProject::getCoordinateSystem.
 If you need points converted to the modeling coordinate system in Revit, you can obtain the transformation matrix from PointCloudInstance GetTransform () () () .

## Exceptions
- **Autodesk.Revit.Exceptions.FileAccessException** - The file or PointCloudEngine is not ReCap based.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Exception happens when ReCap loading the project.

