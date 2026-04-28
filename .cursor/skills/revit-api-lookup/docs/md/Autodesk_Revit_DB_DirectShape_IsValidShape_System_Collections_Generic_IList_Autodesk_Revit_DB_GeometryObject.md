---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.IsValidShape(System.Collections.Generic.IList{Autodesk.Revit.DB.GeometryObject})
source: html/50303032-c170-8d01-754f-b52a698c309a.htm
---
# Autodesk.Revit.DB.DirectShape.IsValidShape Method

Validates shape to be stored in a DirectShape. Supercedes and extends IsValidGeometry().

## Syntax (C#)
```csharp
public bool IsValidShape(
	IList<GeometryObject> shape
)
```

## Parameters
- **shape** (`System.Collections.Generic.IList < GeometryObject >`) - Shape to be validated represented as a collection of GeometryObjects.
 The supported types of GeometryObjects are: Solid, Mesh, GeometryInstance, Point and Curve.

## Returns
True if the supplied shape passes the validation criteria.

## Remarks
This function calls IsValidShape(GeometryObject) to validate each object in the list.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

