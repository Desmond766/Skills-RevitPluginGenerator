---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.HasExternallyTaggedReference(Autodesk.Revit.DB.ExternalGeometryId)
source: html/98a5037a-d40a-4073-30f1-f230982f7456.htm
---
# Autodesk.Revit.DB.DirectShape.HasExternallyTaggedReference Method

Checks if the externally tagged reference is already present in this DirectShape.

## Syntax (C#)
```csharp
public bool HasExternallyTaggedReference(
	ExternalGeometryId externalId
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The external ID of the tagged reference to check for.

## Returns
True if the DirectShape holds a reference with the specified ExternalGeometryId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

