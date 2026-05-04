---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewGutter(Autodesk.Revit.DB.Architecture.GutterType,Autodesk.Revit.DB.Reference)
zh: 文档、文件
source: html/5213092c-0c83-5ba5-4f3a-871a1a93f368.htm
---
# Autodesk.Revit.Creation.Document.NewGutter Method

**中文**: 文档、文件

Creates a gutter along a reference.

## Syntax (C#)
```csharp
public Gutter NewGutter(
	GutterType GutterType,
	Reference reference
)
```

## Parameters
- **GutterType** (`Autodesk.Revit.DB.Architecture.GutterType`) - The type of the gutter to create
- **reference** (`Autodesk.Revit.DB.Reference`) - A planar line or arc that represents the place where you
want to place the gutter.

## Returns
If successful a new gutter object within the project, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the gutter type does not exist in the given document.

