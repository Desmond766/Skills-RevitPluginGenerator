---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Room.IsPointInRoom(Autodesk.Revit.DB.XYZ)
zh: 房间
source: html/96e29ddf-d6dc-0c40-b036-035c5001b996.htm
---
# Autodesk.Revit.DB.Architecture.Room.IsPointInRoom Method

**中文**: 房间

Determines if a point lies within the volume of the room.

## Syntax (C#)
```csharp
public bool IsPointInRoom(
	XYZ point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - Point to be checked.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the point is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - The coordinates of the point is not a number.

