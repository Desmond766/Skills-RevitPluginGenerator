---
kind: property
id: P:Autodesk.Revit.DB.Architecture.RoomTag.TaggedLocalRoomId
source: html/e6144145-8ac1-5b96-f006-717103038e7c.htm
---
# Autodesk.Revit.DB.Architecture.RoomTag.TaggedLocalRoomId Property

The ElementId of the tagged room.

## Syntax (C#)
```csharp
public ElementId TaggedLocalRoomId { get; }
```

## Remarks
If there is no tagged room so the RoomTag is orphaned, ElementId will be InvalidElementId.

