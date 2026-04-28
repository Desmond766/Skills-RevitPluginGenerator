---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilderPersistentIds.IsValidExternalGeometryIdForNewCorrespondence(Autodesk.Revit.DB.ExternalGeometryId)
source: html/634779e5-d3d2-c68c-ccc8-07731fe44486.htm
---
# Autodesk.Revit.DB.BRepBuilderPersistentIds.IsValidExternalGeometryIdForNewCorrespondence Method

Validates the input ExternalGeometryId that will be used to create a correspondence.
 In order to be valid, a correspondence for the input ExternalGeometryId must not already exist.

## Syntax (C#)
```csharp
public bool IsValidExternalGeometryIdForNewCorrespondence(
	ExternalGeometryId externalGeometryId
)
```

## Parameters
- **externalGeometryId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The ExternalGeometryId to be used in a new correspondence.

## Returns
True if the input ExternalGeometryId can be used to create a new correspondence.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

