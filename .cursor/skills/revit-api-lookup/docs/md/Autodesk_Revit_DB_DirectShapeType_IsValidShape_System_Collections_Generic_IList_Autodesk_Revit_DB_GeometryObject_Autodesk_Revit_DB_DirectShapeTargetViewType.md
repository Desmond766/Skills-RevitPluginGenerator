---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.IsValidShape(System.Collections.Generic.IList{Autodesk.Revit.DB.GeometryObject},Autodesk.Revit.DB.DirectShapeTargetViewType)
source: html/f87b331e-3a65-cbfb-8652-1c82a5d57883.htm
---
# Autodesk.Revit.DB.DirectShapeType.IsValidShape Method

Validates view-specific shape to be stored in a DirectShapeType. Expects a non-default view type.

## Syntax (C#)
```csharp
public bool IsValidShape(
	IList<GeometryObject> shape,
	DirectShapeTargetViewType viewType
)
```

## Parameters
- **shape** (`System.Collections.Generic.IList < GeometryObject >`) - Shape of this object expressed as a collection of GeometryObjects.
 For viewType = DirectShapeTargetViewType::Default, the supported types of GeometryObjects are: Solid, Mesh, GeometryInstance, Point, Curve and PolyLine.
 For viewType = DirectShapeTargetViewType::Plan, the supported types of GeometryObjects are: Point and Curve.
- **viewType** (`Autodesk.Revit.DB.DirectShapeTargetViewType`) - The view type this shape is intended for.

## Returns
True if the supplied shape passes the validation criteria.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

