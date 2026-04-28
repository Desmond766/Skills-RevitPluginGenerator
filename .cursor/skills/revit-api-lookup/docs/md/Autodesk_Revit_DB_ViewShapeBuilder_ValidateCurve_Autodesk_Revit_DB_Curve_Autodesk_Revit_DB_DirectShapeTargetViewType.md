---
kind: method
id: M:Autodesk.Revit.DB.ViewShapeBuilder.ValidateCurve(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.DirectShapeTargetViewType)
source: html/3d36d4c2-f736-db7b-ae6a-945f89dce0b9.htm
---
# Autodesk.Revit.DB.ViewShapeBuilder.ValidateCurve Method

Validates curve to be added to the view-specific shape being constructed. Called by AddCurve() to validate input.
 This function may be used to pre-validate the geometry being added to avoid AddCurve() throwing an InvalidArgumentException

## Syntax (C#)
```csharp
public static bool ValidateCurve(
	Curve GCurve,
	DirectShapeTargetViewType targetViewType
)
```

## Parameters
- **GCurve** (`Autodesk.Revit.DB.Curve`) - Curve object to be validated.
- **targetViewType** (`Autodesk.Revit.DB.DirectShapeTargetViewType`) - View type for which this curve is intended.

## Returns
True is %GCurve% is acceptable as a part of view-specific shape representation.

## Remarks
Validation conditions depend on the type of view for which the shape representation is intended.
 For plan views, a curve is expected to be planar and non-degenerate (e.g., NOT a circle of zero radius).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

