---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.RemoveExternallyTaggedGeometry(Autodesk.Revit.DB.ExternalGeometryId)
source: html/0fc3b749-bcc3-1472-092d-38475fe2c81d.htm
---
# Autodesk.Revit.DB.DirectShapeType.RemoveExternallyTaggedGeometry Method

Removes the externally tagged geometry object by its external ID from this DirectShapeType.

## Syntax (C#)
```csharp
public void RemoveExternallyTaggedGeometry(
	ExternalGeometryId externalId
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The external ID of the externally tagged geometry that should be removed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The externally tagged geometry with the input externalId is not present in this DirectShapeType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

