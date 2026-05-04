---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.GetCurvesInView(Autodesk.Revit.DB.DatumExtentType,Autodesk.Revit.DB.View)
source: html/2f93dd88-baac-8e61-377e-b937f3faaff6.htm
---
# Autodesk.Revit.DB.DatumPlane.GetCurvesInView Method

Gets a collection of curves representing the DatumPlane element in the given view.

## Syntax (C#)
```csharp
public IList<Curve> GetCurvesInView(
	DatumExtentType extentMode,
	View view
)
```

## Parameters
- **extentMode** (`Autodesk.Revit.DB.DatumExtentType`) - The extent type.
- **view** (`Autodesk.Revit.DB.View`) - The view.

## Returns
The curves.

## Remarks
Curves returned for Model extents can be different than curves returned for View-specific extents (2d extents) in the given view.
 In some cases, such as an arc grid in a section view, there will be two identical curves but offset from one another.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The datum plane cannot be visible in the view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

