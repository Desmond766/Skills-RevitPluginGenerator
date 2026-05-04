---
kind: method
id: M:Autodesk.Revit.DB.Analysis.HVACLoadSpaceType.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/fa69cfdf-7fab-ee5b-17ea-22cfdbfdc7d2.htm
---
# Autodesk.Revit.DB.Analysis.HVACLoadSpaceType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a space type.

## Syntax (C#)
```csharp
public static HVACLoadSpaceType Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **name** (`System.String`) - The space type name.

## Returns
The new space type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string or contains only whitespace.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The given value for name is already in use as a space type name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

