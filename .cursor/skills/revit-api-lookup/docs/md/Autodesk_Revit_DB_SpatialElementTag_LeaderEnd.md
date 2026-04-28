---
kind: property
id: P:Autodesk.Revit.DB.SpatialElementTag.LeaderEnd
source: html/32bac43c-9a67-7d69-4068-eb4fe34f6acb.htm
---
# Autodesk.Revit.DB.SpatialElementTag.LeaderEnd Property

The position of the leader's end.

## Syntax (C#)
```csharp
public XYZ LeaderEnd { get; set; }
```

## Remarks
Returns the end point of the tag leader.
 Leader end point must be located inside of a room, space or an area.
 Use Room.IsPointInRoom or Space.IsPointInSpace method to check whether the leaderEnd is located in the host element or not.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The point is located outside of the spatial element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no leader for this tag.
 -or-
 When setting this property: SpatialElementTag is pinned.
 -or-
 When setting this property: SpatialElementTag is orphaned.

