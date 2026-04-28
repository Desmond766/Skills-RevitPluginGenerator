---
kind: property
id: P:Autodesk.Revit.UI.RibbonItem.ToolTip
source: html/afc95063-2798-2dfb-8313-8875738dc5e5.htm
---
# Autodesk.Revit.UI.RibbonItem.ToolTip Property

The description that appears as a ToolTip for the item.

## Syntax (C#)
```csharp
public string ToolTip { get; set; }
```

## Remarks
The text that is displayed when the mouse pointer moves over the item. 
SplitButton and RadioButtonGroup cannot display the tooltip set by this method, the SplitButton will
always show the current PushButton tooltip, and RadioButtonGroup has no tooltip.

