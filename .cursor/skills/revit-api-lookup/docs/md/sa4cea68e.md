---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.IsLeaderValid(Autodesk.Revit.DB.DatumEnds,Autodesk.Revit.DB.View,Autodesk.Revit.DB.Leader)
source: html/321a1f1a-61ef-3e7a-e87a-47d4cd4fd014.htm
---
# Autodesk.Revit.DB.DatumPlane.IsLeaderValid Method

Identifies if the leader valid or not for this DatumPlane. This method does not apply to Reference planes (which do not support leaders).

## Syntax (C#)
```csharp
public bool IsLeaderValid(
	DatumEnds datumEnd,
	View view,
	Leader leader
)
```

## Parameters
- **datumEnd** (`Autodesk.Revit.DB.DatumEnds`) - The end of the datum plane.
- **view** (`Autodesk.Revit.DB.View`) - The view on which the DatumPlane shows.
- **leader** (`Autodesk.Revit.DB.Leader`) - The Leader for setting the datum plane.

## Returns
True if the leader is valid for set leader, false otherwise.

## Remarks
If the view or leader is null, it will throw ArgumentNullException;
 A valid leader meets the following conditions:
 The leader's End, Elbow and Anchor should lie in the View's plane The End of the leader should be on the datum plane's curve(s) The Elbow of the leader should be between the End and Anchor

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This datum plane has no leaders.
 -or-
 The DatumPlane should not have a leader.

