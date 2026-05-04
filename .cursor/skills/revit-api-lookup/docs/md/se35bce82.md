---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Room.Unplace
zh: 房间
source: html/d5d66eb0-ca3b-6133-48a6-645900addd5f.htm
---
# Autodesk.Revit.DB.Architecture.Room.Unplace Method

**中文**: 房间

Remove the room from its location, but the project still contains the room.
The room can be placed in another location after unplaced.

## Syntax (C#)
```csharp
public void Unplace()
```

## Remarks
Note that current room is changed to unplaced and all corresponding rooms which in other group instance are deleted 
when in group edit mode.

