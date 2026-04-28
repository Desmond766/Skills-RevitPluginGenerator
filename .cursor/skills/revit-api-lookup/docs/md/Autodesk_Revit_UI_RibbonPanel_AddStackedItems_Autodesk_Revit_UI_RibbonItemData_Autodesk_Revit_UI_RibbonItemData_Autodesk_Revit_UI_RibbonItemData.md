---
kind: method
id: M:Autodesk.Revit.UI.RibbonPanel.AddStackedItems(Autodesk.Revit.UI.RibbonItemData,Autodesk.Revit.UI.RibbonItemData,Autodesk.Revit.UI.RibbonItemData)
zh: 功能区
source: html/5e8e4141-58b8-c786-c43d-f1e043bb4c71.htm
---
# Autodesk.Revit.UI.RibbonPanel.AddStackedItems Method

**中文**: 功能区

Adds three stacked items to the panel.

## Syntax (C#)
```csharp
public IList<RibbonItem> AddStackedItems(
	RibbonItemData item1,
	RibbonItemData item2,
	RibbonItemData item3
)
```

## Parameters
- **item1** (`Autodesk.Revit.UI.RibbonItemData`) - Data containing information about the first item. This data must be of type PushButtonData, PulldownButtonData, SplitButtonData, ComboBoxData, or TextBoxData.
- **item2** (`Autodesk.Revit.UI.RibbonItemData`) - Data containing information about the second item. This data must be of type PushButtonData, PulldownButtonData, SplitButtonData, ComboBoxData, or TextBoxData.
- **item3** (`Autodesk.Revit.UI.RibbonItemData`) - Data containing information about the third item. This data must be of type PushButtonData, PulldownButtonData, SplitButtonData, ComboBoxData, or TextBoxData.

## Returns
A collection containing the added items.

## Remarks
Each new item may either be a PushButton, PulldownButton, SplitButton, ComboBox or TextBox, depending upon the type of 
data passed in for each argument. The new items will be created as small-size horizontal controls, 
with the first stacked on top of the second in the panel.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when item1, item2 or item3 is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when an item with item1.Name or item2.Name or item3.Name already exists in the panel or the data is not of the correct type.

