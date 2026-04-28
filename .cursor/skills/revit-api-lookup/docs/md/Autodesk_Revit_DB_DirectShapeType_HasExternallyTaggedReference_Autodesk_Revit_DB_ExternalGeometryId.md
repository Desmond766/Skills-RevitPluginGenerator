---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.HasExternallyTaggedReference(Autodesk.Revit.DB.ExternalGeometryId)
source: html/984c365c-9b92-bdc1-c7a3-423b795f073c.htm
---
# Autodesk.Revit.DB.DirectShapeType.HasExternallyTaggedReference Method

Checks if the externally tagged reference is already present in this DirectShapeType.

## Syntax (C#)
```csharp
public bool HasExternallyTaggedReference(
	ExternalGeometryId externalId
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The external ID of the tagged reference to check for.

## Returns
True if the DirectShapeType holds a reference with the specified ExternalGeometryId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

