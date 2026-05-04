---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewGutter(Autodesk.Revit.DB.Architecture.GutterType,Autodesk.Revit.DB.ReferenceArray)
zh: 文档、文件
source: html/46c49562-965d-6819-d2c4-05d1211fc960.htm
---
# Autodesk.Revit.Creation.Document.NewGutter Method

**中文**: 文档、文件

Creates a gutter along a reference array.

## Syntax (C#)
```csharp
public Gutter NewGutter(
	GutterType GutterType,
	ReferenceArray references
)
```

## Parameters
- **GutterType** (`Autodesk.Revit.DB.Architecture.GutterType`) - The type of the gutter to create
- **references** (`Autodesk.Revit.DB.ReferenceArray`) - An array of planar lines and arcs that represents the place where you
want to place the gutter.

## Returns
If successful a new gutter object within the project, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the gutter type does not exist in the given document.

