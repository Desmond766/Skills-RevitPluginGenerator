---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainer.RemoveItem(Autodesk.Revit.DB.Structure.RebarContainerItem)
source: html/a72cdb40-2bb0-47c2-d0da-acca1289099e.htm
---
# Autodesk.Revit.DB.Structure.RebarContainer.RemoveItem Method

Removes Item from the Rebar Container.

## Syntax (C#)
```csharp
public void RemoveItem(
	RebarContainerItem pItem
)
```

## Parameters
- **pItem** (`Autodesk.Revit.DB.Structure.RebarContainerItem`) - Item to be removed from this Rebar Container

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The item is not a member of this Rebar Container element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

