---
kind: method
id: M:Autodesk.Revit.DB.Document.GetSpaceAtPoint(Autodesk.Revit.DB.XYZ)
zh: 文档、文件
source: html/73543682-0f14-1b49-a881-d694aa17192b.htm
---
# Autodesk.Revit.DB.Document.GetSpaceAtPoint Method

**中文**: 文档、文件

Gets a space containing the point.

## Syntax (C#)
```csharp
public Space GetSpaceAtPoint(
	XYZ point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - Point to be checked.

## Returns
The space containing the point.

## Remarks
Surveys only the spaces from the final phase of the project. The first one found will be returned. If there is no space containing the point, it returns Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the point is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the coordinates of the point are not number or are Double::MaxValue or Double::MinValue.

