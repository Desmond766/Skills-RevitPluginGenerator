---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainer.GetItem(System.Int32)
source: html/d591f494-7c8c-a8ef-1a6a-31dc8dbc2ee4.htm
---
# Autodesk.Revit.DB.Structure.RebarContainer.GetItem Method

Gets the item stored in the RebarContainer at the associated index.

## Syntax (C#)
```csharp
public RebarContainerItem GetItem(
	int itemIndex
)
```

## Parameters
- **itemIndex** (`System.Int32`) - Item index in the Rebar Container

## Returns
Rebar Container Item

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The item index is either less than 0 or graeter than or equal to number of items in this Rebar Container element.

