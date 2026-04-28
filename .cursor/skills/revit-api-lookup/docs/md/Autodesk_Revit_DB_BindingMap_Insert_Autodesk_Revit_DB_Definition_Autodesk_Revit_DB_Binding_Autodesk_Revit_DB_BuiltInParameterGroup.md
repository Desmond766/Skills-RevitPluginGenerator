---
kind: method
id: M:Autodesk.Revit.DB.BindingMap.Insert(Autodesk.Revit.DB.Definition,Autodesk.Revit.DB.Binding,Autodesk.Revit.DB.BuiltInParameterGroup)
source: html/c3bed87a-956f-47c3-060c-0294c7ef43e7.htm
---
# Autodesk.Revit.DB.BindingMap.Insert Method

Creates a new parameter binding between a parameter and a set of categories in a specified group.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 and may be removed in a future version of Revit. Please use the `Insert(Definition, Binding, ForgeTypeId)` method instead.")]
public virtual bool Insert(
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
If the Parameter binding already exists, post an error and return false

