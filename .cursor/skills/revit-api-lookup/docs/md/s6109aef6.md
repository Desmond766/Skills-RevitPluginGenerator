---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.SetCurveInView(Autodesk.Revit.DB.DatumExtentType,Autodesk.Revit.DB.View,Autodesk.Revit.DB.Curve)
source: html/eaff0038-34f2-03cf-185b-2872cffb84af.htm
---
# Autodesk.Revit.DB.DatumPlane.SetCurveInView Method

Sets the extents to match the curve.

## Syntax (C#)
```csharp
public void SetCurveInView(
	DatumExtentType extentMode,
	View view,
	Curve curve
)
```

## Parameters
- **extentMode** (`Autodesk.Revit.DB.DatumExtentType`) - The extent type.
- **view** (`Autodesk.Revit.DB.View`) - The view.
- **curve** (`Autodesk.Revit.DB.Curve`) - The curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The datum plane cannot be visible in the view.
 -or-
 The curve is unbound or not coincident with the original one of the datum plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

