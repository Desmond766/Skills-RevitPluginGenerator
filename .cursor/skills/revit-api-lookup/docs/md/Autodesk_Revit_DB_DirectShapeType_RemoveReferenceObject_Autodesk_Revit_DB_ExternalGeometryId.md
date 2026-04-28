---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.RemoveReferenceObject(Autodesk.Revit.DB.ExternalGeometryId)
source: html/d55e1f4f-d852-b807-05e2-b7d2ed41c133.htm
---
# Autodesk.Revit.DB.DirectShapeType.RemoveReferenceObject Method

Removes any reference object associated with the provided ExternalGeometryId from the DirectShapeType.
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

