---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudOverrides.SetPointCloudRegionOverrideSettings(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings,System.String,Autodesk.Revit.DB.Document)
source: html/dda42d13-bbf1-93f2-9be5-fa9481c867a9.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudOverrides.SetPointCloudRegionOverrideSettings Method

Assigns override settings to a particular region within a PointCloudInstance element.

## Syntax (C#)
```csharp
public void SetPointCloudRegionOverrideSettings(
	ElementId elementId,
	PointCloudOverrideSettings newSettings,
	string regionTag,
	Document doc
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Id of the element to be overridden.
- **newSettings** (`Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings`) - Override settings to be assigned.
- **regionTag** (`System.String`) - The tag identifying the particular region within the PointCloudInstance element.
 Tags can be obtained from PointCloudInstance via method getRegions.
- **doc** (`Autodesk.Revit.DB.Document`) - Document containing the element to be overridden.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when supplied regionTag is not empty while doc is NULL
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The override settings are not valid.

