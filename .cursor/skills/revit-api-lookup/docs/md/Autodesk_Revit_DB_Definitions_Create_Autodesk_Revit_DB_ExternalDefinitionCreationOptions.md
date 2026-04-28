---
kind: method
id: M:Autodesk.Revit.DB.Definitions.Create(Autodesk.Revit.DB.ExternalDefinitionCreationOptions)
zh: 创建、新建、生成、建立、新增
source: html/3ece56e2-3980-c86f-cfdf-7b5d2b371da5.htm
---
# Autodesk.Revit.DB.Definitions.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new parameter definition using specified options.

## Syntax (C#)
```csharp
public Definition Create(
	ExternalDefinitionCreationOptions option
)
```

## Parameters
- **option** (`Autodesk.Revit.DB.ExternalDefinitionCreationOptions`) - The options used to create the new parameter definition.

## Returns
If successful a reference to the new parameter definition is returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
This method only supports creation of new external definitions (shared parameters).

