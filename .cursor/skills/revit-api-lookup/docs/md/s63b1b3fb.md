---
kind: property
id: P:Autodesk.Revit.UI.RibbonItem.LongDescription
source: html/b5d651b3-136b-a0b1-fe3c-d37c55196e87.htm
---
# Autodesk.Revit.UI.RibbonItem.LongDescription Property

Long description of the command tooltip

## Syntax (C#)
```csharp
public string LongDescription { get; set; }
```

## Remarks
It will be used as part of the button's extended 
tooltip. This tooltip is shown when the mouse hovers over the command for a long amount 
of time. You can split the text of this option into multiple paragraphs by placing <p> 
tags around each paragraph. Optional. If neither of this property and TooltipImage is 
supplied, the button will not have an extended tooltip. 
SplitButton and RadioButtonGroup cannot display the tooltip set by this method, the SplitButton will
always show the current PushButton tooltip, and RadioButtonGroup has no tooltip.

