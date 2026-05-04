---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.IsValidShape(Autodesk.Revit.DB.ExternallyTaggedGeometryObject)
source: html/28a0897c-2772-99be-74fc-ec4eef285457.htm
---
# Autodesk.Revit.DB.DirectShapeType.IsValidShape Method

Validates shape to be stored in a DirectShapeType.

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

