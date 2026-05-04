---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewRoomTag(Autodesk.Revit.DB.LinkElementId,Autodesk.Revit.DB.UV,Autodesk.Revit.DB.ElementId)
zh: 文档、文件
source: html/9847aafe-42f9-fe8e-5229-c491add7ec46.htm
---
# Autodesk.Revit.Creation.Document.NewRoomTag Method

**中文**: 文档、文件

Creates a new RoomTag referencing a room in the host model or in a Revit link.

## Syntax (C#)
```csharp
public RoomTag NewRoomTag(
	LinkElementId roomId,
	UV point,
	ElementId viewId
)
```

## Parameters
- **roomId** (`Autodesk.Revit.DB.LinkElementId`) - The HostOrLinkElementId of the Room.
- **point** (`Autodesk.Revit.DB.UV`) - A 2D point that defines the tag location on the level of the room.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The id of the view where the tag will be shown. If Nothing nullptr a null reference ( Nothing in Visual Basic) and the room in not in a Revit link, the view of the room will be used.

## Returns
If successful a RoomTag object will be returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - viewId is not associated with a plan view or section view.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - viewId is null and the room is in a linked file.

