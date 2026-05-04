---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.HasBubbleInView(Autodesk.Revit.DB.DatumEnds,Autodesk.Revit.DB.View)
source: html/c216fb35-eb3b-6097-e866-989dfb1d433e.htm
---
# Autodesk.Revit.DB.DatumPlane.HasBubbleInView Method

Identifies if the DatumPlane has bubble or not.

## Syntax (C#)
```csharp
public bool HasBubbleInView(
	DatumEnds datumEnd,
	View view
)
```

## Parameters
- **datumEnd** (`Autodesk.Revit.DB.DatumEnds`) - The end of the datum plane.
- **view** (`Autodesk.Revit.DB.View`) - The view on which the DatumPlane shows.

## Returns
True if the DatumPlane has bubble, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This datum plane doesn't support bubble operations.

