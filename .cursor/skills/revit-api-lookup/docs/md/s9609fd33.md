---
kind: method
id: M:Autodesk.Revit.DB.BindingMap.Insert(Autodesk.Revit.DB.Definition,Autodesk.Revit.DB.Binding)
source: html/f2f95b7a-fc25-ac0e-31e3-0fc1b331f224.htm
---
# Autodesk.Revit.DB.BindingMap.Insert Method

Creates a new parameter binding between a parameter and a set of categories.

## Syntax (C#)
```csharp
public override bool Insert(
	Definition key,
	Binding item
)
```

## Parameters
- **key** (`Autodesk.Revit.DB.Definition`) - A parameter definition which can be an existing definition or one from a shared parameters file.
- **item** (`Autodesk.Revit.DB.Binding`) - An InstanceBinding or TypeBinding object which contains the set of categories to which the parameter should be bound.

## Remarks
Note the type of the binding object dictates whether the parameter is bound to all
instances or just types. A parameter definition cannot be bound to both instances and types.
If the parameter binding already exists, post an error and return false.

