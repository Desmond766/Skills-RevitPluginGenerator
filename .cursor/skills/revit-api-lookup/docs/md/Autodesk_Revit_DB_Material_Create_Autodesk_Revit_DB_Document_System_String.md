---
kind: method
id: M:Autodesk.Revit.DB.Material.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/5d8f8735-b814-5ac0-e8c5-114da8caa7bc.htm
---
# Autodesk.Revit.DB.Material.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new material.

## Syntax (C#)
```csharp
public static ElementId Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the material.
- **name** (`System.String`) - The name of the new material.

## Returns
Identifier of the new material.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The given value for name is already in use as a material element name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

