---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.AddLeader(Autodesk.Revit.DB.DatumEnds,Autodesk.Revit.DB.View)
source: html/0373eec6-5963-b036-e816-de4d93f2f5f1.htm
---
# Autodesk.Revit.DB.DatumPlane.AddLeader Method

Adds a default Leader for the indicated end of the datum plane. This method does not apply to Reference planes (which do not support leaders).

## Syntax (C#)
```csharp
public Leader AddLeader(
	DatumEnds datumEnd,
	View view
)
```

## Parameters
- **datumEnd** (`Autodesk.Revit.DB.DatumEnds`) - The end of the datum plane.
- **view** (`Autodesk.Revit.DB.View`) - The view on which the DatumPlane shows.

## Returns
The Leader of the datum plane. Null will return if the view is null.

## Remarks
The leader can be added only to ends where the bubble is set to be shown and does not have a leader applied.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The datum plane cannot be visible in the view.
 -or-
 The bubble is not visible at the datumEnd of the datum plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This datum plane has no leaders.
 -or-
 The DatumPlane already has a leader applied.

