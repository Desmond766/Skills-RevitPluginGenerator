---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewInstanceBinding(Autodesk.Revit.DB.CategorySet)
source: html/889f1519-d680-eaa0-1036-494656da065c.htm
---
# Autodesk.Revit.Creation.Application.NewInstanceBinding Method

Creates a new instance binding object containing the categories passed as a parameter.

## Syntax (C#)
```csharp
public InstanceBinding NewInstanceBinding(
	CategorySet categorySet
)
```

## Parameters
- **categorySet** (`Autodesk.Revit.DB.CategorySet`) - A set of categories that will be added to the binding.

## Returns
A new instance binding object.

## Remarks
Instance binding objects are used for attaching shared parameter definitions to all
instances of an element within a category.

