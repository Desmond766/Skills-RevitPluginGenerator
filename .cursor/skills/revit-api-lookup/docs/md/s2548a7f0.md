---
kind: method
id: M:Autodesk.Revit.DB.ViewShapeBuilder.ValidateShape(System.Collections.Generic.IList{Autodesk.Revit.DB.GeometryObject},Autodesk.Revit.DB.DirectShapeTargetViewType)
source: html/6d5a7e8f-b0eb-51bc-7963-fa034792fe66.htm
---
# Autodesk.Revit.DB.ViewShapeBuilder.ValidateShape Method

Validates a shape represented as a collection of geometry objects for use as a view-specific shape.
 The objects are expected to be either points, curves or polylines.
 Curves are expected to be flat and lie in a plane perpendicular to view normal as defined by view type.

## Syntax (C#)
```csharp
public static bool ValidateShape(
	IList<GeometryObject> shape,
	DirectShapeTargetViewType targetViewType
)
```

## Parameters
- **shape** (`System.Collections.Generic.IList < GeometryObject >`)
- **targetViewType** (`Autodesk.Revit.DB.DirectShapeTargetViewType`)

## Returns
Returns true if %shape% may be used as a view-specific shape representation, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - targetViewType is not DirectShapeTargetViewType::Plan
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

