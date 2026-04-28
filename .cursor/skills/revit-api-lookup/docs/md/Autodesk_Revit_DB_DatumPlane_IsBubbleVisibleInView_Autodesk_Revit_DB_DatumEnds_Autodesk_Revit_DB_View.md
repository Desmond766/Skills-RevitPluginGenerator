---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.IsBubbleVisibleInView(Autodesk.Revit.DB.DatumEnds,Autodesk.Revit.DB.View)
source: html/75c39be6-5f78-9dd2-061e-13b846e739d5.htm
---
# Autodesk.Revit.DB.DatumPlane.IsBubbleVisibleInView Method

Identifies if the bubble is visible or not in a view.

## Syntax (C#)
```csharp
public bool IsBubbleVisibleInView(
	DatumEnds datumEnd,
	View view
)
```

## Parameters
- **datumEnd** (`Autodesk.Revit.DB.DatumEnds`) - The end of the datum plane.
- **view** (`Autodesk.Revit.DB.View`) - The view on which the DatumPlane shows.

## Returns
True if the bubble is visible, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The datum plane cannot be visible in the view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This datum plane doesn't support bubble operations.

