---
kind: method
id: M:Autodesk.Revit.DB.BindingMap.ReInsert(Autodesk.Revit.DB.Definition,Autodesk.Revit.DB.Binding,Autodesk.Revit.DB.ForgeTypeId)
source: html/6dbdd2ef-e286-dc2a-8102-d6fbfef7e973.htm
---
# Autodesk.Revit.DB.BindingMap.ReInsert Method

Removes an existing parameter and creates a new binding for a given parameter in a specified group.

## Syntax (C#)
```csharp
public virtual bool ReInsert(
	Definition key,
	Binding item,
	ForgeTypeId groupTypeId
)
```

## Parameters
- **key** (`Autodesk.Revit.DB.Definition`) - A parameter definition which can be an existing definition or one from a shared parameters file.
- **item** (`Autodesk.Revit.DB.Binding`) - An InstanceBinding or TypeBinding object which contains the set of categories to which the parameter should be bound.
- **groupTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier of the parameter definition's parameter group, or empty if the parameter is not to be associated with any predefined group.

## Remarks
Note the type of the binding object dictates whether the parameter is bound to all
instances or just types. A parameter definition cannot be bound to both instances and types. 
If the parameter binding already exists, remove the binding, create a new parameter binding.
If the parameter binding related to the input key doesn't exist in the database, 
ReInsert will fail and false will be returned. In this case, Insert should be called.

