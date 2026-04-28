---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.SetShape(System.Collections.Generic.IList{Autodesk.Revit.DB.GeometryObject})
source: html/8d62b427-bc3c-e772-f6b0-0aed603cc1c9.htm
---
# Autodesk.Revit.DB.DirectShape.SetShape Method

Builds the shape of this object from the supplied collection of GeometryObjects. The objects are copied.
 If the new shape is identical to the old one, the old shape will be kept.

## Syntax (C#)
```csharp
public void SetShape(
	IList<GeometryObject> pGeomArr
)
```

## Parameters
- **pGeomArr** (`System.Collections.Generic.IList < GeometryObject >`) - Shape of this object expressed as a collection of GeometryObjects.
 The supported types of GeometryObjects are: Solid, Mesh, GeometryInstance, Point and Curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - At least one member of pGeomArr does not satisfy DirectShape validation criteria.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

