---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.RemoveExternallyTaggedGeometry(Autodesk.Revit.DB.ExternalGeometryId)
source: html/f25a46b4-5eb7-f503-1599-bfb3b549d632.htm
---
# Autodesk.Revit.DB.DirectShape.RemoveExternallyTaggedGeometry Method

Removes the externally tagged geometry object by its external ID from this DirectShape.

## Syntax (C#)
```csharp
public void RemoveExternallyTaggedGeometry(
	ExternalGeometryId externalId
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The external ID of the externally tagged geometry that should be removed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The externally tagged geometry with the input externalId is not present in this DirectShape.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

