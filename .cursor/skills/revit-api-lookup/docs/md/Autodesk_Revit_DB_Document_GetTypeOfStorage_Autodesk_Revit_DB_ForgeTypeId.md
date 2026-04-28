---
kind: method
id: M:Autodesk.Revit.DB.Document.GetTypeOfStorage(Autodesk.Revit.DB.ForgeTypeId)
zh: 文档、文件
source: html/39a19e04-d424-9e7d-0d82-866172fb26d9.htm
---
# Autodesk.Revit.DB.Document.GetTypeOfStorage Method

**中文**: 文档、文件

Get the storage type of the identified built-in parameter.

## Syntax (C#)
```csharp
public StorageType GetTypeOfStorage(
	ForgeTypeId parameterTypeId
)
```

## Parameters
- **parameterTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the built-in parameter.

## Returns
Storage type of the built-in parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - parameterTypeId does not identify a built-in parameter. See Parameter.IsBuiltInParameter(ForgeTypeId) and Parameter.GetParameterTypeId(BuiltInParameter).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

