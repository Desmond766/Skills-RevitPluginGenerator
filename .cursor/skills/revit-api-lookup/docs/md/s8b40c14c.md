---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.SetShape(System.Collections.Generic.IList{Autodesk.Revit.DB.GeometryObject},Autodesk.Revit.DB.DirectShapeTargetViewType)
source: html/de35fe1d-a1e4-b003-ff87-66978f6a19f0.htm
---
# Autodesk.Revit.DB.DirectShape.SetShape Method

Builds the shape of this object from the supplied collection of GeometryObjects. The objects are copied.
 If the new shape is identical to the old one, the old shape will be kept.

## Syntax (C#)
```csharp
public void SetShape(
	IList<GeometryObject> pGeomArr,
	DirectShapeTargetViewType viewType
)
```

## Parameters
- **pGeomArr** (`System.Collections.Generic.IList < GeometryObject >`) - Shape of this object expressed as a collection of GeometryObjects.
 For viewType = DirectShapeTargetViewType::Default, the supported types of GeometryObjects are: Solid, Mesh, GeometryInstance, Point and Curve.
 For viewType = DirectShapeTargetViewType::Plan, the supported types of GeometryObjects are: Point and Curve.
- **viewType** (`Autodesk.Revit.DB.DirectShapeTargetViewType`) - Optional: set a view-specific shape representation that will be used in views of that type only.
 Passing DirectShapeTargetViewType::Default as view type will cause the default shape to be set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - At least one member of pGeomArr does not satisfy DirectShape validation criteria.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

