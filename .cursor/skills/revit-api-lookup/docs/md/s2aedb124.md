---
kind: method
id: M:Autodesk.Revit.DB.Structure.LoadUsage.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/32ab758e-72e1-b024-3c9c-a21b7ed2d575.htm
---
# Autodesk.Revit.DB.Structure.LoadUsage.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new LoadUsage.

## Syntax (C#)
```csharp
public static LoadUsage Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document to which new load usage element will be added.
- **name** (`System.String`) - The name of the load usage.

## Returns
The newly created load usage element if successful, Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given name is not unique
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

