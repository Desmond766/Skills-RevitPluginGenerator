---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.GetExternallyTaggedReference(Autodesk.Revit.DB.ExternalGeometryId)
source: html/612c51c5-c97d-19ce-2ced-209fd6e7a92a.htm
---
# Autodesk.Revit.DB.DirectShapeType.GetExternallyTaggedReference Method

Retrieve a Reference to reference geometry of the DirectShapeType that is associated with a particular ExternalGeometryId.

## Syntax (C#)
```csharp
public Reference GetExternallyTaggedReference(
	ExternalGeometryId externalId
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The ExternalGeometryId of the requested reference object.

## Returns
A Reference to the externally tagged reference GeometryObject having the provided external ID
 or Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no reference geometry having the external ID.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

