---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.SetLeader(Autodesk.Revit.DB.DatumEnds,Autodesk.Revit.DB.View,Autodesk.Revit.DB.Leader)
source: html/a771f300-9d74-3ed7-ba1b-b0961e6c36b3.htm
---
# Autodesk.Revit.DB.DatumPlane.SetLeader Method

Sets the leader to the indicated end of the datum plane. This method does not apply to Reference planes (which do not support leaders).

## Syntax (C#)
```csharp
public void SetLeader(
	DatumEnds datumEnd,
	View view,
	Leader pLeader
)
```

## Parameters
- **datumEnd** (`Autodesk.Revit.DB.DatumEnds`) - The end of the datum plane.
- **view** (`Autodesk.Revit.DB.View`) - The view on which the DatumPlane shows.
- **pLeader** (`Autodesk.Revit.DB.Leader`) - The Leader for setting the datum plane.

## Remarks
The leader can be applied only to ends where the bubble is set to be shown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One of the conditions is not valid: the input leader and view is not null;
 The leader End, Elbow, Anchor should be in the view;
 the End of leader should be in the datum plane curves; Elbow is between End and Anchor.
 -or-
 The datum plane cannot be visible in the view.
 -or-
 The bubble is not visible at the datumEnd of the datum plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

