---
kind: property
id: P:Autodesk.Revit.DB.Architecture.RoomTag.Room
zh: 房间
source: html/d6156ddf-27d5-5311-0887-5d8a326e9e99.htm
---
# Autodesk.Revit.DB.Architecture.RoomTag.Room Property

**中文**: 房间

The room that the tag is associated with.

## Syntax (C#)
```csharp
public Room Room { get; }
```

## Remarks
In rare cases, the tag may not be associated to a room. The property will
be Nothing nullptr a null reference ( Nothing in Visual Basic) in these situations.

