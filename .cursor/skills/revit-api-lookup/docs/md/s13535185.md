---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.HideBubbleInView(Autodesk.Revit.DB.DatumEnds,Autodesk.Revit.DB.View)
source: html/1349dc55-fbac-f114-f94d-42fc5fc10b1f.htm
---
# Autodesk.Revit.DB.DatumPlane.HideBubbleInView Method

Hides the bubble in a view. This method does not apply to Reference planes.

## Syntax (C#)
```csharp
public void HideBubbleInView(
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

