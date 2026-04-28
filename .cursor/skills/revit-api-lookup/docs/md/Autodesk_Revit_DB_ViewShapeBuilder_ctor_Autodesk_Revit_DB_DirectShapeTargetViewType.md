---
kind: method
id: M:Autodesk.Revit.DB.ViewShapeBuilder.#ctor(Autodesk.Revit.DB.DirectShapeTargetViewType)
source: html/5aaeefcb-2f36-6f44-0c84-f48fad404a99.htm
---
# Autodesk.Revit.DB.ViewShapeBuilder.#ctor Method

A constructor for an ViewShapeBuilder object that takes a view type. It will infer the view normal from view type.
 View normal and view type are used to validate the geometry to be stored as a view-specific shape representation of a DirectShape object.

## Syntax (C#)
```csharp
public ViewShapeBuilder(
	DirectShapeTargetViewType targetViewType
)
```

## Parameters
- **targetViewType** (`Autodesk.Revit.DB.DirectShapeTargetViewType`) - View type for which this shape representation is intended. Currently limited to Plan Views.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - targetViewType is not DirectShapeTargetViewType::Plan
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

