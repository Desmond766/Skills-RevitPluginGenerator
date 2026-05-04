---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeReferenceOptions.SetExternalGeometryId(Autodesk.Revit.DB.ExternalGeometryId)
source: html/cf7b570f-9e31-adba-cd8d-59e52debe7d3.htm
---
# Autodesk.Revit.DB.DirectShapeReferenceOptions.SetExternalGeometryId Method

Sets the ExternalGeometryId associated with the reference object.
 The ID must be non-empty.

## Syntax (C#)
```csharp
public DirectShapeReferenceOptions SetExternalGeometryId(
	ExternalGeometryId externalId
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - externalId cannot be used as an ExternalGeometryId for a direct shape reference.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

