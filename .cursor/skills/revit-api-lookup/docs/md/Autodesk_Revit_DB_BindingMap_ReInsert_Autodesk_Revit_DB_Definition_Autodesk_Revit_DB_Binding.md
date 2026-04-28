---
kind: method
id: M:Autodesk.Revit.DB.BindingMap.ReInsert(Autodesk.Revit.DB.Definition,Autodesk.Revit.DB.Binding)
source: html/50ccd2e2-a484-e0a2-ef18-7ee552bf2e8a.htm
---
# Autodesk.Revit.DB.BindingMap.ReInsert Method

Removes an existing parameter and creates a new binding for a given parameter.

## Syntax (C#)
```csharp
public virtual bool ReInsert(
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
If the parameter binding already exists, remove the binding, create a new parameter binding.

