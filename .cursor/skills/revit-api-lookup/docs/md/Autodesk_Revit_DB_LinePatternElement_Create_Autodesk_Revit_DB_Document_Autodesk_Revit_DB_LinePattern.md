---
kind: method
id: M:Autodesk.Revit.DB.LinePatternElement.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.LinePattern)
zh: 创建、新建、生成、建立、新增
source: html/8fda7258-a19d-c0b6-fe70-25da08b8ef63.htm
---
# Autodesk.Revit.DB.LinePatternElement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new LinePatternElement.

## Syntax (C#)
```csharp
public static LinePatternElement Create(
	Document document,
	LinePattern linePattern
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the LinePatternElement.
- **linePattern** (`Autodesk.Revit.DB.LinePattern`) - The LinePattern associated to the newly created LinePatternElement.

## Returns
The newly created LinePatternElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The Line Pattern is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

