---
kind: property
id: P:Autodesk.Revit.DB.Architecture.RoomTag.TaggedRoomId
source: html/05449236-668c-3eff-9bf6-33b71b561185.htm
---
# Autodesk.Revit.DB.Architecture.RoomTag.TaggedRoomId Property

The LinkElementId of the tagged room.

## Syntax (C#)
```csharp
public LinkElementId TaggedRoomId { get; }
```

## Remarks
If there is no tagged room in a linked document so the RoomTag is orphaned, LinkElementId will be InvalidElementId.

