---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudOverrides.SetPointCloudScanOverrideSettings(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings,System.String,Autodesk.Revit.DB.Document)
source: html/0de5315f-6924-3aa2-b2b5-b3999e1bc0fa.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudOverrides.SetPointCloudScanOverrideSettings Method

Assigns scan override settings to a particular scan within a PointCloudInstance element.

## Syntax (C#)
```csharp
public void SetPointCloudScanOverrideSettings(
	ElementId elementId,
	PointCloudOverrideSettings newSettings,
	string scanTag,
	Document doc
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Id of the element to be overridden.
- **newSettings** (`Autodesk.Revit.DB.PointClouds.PointCloudOverrideSettings`) - Override settings to be assigned.
- **scanTag** (`System.String`) - The tag identifying the particular scan within the PointCloudInstance element.
 Tags can be obtained from PointCloudInstance via method getScans.
- **doc** (`Autodesk.Revit.DB.Document`) - Document containing the element to be overridden.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when supplied scanTag is not empty while doc is NULL
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The override settings are not valid.

