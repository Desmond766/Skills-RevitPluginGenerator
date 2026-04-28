---
kind: method
id: M:Autodesk.Revit.DB.Structure.LoadCombination.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/e8c2e315-9c59-fc3b-0c16-fd101b893b20.htm
---
# Autodesk.Revit.DB.Structure.LoadCombination.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new default LoadCombination.

## Syntax (C#)
```csharp
public static LoadCombination Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document to which new load combination element will be added.
- **name** (`System.String`) - The name of the load combination.

## Returns
The newly created load combination element if successful, Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given name is not unique
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

