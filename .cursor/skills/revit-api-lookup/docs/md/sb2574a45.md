---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.AppendShape(System.Collections.Generic.IList{Autodesk.Revit.DB.GeometryObject},Autodesk.Revit.DB.DirectShapeTargetViewType)
source: html/d56956bb-c2ec-8504-fb6a-717e26e1f891.htm
---
# Autodesk.Revit.DB.DirectShape.AppendShape Method

Appends the collection of GeometryObjects into the model or view specific shape representation stored in this DirectShape.
 Passing DirectShapeTargetViewType.Default as view type will cause the model shape to be updated.

## Syntax (C#)
```csharp
public void AppendShape(
	IList<GeometryObject> pGeomArr,
	DirectShapeTargetViewType viewType
)
```

## Parameters
- **pGeomArr** (`System.Collections.Generic.IList < GeometryObject >`) - Shape expressed as a collection of GeometryObjects.
 For viewType = DirectShapeTargetViewType::Default, the supported types of GeometryObjects are: Solid, Mesh, GeometryInstance, Point and Curve.
 For viewType = DirectShapeTargetViewType::Plan, the supported types of GeometryObjects are: Point and Curve.
- **viewType** (`Autodesk.Revit.DB.DirectShapeTargetViewType`) - Passing DirectShapeTargetViewType.Default as view type will cause the default shape to be appended.

## Remarks
The existing shape will not be cleared by this function, and intersecting or overlapped geometry will not be
 joined with the appended geometry. It is up to the caller to ensure that the combination of geometry
 will have the correct appearance in Revit.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - At least one member of pGeomArr does not satisfy DirectShape validation criteria.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

