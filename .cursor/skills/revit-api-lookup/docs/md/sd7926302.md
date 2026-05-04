---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.GetExternallyTaggedGeometry(Autodesk.Revit.DB.ExternalGeometryId)
source: html/a32792d0-1633-37c5-6ed0-02bdb9b6c4b5.htm
---
# Autodesk.Revit.DB.DirectShape.GetExternallyTaggedGeometry Method

Gets the externally tagged geometry by its external ID that is stored in this DirectShape.

## Syntax (C#)
```csharp
public ExternallyTaggedGeometryObject GetExternallyTaggedGeometry(
	ExternalGeometryId externalId
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The external ID of the externally tagged geometry that should be obtained.

## Returns
The externally tagged geometry.
 Or Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no such an externally tagged geometry in the DirectShape.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

