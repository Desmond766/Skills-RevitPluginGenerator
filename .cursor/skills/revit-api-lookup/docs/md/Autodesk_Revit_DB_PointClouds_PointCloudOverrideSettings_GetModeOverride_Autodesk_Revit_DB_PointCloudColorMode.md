---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings.GetModeOverride(Autodesk.Revit.DB.PointCloudColorMode)
source: html/258ce0c5-fd08-20bb-9052-50458a5975bf.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings.GetModeOverride Method

Lookup color settings for the given color mode.

## Syntax (C#)
```csharp
public PointCloudColorSettings GetModeOverride(
	PointCloudColorMode mode
)
```

## Parameters
- **mode** (`Autodesk.Revit.DB.PointCloudColorMode`) - Color mode for which to lookup the color settings.

## Returns
Color settings stored for the given color mode or default color settings if nothing is stored for the given color mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

