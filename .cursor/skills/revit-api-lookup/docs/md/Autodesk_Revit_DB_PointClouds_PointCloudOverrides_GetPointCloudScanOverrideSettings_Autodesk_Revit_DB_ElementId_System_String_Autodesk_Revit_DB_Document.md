---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudOverrides.GetPointCloudScanOverrideSettings(Autodesk.Revit.DB.ElementId,System.String,Autodesk.Revit.DB.Document)
source: html/499db414-b5a3-2ca6-b52b-21ed90c5d0d5.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudOverrides.GetPointCloudScanOverrideSettings Method

Gets override settings assigned to a particular scan within a PointCloudInstance element.

## Syntax (C#)
```csharp
public PointCloudOverrideSettings GetPointCloudScanOverrideSettings(
	ElementId elementId,
	string scanTag,
	Document doc
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Id of the overridden element.
- **scanTag** (`System.String`) - The tag identifying the particular scan within the PointCloudInstance element.
 Tags can be obtained from PointCloudInstance via method getScans.
- **doc** (`Autodesk.Revit.DB.Document`) - Document containing the overridden element.

## Returns
The override settings assigned to the scan, if present, or a default override settings if nothing was found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when supplied scanTag is not empty while doc is NULL
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

