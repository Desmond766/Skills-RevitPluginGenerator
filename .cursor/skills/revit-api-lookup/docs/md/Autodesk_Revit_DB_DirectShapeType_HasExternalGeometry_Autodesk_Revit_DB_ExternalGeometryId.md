---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.HasExternalGeometry(Autodesk.Revit.DB.ExternalGeometryId)
source: html/331798b3-7509-159a-2f57-04bb6aacf049.htm
---
# Autodesk.Revit.DB.DirectShapeType.HasExternalGeometry Method

Checks whether the externally tagged geometry is already present in this DirectShapeType.

## Syntax (C#)
```csharp
public bool HasExternalGeometry(
	ExternalGeometryId externalId
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The external ID of the externally tagged geometry to check.

## Returns
True if such an externally tagged geometry is already present in this DirectShapeType, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

