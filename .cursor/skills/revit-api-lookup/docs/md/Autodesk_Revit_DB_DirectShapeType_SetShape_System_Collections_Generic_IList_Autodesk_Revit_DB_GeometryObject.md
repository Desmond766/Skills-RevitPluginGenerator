---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.SetShape(System.Collections.Generic.IList{Autodesk.Revit.DB.GeometryObject})
source: html/5c2bf291-537e-0de1-4982-87a7e20c217a.htm
---
# Autodesk.Revit.DB.DirectShapeType.SetShape Method

Builds the type shape from the supplied collection of GeometryObjects. The objects are copied.
 If the new shape is identical to the old one, the old shape will be kept.

## Syntax (C#)
```csharp
public void SetShape(
	IList<GeometryObject> pGeomArr
)
```

## Parameters
- **pGeomArr** (`System.Collections.Generic.IList < GeometryObject >`) - Shape of this object expressed as a collection of GeometryObjects. These will be copied.
 Shape and Category should be consistent: geometry supplied as shape should be valid for the Category
 the type object is associated with.
 The supported types of GeometryObjects are: Solid, Mesh, GeometryInstance, Point, Curve and PolyLine.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - At least one member of pGeomArr does not satisfy DirectShapeType validation criteria.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

