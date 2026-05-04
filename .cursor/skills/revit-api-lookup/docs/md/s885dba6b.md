---
kind: method
id: M:Autodesk.Revit.DB.Structure.LoadNature.Create(Autodesk.Revit.DB.Document,System.String)
zh: 创建、新建、生成、建立、新增
source: html/23564e70-0341-0d1c-f707-5a59deadf8c8.htm
---
# Autodesk.Revit.DB.Structure.LoadNature.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new LoadNature.

## Syntax (C#)
```csharp
public static LoadNature Create(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Document to which new load nature element will be added.
- **name** (`System.String`) - The name of the load nature.

## Returns
The newly created load nature element if successful, Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given name is not unique
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

