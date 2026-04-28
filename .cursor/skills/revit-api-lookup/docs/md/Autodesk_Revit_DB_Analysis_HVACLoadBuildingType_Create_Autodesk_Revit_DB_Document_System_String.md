---
kind: method
id: M:Autodesk.Revit.DB.Analysis.HVACLoadBuildingType.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/3dfb45e3-59e1-6543-1869-796c94b1965e.htm
---
# Autodesk.Revit.DB.Analysis.HVACLoadBuildingType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a building type element.

## Syntax (C#)
```csharp
public static HVACLoadBuildingType Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **name** (`System.String`) - The building type name.

## Returns
The new building type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string or contains only whitespace.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The given value for name is already in use as a building type name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

