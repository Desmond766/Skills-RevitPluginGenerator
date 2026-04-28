---
kind: method
id: M:Autodesk.Revit.DB.ExternallyTaggedBRep.GetTaggedGeometry(Autodesk.Revit.DB.ExternalGeometryId)
source: html/80dfe0b5-6912-6423-b2e8-a2d3b8c13590.htm
---
# Autodesk.Revit.DB.ExternallyTaggedBRep.GetTaggedGeometry Method

Returns the externally tagged geometry object.

## Syntax (C#)
```csharp
public GeometryObject GetTaggedGeometry(
	ExternalGeometryId externalId
)
```

## Parameters
- **externalId** (`Autodesk.Revit.DB.ExternalGeometryId`) - An external tag that may match a geometry object (i.e face/edge) in this Solid.

## Returns
Returns the geometry object that matches the external tag.
 If no such object is found, this method will return null.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

