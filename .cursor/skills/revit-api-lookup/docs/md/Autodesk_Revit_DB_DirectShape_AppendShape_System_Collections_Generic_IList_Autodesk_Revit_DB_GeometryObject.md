---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.AppendShape(System.Collections.Generic.IList{Autodesk.Revit.DB.GeometryObject})
source: html/c4ab9ba7-2507-2b4a-f660-8e8337212644.htm
---
# Autodesk.Revit.DB.DirectShape.AppendShape Method

Appends the collection of GeometryObjects into the model shape representation stored in this DirectShape.

## Syntax (C#)
```csharp
public void AppendShape(
	IList<GeometryObject> pGeomArr
)
```

## Parameters
- **pGeomArr** (`System.Collections.Generic.IList < GeometryObject >`) - Shape expressed as a collection of GeometryObjects.
 The supported types of GeometryObjects are: Solid, Mesh, GeometryInstance, Point and Curve.

## Remarks
The existing shape will not be cleared by this function, and intersecting or overlapped geometry will not be
 joined with the appended geometry. It is up to the caller to ensure that the combination of geometry
 will have the correct appearance in Revit.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - At least one member of pGeomArr does not satisfy DirectShape validation criteria.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

