---
kind: method
id: M:Autodesk.Revit.UI.RibbonPanel.AddItem(Autodesk.Revit.UI.RibbonItemData)
zh: 功能区
source: html/8b74bcca-b764-4c57-5161-840afe14af4d.htm
---
# Autodesk.Revit.UI.RibbonPanel.AddItem Method

**中文**: 功能区

Adds a Ribbon item to the panel.

## Syntax (C#)
```csharp
public RibbonItem AddItem(
	RibbonItemData itemData
)
```

## Parameters
- **itemData** (`Autodesk.Revit.UI.RibbonItemData`) - Data containing information about the new item.

## Returns
The added Ribbon item.

## Remarks
The new item may either be a PushButton, PulldownButton, SplitButon, RadioButtonGroup, ComboBox, or TextBox depending upon the type of data passed in.
The new item may be created as a large-size vertical control in the panel.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when itemData is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when an item with the itemData.Name already exists in the panel or the data is not of the correct type.

