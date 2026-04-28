---
kind: property
id: P:Autodesk.Revit.DB.SpatialElementTag.TagHeadPosition
source: html/4a5d8e7d-2a08-faec-4266-6773280aeb61.htm
---
# Autodesk.Revit.DB.SpatialElementTag.TagHeadPosition Property

The position of the tag's head.

## Syntax (C#)
```csharp
public XYZ TagHeadPosition { get; set; }
```

## Remarks
Returns the end point of the tag leader.
 Leader end point must be located inside of a room, space or an area.
 Use Room.IsPointInRoom or Space.IsPointInSpace method to check whether the leaderEnd is located in the host element or not.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: Head position of the tag with no leader could not be located outside of the host element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: SpatialElementTag is pinned.
 -or-
 When setting this property: SpatialElementTag is orphaned.

