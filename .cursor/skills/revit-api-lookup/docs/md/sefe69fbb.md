---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudOverrides.GetPointCloudRegionOverrideSettings(Autodesk.Revit.DB.ElementId,System.String,Autodesk.Revit.DB.Document)
source: html/10f17433-17b0-3013-e9c6-b6630aeef9b8.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudOverrides.GetPointCloudRegionOverrideSettings Method

Gets override settings assigned to a particular region within a PointCloudInstance element.

## Syntax (C#)
```csharp
public PointCloudOverrideSettings GetPointCloudRegionOverrideSettings(
	ElementId elementId,
	string regionTag,
	Document doc
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Id of the overridden element.
- **regionTag** (`System.String`) - The tag identifying the particular region within the PointCloudInstance element.
 Tags can be obtained from PointCloudInstance via method getRegions.
- **doc** (`Autodesk.Revit.DB.Document`) - Document containing the overridden element.

## Returns
The override settings assigned to the region, if present, or a default override settings if nothing was found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when supplied regionTag is not empty while doc is NULL
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

