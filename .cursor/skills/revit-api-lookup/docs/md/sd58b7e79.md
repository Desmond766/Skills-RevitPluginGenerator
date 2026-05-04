---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.IsValidShape(System.Collections.Generic.IList{Autodesk.Revit.DB.GeometryObject})
source: html/89861b7d-c844-45ff-e9f3-a804602c842e.htm
---
# Autodesk.Revit.DB.DirectShapeType.IsValidShape Method

Validates shape to be stored in a DirectShapeType.

## Syntax (C#)
```csharp
public bool IsValidShape(
	IList<GeometryObject> shape
)
```

## Parameters
- **shape** (`System.Collections.Generic.IList < GeometryObject >`) - Shape to be validated represented as a collection of GeometryObjects.
 The supported types of GeometryObjects are: Solid, Mesh, GeometryInstance, Point, Curve and PolyLine.

## Returns
True if the supplied shape passes the validation criteria.

## Remarks
This function calls IsValidShape(GeometryObject) to validate each object in the list.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

