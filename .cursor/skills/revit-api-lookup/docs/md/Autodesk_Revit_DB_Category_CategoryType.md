---
kind: property
id: P:Autodesk.Revit.DB.Category.CategoryType
source: html/1d6672eb-82d6-f702-661b-a3c59fdbe67b.htm
---
# Autodesk.Revit.DB.Category.CategoryType Property

Gets the category type of this category.

## Syntax (C#)
```csharp
public CategoryType CategoryType { get; }
```

## Remarks
The category type determines if the category is shown in the Visibility/Graphics settings
grouped with the model,annotation, or analytical model categories. 
Note that import categories are also "model" but will be shown separately in the dialog. 
Some categories not shown in the dialog and will return Internal for the category type.

