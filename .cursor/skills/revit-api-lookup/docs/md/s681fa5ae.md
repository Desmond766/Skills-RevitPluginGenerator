---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.IsCurveValidInView(Autodesk.Revit.DB.DatumExtentType,Autodesk.Revit.DB.View,Autodesk.Revit.DB.Curve)
source: html/2fb3c757-0555-d2ba-2cd2-9399bf238735.htm
---
# Autodesk.Revit.DB.DatumPlane.IsCurveValidInView Method

Checks if the curve is valid to be as the extents for the datum plane in a view.
 The curve must be bound and coincident with the original one of the datum plane.

## Syntax (C#)
```csharp
public bool IsCurveValidInView(
	DatumExtentType extentMode,
	View view,
	Curve curve
)
```

## Parameters
- **extentMode** (`Autodesk.Revit.DB.DatumExtentType`) - The extent type.
- **view** (`Autodesk.Revit.DB.View`) - The view.
- **curve** (`Autodesk.Revit.DB.Curve`) - The curve.

## Returns
True if it is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

