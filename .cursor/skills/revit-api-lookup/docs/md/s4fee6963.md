---
kind: method
id: M:Autodesk.Revit.DB.Grid.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Line)
zh: 创建、新建、生成、建立、新增
source: html/462cb588-9811-e464-0fe9-13226a2fc8f7.htm
---
# Autodesk.Revit.DB.Grid.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new grid line.

## Syntax (C#)
```csharp
public static Grid Create(
	Document document,
	Line line
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new instance is created.
- **line** (`Autodesk.Revit.DB.Line`) - A line which represents the location of the grid line.

## Returns
The newly created grid line.

## Remarks
The line should be on a horizontal plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 The input line is not on horizontal plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

