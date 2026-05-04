---
kind: method
id: M:Autodesk.Revit.DB.Level.Create(Autodesk.Revit.DB.Document,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/d661b7cd-dec8-6ae6-a753-b14ac2568772.htm
---
# Autodesk.Revit.DB.Level.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of level based on an input elevation.

## Syntax (C#)
```csharp
public static Level Create(
	Document document,
	double elevation
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new instance is created
- **elevation** (`System.Double`) - The elevation of the level to be created.

## Returns
The newly created level instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

