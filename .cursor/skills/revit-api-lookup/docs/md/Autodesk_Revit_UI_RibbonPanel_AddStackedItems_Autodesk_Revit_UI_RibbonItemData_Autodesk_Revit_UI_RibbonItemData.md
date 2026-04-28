---
kind: method
id: M:Autodesk.Revit.UI.RibbonPanel.AddStackedItems(Autodesk.Revit.UI.RibbonItemData,Autodesk.Revit.UI.RibbonItemData)
zh: 功能区
source: html/1fe0bbea-29a5-dff5-7330-ff07879b1cee.htm
---
# Autodesk.Revit.UI.RibbonPanel.AddStackedItems Method

**中文**: 功能区

Adds two stacked items to the panel.

## Syntax (C#)
```csharp
public IList<RibbonItem> AddStackedItems(
	RibbonItemData item1,
	RibbonItemData item2
)
```

## Parameters
- **item1** (`Autodesk.Revit.UI.RibbonItemData`) - Data containing information about the first item. This data must be of type PushButtonData, PulldownButtonData, SplitButtonData, ComboBoxData, or TextBoxData.
- **item2** (`Autodesk.Revit.UI.RibbonItemData`) - Data containing information about the second item. This data must be of type PushButtonData, PulldownButtonData, SplitButtonData, ComboBoxData, or TextBoxData.

## Returns
A collection containing the added items.

## Remarks
Each new item may either be a PushButton, PulldownButton, SplitButton, ComboBox or TextBox, depending upon the type of 
data passed in for each argument. The new items will be created as small-size horizontal controls, 
with the first stacked on top of the second in the panel.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when item1 or item2 is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when an item with the item1.Name or item2.Name already exists in the panel or the data is not of the correct type.

