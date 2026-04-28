---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.SetDatumExtentType(Autodesk.Revit.DB.DatumEnds,Autodesk.Revit.DB.View,Autodesk.Revit.DB.DatumExtentType)
source: html/6509627e-dda7-4d3d-eddf-4ed462a1f68c.htm
---
# Autodesk.Revit.DB.DatumPlane.SetDatumExtentType Method

Sets whether the curve representing the datum plane is displayed according to its 3d extents, or else according to a view specific setting.

## Syntax (C#)
```csharp
public void SetDatumExtentType(
	DatumEnds datumEnd,
	View view,
	DatumExtentType extentMode
)
```

## Parameters
- **datumEnd** (`Autodesk.Revit.DB.DatumEnds`) - Specifies one end of the curve representing the datum plane in the view.
- **view** (`Autodesk.Revit.DB.View`) - The view in which to set the datum extent settings.
- **extentMode** (`Autodesk.Revit.DB.DatumExtentType`) - The DatumExtentType.

## Remarks
In a particular view, the datum plane is represented by a curve and the two ends of the curve may have different DatumExtentTypes in that view.
 If the value is changed from DatumExtentType::Model to DatumExtentType::ViewSpecific, then the view specific extents will be identical to the model
 extent until modified.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The datum plane cannot be visible in the view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

