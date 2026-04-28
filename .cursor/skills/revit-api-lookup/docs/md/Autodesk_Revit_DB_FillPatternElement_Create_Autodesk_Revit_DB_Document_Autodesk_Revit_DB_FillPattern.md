---
kind: method
id: M:Autodesk.Revit.DB.FillPatternElement.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FillPattern)
zh: 创建、新建、生成、建立、新增
source: html/abce94ee-40a0-225e-f3dd-29d46218fba0.htm
---
# Autodesk.Revit.DB.FillPatternElement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new FillPatternElement.

## Syntax (C#)
```csharp
public static FillPatternElement Create(
	Document document,
	FillPattern fillPattern
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the FillPatternElement.
- **fillPattern** (`Autodesk.Revit.DB.FillPattern`) - The FillPattern associated to the newly created FillPatternElement.

## Returns
The newly created FillPatternElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fillPattern does not have a valid Target.
 -or-
 fillPattern does not have a valid Name.
 -or-
 fillPattern is a solid fill pattern.
 -or-
 fillPattern contains FillGrids with a zero Offset.
 -or-
 The name of the fillPattern already exists.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

