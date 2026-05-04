---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.GetDatumExtentTypeInView(Autodesk.Revit.DB.DatumEnds,Autodesk.Revit.DB.View)
source: html/b3498ccf-1180-e0fd-502c-6c767f5b42cc.htm
---
# Autodesk.Revit.DB.DatumPlane.GetDatumExtentTypeInView Method

Identifies whether the curve representing the datum plane is displayed according to its actual 3d extents, or else according to a view specific setting.

## Syntax (C#)
```csharp
public DatumExtentType GetDatumExtentTypeInView(
	DatumEnds datumEnd,
	View view
)
```

## Parameters
- **datumEnd** (`Autodesk.Revit.DB.DatumEnds`) - Specifies one end of the curve representing the datum plane in the view.
- **view** (`Autodesk.Revit.DB.View`) - The view in which to evaluate the datum extent settings.

## Returns
The extent type.

## Remarks
In a particular view, the datum plane is represented by a curve and the two ends of the curve may have different DatumExtentTypes in that view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The datum plane cannot be visible in the view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

