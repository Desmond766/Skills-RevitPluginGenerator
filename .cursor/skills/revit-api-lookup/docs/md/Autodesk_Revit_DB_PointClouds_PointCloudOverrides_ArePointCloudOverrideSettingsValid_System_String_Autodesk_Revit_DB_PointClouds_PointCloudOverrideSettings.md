---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudOverrides.ArePointCloudOverrideSettingsValid(System.String,Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings)
source: html/2c34669d-bda3-5823-b58a-37526fc4566d.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudOverrides.ArePointCloudOverrideSettingsValid Method

Checks if PointCloudOverrideSettings are valid

## Syntax (C#)
```csharp
public static bool ArePointCloudOverrideSettingsValid(
	string tag,
	PointCloudOverrideSettings settings
)
```

## Parameters
- **tag** (`System.String`) - The tag identifying the particular scan/region within the PointCloudInstance element.
 Tags can be obtained from PointCloudInstance via method getScans/getRegions.
- **settings** (`Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings`) - Override settings to be checked.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

