---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.GetExternallyTaggedReference(Autodesk.Revit.DB.ExternalGeometryId)
source: html/22cf5a24-787e-ced2-daa4-8f23d1f2b96b.htm
---
# Autodesk.Revit.DB.DirectShape.GetExternallyTaggedReference Method

Retrieve a Reference to reference geometry of the DirectShape that is associated with a particular ExternalGeometryId.

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

