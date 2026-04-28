---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudOverrides.SetPointCloudScanOverrideSettings(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings)
source: html/2f5e2c7f-39a9-5082-11ff-7441e948122d.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudOverrides.SetPointCloudScanOverrideSettings Method

Assigns scan override settings to the whole PointCloudInstance element.

## Syntax (C#)
```csharp
public void SetPointCloudScanOverrideSettings(
	ElementId elementId,
	PointCloudOverrideSettings newSettings
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Id of the element to be overridden.
- **newSettings** (`Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings`) - Override settings to be assigned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

