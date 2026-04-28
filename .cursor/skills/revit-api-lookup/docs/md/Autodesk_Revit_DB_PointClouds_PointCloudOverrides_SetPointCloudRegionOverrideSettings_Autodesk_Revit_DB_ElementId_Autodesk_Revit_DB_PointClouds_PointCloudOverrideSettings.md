---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudOverrides.SetPointCloudRegionOverrideSettings(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings)
source: html/983f1c51-43e3-461a-4846-cfc27b6a3cd9.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudOverrides.SetPointCloudRegionOverrideSettings Method

Assigns region override settings to the whole PointCloudInstance element.

## Syntax (C#)
```csharp
public void SetPointCloudRegionOverrideSettings(
	ElementId elementId,
	PointCloudOverrideSettings newSettings
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Id of the element to be overridden.
- **newSettings** (`Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings`) - Override settings to be assigned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

