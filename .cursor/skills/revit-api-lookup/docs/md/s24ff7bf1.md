---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.ShowBubbleInView(Autodesk.Revit.DB.DatumEnds,Autodesk.Revit.DB.View)
source: html/e8bbbf7f-38d2-d818-1738-17d844b96162.htm
---
# Autodesk.Revit.DB.DatumPlane.ShowBubbleInView Method

Shows the bubble in a view. This method does not apply to Reference planes.

## Syntax (C#)
```csharp
public void ShowBubbleInView(
	DatumEnds datumEnd,
	View view
)
```

## Parameters
- **datumEnd** (`Autodesk.Revit.DB.DatumEnds`) - The end of the datum plane.
- **view** (`Autodesk.Revit.DB.View`) - The view on which the DatumPlane shows.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The datum plane cannot be visible in the view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This datum plane doesn't support bubble operations.
 -or-
 This DatumPlane doesn't have bubbles shown the view.

