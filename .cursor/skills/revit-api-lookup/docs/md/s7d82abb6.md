---
kind: method
id: M:Autodesk.Revit.DB.BindingMap.Insert(Autodesk.Revit.DB.Definition,Autodesk.Revit.DB.Binding,Autodesk.Revit.DB.ForgeTypeId)
source: html/2619a727-57b9-26ed-6d5a-3316a2641fd0.htm
---
# Autodesk.Revit.DB.BindingMap.Insert Method

Creates a new parameter binding between a parameter and a set of categories in a specified group.

## Syntax (C#)
```csharp
public virtual bool Insert(
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
If the Parameter binding already exists, post an error and return false

