---
kind: property
id: P:Autodesk.Revit.UI.RibbonItemData.ToolTip
source: html/9642a773-d812-3bb6-9a30-faae3af9468e.htm
---
# Autodesk.Revit.UI.RibbonItemData.ToolTip Property

The description that appears as a ToolTip for the item.

## Syntax (C#)
```csharp
public string ToolTip { get; set; }
```

## Remarks
The text that is displayed when the mouse pointer moves over the item. 
SplitButton and RadioButtonGroup cannot display the tooltip set by this method, the SplitButton will
always show the current PushButton tooltip, and RadioButtonGroup has no tooltip.

