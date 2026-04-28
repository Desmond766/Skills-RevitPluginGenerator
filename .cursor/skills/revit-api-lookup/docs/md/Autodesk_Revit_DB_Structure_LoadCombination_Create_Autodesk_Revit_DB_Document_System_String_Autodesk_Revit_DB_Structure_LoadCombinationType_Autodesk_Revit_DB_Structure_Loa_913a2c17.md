---
kind: method
id: M:Autodesk.Revit.DB.Structure.LoadCombination.Create(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.Structure.LoadCombinationType,Autodesk.Revit.DB.Structure.LoadCombinationState)
zh: 创建、新建、生成、建立、新增
source: html/a8a63cfd-a250-3125-892c-ba5b799c45c3.htm
---
# Autodesk.Revit.DB.Structure.LoadCombination.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new LoadCombination.

## Syntax (C#)
```csharp
public static LoadCombination Create(
	Document document,
	string name,
	LoadCombinationType type,
	LoadCombinationState state
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document to which new load combination element will be added.
- **name** (`System.String`) - The name of the load combination.
- **type** (`Autodesk.Revit.DB.Structure.LoadCombinationType`) - The type of the load combination.
- **state** (`Autodesk.Revit.DB.Structure.LoadCombinationState`) - The state of the load combination.

## Returns
The newly created load combination element if successful, Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given name is not unique
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

