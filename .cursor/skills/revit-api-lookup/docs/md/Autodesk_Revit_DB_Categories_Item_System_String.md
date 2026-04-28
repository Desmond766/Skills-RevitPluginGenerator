---
kind: property
id: P:Autodesk.Revit.DB.Categories.Item(System.String)
source: html/9e2a96fc-df10-2e33-e042-53360cc9724e.htm
---
# Autodesk.Revit.DB.Categories.Item Property

Gets a category which has the specified name from this list of top-level categories.

## Syntax (C#)
```csharp
public override Category this[
	string name
] { get; set; }
```

## Parameters
- **name** (`System.String`) - The name of the category to be retrieved.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the category list does not contain the category with this name.
Thrown when trying to set an item to this list of categories; this list is read only.

