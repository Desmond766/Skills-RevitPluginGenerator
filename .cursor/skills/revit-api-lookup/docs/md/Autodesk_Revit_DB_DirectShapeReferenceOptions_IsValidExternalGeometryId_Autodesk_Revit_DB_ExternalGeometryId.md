---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeReferenceOptions.IsValidExternalGeometryId(Autodesk.Revit.DB.ExternalGeometryId)
source: html/7c39eef2-bc93-d270-2e5f-c1fbe599d4e6.htm
---
# Autodesk.Revit.DB.DirectShapeReferenceOptions.IsValidExternalGeometryId Method

Validates that the input ExternalGeometryId can be assigned to a direct shape reference.

## Syntax (C#)
```csharp
public static bool IsValidExternalGeometryId(
	ExternalGeometryId externalId
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The ExternalGeometryId to assign to the reference.

## Returns
True if the provided ExternalGeometryId is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

