---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.GetExternallyTaggedGeometry(Autodesk.Revit.DB.ExternalGeometryId)
source: html/60d0ba59-5345-dbd0-e92a-0f2d71d709de.htm
---
# Autodesk.Revit.DB.DirectShapeType.GetExternallyTaggedGeometry Method

Gets the externally tagged geometry by its external ID that is stored in this DirectShapeType.

## Syntax (C#)
```csharp
public ExternallyTaggedGeometryObject GetExternallyTaggedGeometry(
	ExternalGeometryId externalId
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - The external ID of the externally tagged geometry that should be obtained.

## Returns
The externally tagged geometry.
 Or Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no such externally tagged geometry in the DirectShapeType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

