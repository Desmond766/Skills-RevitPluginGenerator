---
kind: method
id: M:Autodesk.Revit.DB.Document.GetRoomAtPoint(Autodesk.Revit.DB.XYZ)
zh: 文档、文件
source: html/656d34c2-1e53-7278-ab83-fefaff7f40a4.htm
---
# Autodesk.Revit.DB.Document.GetRoomAtPoint Method

**中文**: 文档、文件

Gets a room containing the point.

## Syntax (C#)
```csharp
public Room GetRoomAtPoint(
	XYZ point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - Point to be checked.

## Returns
The room containing the point.

## Remarks
Surveys only the rooms from the final phase of the project. The first one found will be returned. If there is no room containing the point, it returns Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the point is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the coordinates of the point are not number or are Double::MaxValue or Double::MinValue.

