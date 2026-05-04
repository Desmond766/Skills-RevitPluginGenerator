---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewOpening(Autodesk.Revit.DB.Level,Autodesk.Revit.DB.Level,Autodesk.Revit.DB.CurveArray)
zh: 文档、文件
source: html/871161b1-a154-be20-f256-6f9141100905.htm
---
# Autodesk.Revit.Creation.Document.NewOpening Method

**中文**: 文档、文件

Creates a new shaft opening between a set of levels.

## Syntax (C#)
```csharp
public Opening NewOpening(
	Level bottomLevel,
	Level topLevel,
	CurveArray profile
)
```

## Parameters
- **bottomLevel** (`Autodesk.Revit.DB.Level`) - bottom level
- **topLevel** (`Autodesk.Revit.DB.Level`) - top level
- **profile** (`Autodesk.Revit.DB.CurveArray`) - profile of the opening.

## Returns
If successful, an Opening object is returned.

## Remarks
This method forms an opening on floor, ceiling and roof. Make sure topLevel is higher than bottomLevel, otherwise an exception will be returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the bottom level does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the top level does not exist in the given document.

