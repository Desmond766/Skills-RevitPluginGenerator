---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.HasExternalGeometry(Autodesk.Revit.DB.ExternalGeometryId)
source: html/e17297d9-8bc9-2408-515d-2e9058e4fb5c.htm
---
# Autodesk.Revit.DB.DirectShape.HasExternalGeometry Method

Checks whether the externally tagged geometry is already present in this DirectShape.

## Syntax (C#)
```csharp
public bool HasExternalGeometry(
	ExternalGeometryId externalId
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The external ID of the externally tagged geometry to check.

## Returns
True if such an externally tagged geometry is already present in this DirectShape, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

