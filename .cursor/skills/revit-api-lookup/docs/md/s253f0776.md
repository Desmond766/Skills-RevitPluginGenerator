---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.IsValidShape(Autodesk.Revit.DB.ExternallyTaggedGeometryObject)
source: html/8139f7b0-6cda-213f-3d9b-f2576ef8e2c4.htm
---
# Autodesk.Revit.DB.DirectShape.IsValidShape Method

Validates shape to be stored in a DirectShape.

## Syntax (C#)
```csharp
public bool IsValidShape(
	ExternallyTaggedGeometryObject externallyTaggedGeometry
)
```

## Parameters
- **externallyTaggedGeometry** (`Autodesk.Revit.DB.ExternallyTaggedGeometryObject`) - The supported types of GeometryObjects are: Solid, Mesh, GeometryInstance, Point and Curve.

## Returns
True if the supplied shape passes the validation criteria.

## Remarks
This function uses the same criteria as IsValidShape(GeometryObject).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

