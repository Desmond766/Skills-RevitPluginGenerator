---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainer.IsItemHidden(Autodesk.Revit.DB.View,System.Int32)
source: html/0c86e348-7204-5953-4398-e6ee29bc79c1.htm
---
# Autodesk.Revit.DB.Structure.RebarContainer.IsItemHidden Method

Identifies if a given RebarContainerItem is hidden in this view.

## Syntax (C#)
```csharp
public bool IsItemHidden(
	View view,
	int itemIndex
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view.
- **itemIndex** (`System.Int32`) - Item index in the Rebar Container.

## Returns
True if the RebarContainerItem is hidden in this view, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The item index is either less than 0 or graeter than or equal to number of items in this Rebar Container element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

