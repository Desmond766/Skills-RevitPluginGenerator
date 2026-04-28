---
kind: method
id: M:Autodesk.Revit.DB.PointCloudInstance.GetScanOrigin(System.String)
source: html/2c3c465d-8681-6eb3-284b-f75fdfa10c0c.htm
---
# Autodesk.Revit.DB.PointCloudInstance.GetScanOrigin Method

Returns the origin point of a scan in model coordinates.

## Syntax (C#)
```csharp
public XYZ GetScanOrigin(
	string scanName
)
```

## Parameters
- **scanName** (`System.String`) - Name of the scan.

## Returns
Resulting origin point of the scan.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - PointCloudInstance does not contain scan scanName.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

