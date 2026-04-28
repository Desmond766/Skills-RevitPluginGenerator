---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.RemoveReferenceObject(Autodesk.Revit.DB.ExternalGeometryId)
source: html/325786b7-1d11-0a77-203c-ebfc4bd0acf4.htm
---
# Autodesk.Revit.DB.DirectShape.RemoveReferenceObject Method

Removes any reference object associated with the provided ExternalGeometryId from the DirectShape.
 Nothing is done if no reference object has the given external ID or if the external ID is an empty string.

## Syntax (C#)
```csharp
public void RemoveReferenceObject(
	ExternalGeometryId externalId
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The ExternalGeometryId of the reference object to be removed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

