---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudOverrides.GetPointCloudRegionOverrideSettings(Autodesk.Revit.DB.ElementId)
source: html/31f2fb8a-d5a7-74fb-e345-6cbfd123e57a.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudOverrides.GetPointCloudRegionOverrideSettings Method

Gets region override settings assigned to the whole PointCloudInstance element.

## Syntax (C#)
```csharp
public PointCloudOverrideSettings GetPointCloudRegionOverrideSettings(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Id of the overridden element.

## Returns
The override settings assigned to the element, if present, or a default override settings if nothing was found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

