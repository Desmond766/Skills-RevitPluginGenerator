---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainer.SetItemHiddenStatus(Autodesk.Revit.DB.View,System.Int32,System.Boolean)
source: html/c2eccd30-4ff7-7d9c-7858-548fc7269505.htm
---
# Autodesk.Revit.DB.Structure.RebarContainer.SetItemHiddenStatus Method

Sets the RebarContainerItem to be hidden or unhidden in the given view.

## Syntax (C#)
```csharp
public void SetItemHiddenStatus(
	View view,
	int itemIndex,
	bool hide
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view.
- **itemIndex** (`System.Int32`) - Item index in the Rebar Container.
- **hide** (`System.Boolean`) - True to hide this RebarContainerItem in the view, false to unhide the item.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The item index is either less than 0 or graeter than or equal to number of items in this Rebar Container element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

