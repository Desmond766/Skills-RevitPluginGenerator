---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudOverrides.GetPointCloudScanOverrideSettings(Autodesk.Revit.DB.ElementId)
source: html/f861fe75-b216-9f28-16a6-d66f5d63f8b0.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudOverrides.GetPointCloudScanOverrideSettings Method

Gets scan override settings assigned to the whole PointCloudInstance element.

## Syntax (C#)
```csharp
public PointCloudOverrideSettings GetPointCloudScanOverrideSettings(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Id of the overridden element.

## Returns
The override settings assigned to the element, if present, or a default override settings if nothing was found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

