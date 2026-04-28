---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewTypeBinding(Autodesk.Revit.DB.CategorySet)
source: html/4c434e0a-222a-b13f-276b-dde9630a95eb.htm
---
# Autodesk.Revit.Creation.Application.NewTypeBinding Method

Creates a new type binding object containing the categories passed as a parameter.

## Syntax (C#)
```csharp
public TypeBinding NewTypeBinding(
	CategorySet categorySet
)
```

## Parameters
- **categorySet** (`Autodesk.Revit.DB.CategorySet`) - A set of categories that will be added to the binding.

## Returns
A new type binding object.

## Remarks
Type binding objects are used for attaching shared parameter definitions to a type
within a category.

