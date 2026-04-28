---
kind: method
id: M:Autodesk.Revit.DB.Grid.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Arc)
zh: 创建、新建、生成、建立、新增
source: html/2f1e2722-d302-eb69-818a-44e0e169140c.htm
---
# Autodesk.Revit.DB.Grid.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new radial grid line.

## Syntax (C#)
```csharp
public static Grid Create(
	Document document,
	Arc arc
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new instance is created.
- **arc** (`Autodesk.Revit.DB.Arc`) - An arc object that represents the location of the new grid line.

## Returns
The newly created grid line.

## Remarks
The arc should be on a horizontal plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 The input arc is not on horizontal plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

