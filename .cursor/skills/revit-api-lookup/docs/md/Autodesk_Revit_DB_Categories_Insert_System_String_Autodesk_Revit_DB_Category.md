---
kind: method
id: M:Autodesk.Revit.DB.Categories.Insert(System.String,Autodesk.Revit.DB.Category)
source: html/4dab9242-c529-b837-1464-496cee3b14a5.htm
---
# Autodesk.Revit.DB.Categories.Insert Method

Inserts the specified category with the specified name into the map.

## Syntax (C#)
```csharp
public override bool Insert(
	string key,
	Category item
)
```

## Parameters
- **key** (`System.String`) - The name to be used for inserting the category into the map.
- **item** (`Autodesk.Revit.DB.Category`) - The category to be inserted into the map.

## Returns
Whether or not the category was inserted into the map.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Always thrown; this list is read only.

