---
kind: method
id: M:Autodesk.Revit.DB.BindingMap.ReInsert(Autodesk.Revit.DB.Definition,Autodesk.Revit.DB.Binding,Autodesk.Revit.DB.BuiltInParameterGroup)
source: html/7b613771-310d-6d89-4b69-475a68033f73.htm
---
# Autodesk.Revit.DB.BindingMap.ReInsert Method

Removes an existing parameter and creates a new binding for a given parameter in a specified group.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 and may be removed in a future version of Revit. Please use the `ReInsert(Definition, Binding, ForgeTypeId)` method instead.")]
public virtual bool ReInsert(
	Definition key,
	Binding item,
	BuiltInParameterGroup parameterGroup
)
```

## Parameters
- **key** (`Autodesk.Revit.DB.Definition`) - A parameter definition which can be an existing definition or one from a shared parameters file.
- **item** (`Autodesk.Revit.DB.Binding`) - An InstanceBinding or TypeBinding object which contains the set of categories to which the parameter should be bound.
- **parameterGroup** (`Autodesk.Revit.DB.BuiltInParameterGroup`) - The GroupID of the parameter definition, or INVALID if the parameter is not to be associated with any predefined group.

## Remarks
Note the type of the binding object dictates whether the parameter is bound to all
instances or just types. A parameter definition cannot be bound to both instances and types. 
If the parameter binding already exists, remove the binding, create a new parameter binding.
If the parameter binding related to the input key doesn't exist in the database, 
ReInsert will fail and false will be returned. In this case, Insert should be called.

