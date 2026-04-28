---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.GetLeader(Autodesk.Revit.DB.DatumEnds,Autodesk.Revit.DB.View)
source: html/4f5ebf97-8a85-bd5b-0edd-f2f0f6b18cb2.htm
---
# Autodesk.Revit.DB.DatumPlane.GetLeader Method

Gets a copy of the leader applied to the indicated end of the datum plane. This method does not apply to Reference planes (which do not support leaders).

## Syntax (C#)
```csharp
public Leader GetLeader(
	DatumEnds datumEnd,
	View view
)
```

## Parameters
- **datumEnd** (`Autodesk.Revit.DB.DatumEnds`) - The end of the datum plane.
- **view** (`Autodesk.Revit.DB.View`) - The view on which the DatumPlane shows.

## Returns
The Leader of the datum plane. Null will return if no leader applied.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The datum plane cannot be visible in the view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This datum plane has no leaders.

