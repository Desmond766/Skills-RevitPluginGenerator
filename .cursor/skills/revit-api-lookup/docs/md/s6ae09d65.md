---
kind: method
id: M:Autodesk.Revit.DB.Document.GetSpaceAtPoint(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Phase)
zh: 文档、文件
source: html/aeb0a0c9-2d9d-1705-ad93-31956a63704d.htm
---
# Autodesk.Revit.DB.Document.GetSpaceAtPoint Method

**中文**: 文档、文件

Gets a space containing the point.

## Syntax (C#)
```csharp
public Space GetSpaceAtPoint(
	XYZ point,
	Phase phase
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - Point to be checked.
- **phase** (`Autodesk.Revit.DB.Phase`) - Phase in which the space exists.

## Returns
The space containing the point.

## Remarks
If phase is Nothing nullptr a null reference ( Nothing in Visual Basic) , it will get the space of the last phase.The first one found will be returned. If there is no space containing the point, it returns Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the point is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the coordinates of the point are not number or are Double::MaxValue or Double::MinValue.

