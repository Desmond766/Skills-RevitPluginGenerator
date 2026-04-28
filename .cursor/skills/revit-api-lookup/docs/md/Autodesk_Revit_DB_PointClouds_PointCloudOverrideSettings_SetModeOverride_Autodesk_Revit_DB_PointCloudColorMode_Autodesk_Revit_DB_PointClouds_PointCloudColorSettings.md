---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings.SetModeOverride(Autodesk.Revit.DB.PointCloudColorMode,Autodesk.Revit.DB.PointClouds.PointCloudColorSettings)
source: html/d44adc12-6607-719a-98fd-fd8efbc85771.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings.SetModeOverride Method

Sets color settings for the given color mode.

## Syntax (C#)
```csharp
public void SetModeOverride(
	PointCloudColorMode mode,
	PointCloudColorSettings colorSettings
)
```

## Parameters
- **mode** (`Autodesk.Revit.DB.PointCloudColorMode`) - Color mode for which color settings are set.
- **colorSettings** (`Autodesk.Revit.DB.PointClouds.PointCloudColorSettings`) - Color settings to be set for the given color mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

