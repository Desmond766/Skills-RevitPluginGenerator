---
kind: method
id: M:Autodesk.Revit.DB.Document.GetRoomAtPoint(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Phase)
zh: 文档、文件
source: html/7dbcac93-ec82-5f60-4a54-a427f3e1cc1e.htm
---
# Autodesk.Revit.DB.Document.GetRoomAtPoint Method

**中文**: 文档、文件

Gets a room containing the point.

## Syntax (C#)
```csharp
public Room GetRoomAtPoint(
	XYZ point,
	Phase phase
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - Point to be checked.
- **phase** (`Autodesk.Revit.DB.Phase`) - Phase in which the room exists.

## Returns
The room containing the point.

## Remarks
If phase is Nothing nullptr a null reference ( Nothing in Visual Basic) , it will get the room of the last phase.The first one found will be returned. If there is no room containing the point, it returns Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the point is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the coordinates of the point are not number or are Double::MaxValue or Double::MinValue.

