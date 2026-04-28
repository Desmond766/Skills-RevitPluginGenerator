---
kind: method
id: M:Autodesk.Revit.DB.DefinitionGroups.Create(System.String)
zh: 创建、新建、生成、建立、新增
source: html/8548b429-4556-71f6-f885-0be06aff248d.htm
---
# Autodesk.Revit.DB.DefinitionGroups.Create Method

**中文**: 创建、新建、生成、建立、新增

Create a new parameter definition group using the name provided.

## Syntax (C#)
```csharp
public DefinitionGroup Create(
	string name
)
```

## Parameters
- **name** (`System.String`) - The name of the group to be created.

## Returns
If successful a reference to the new parameter group is returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
If a group with the same name already exists then an exception will be thrown.

