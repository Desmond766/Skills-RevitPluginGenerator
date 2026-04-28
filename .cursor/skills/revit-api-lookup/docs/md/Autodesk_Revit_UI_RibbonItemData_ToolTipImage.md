---
kind: property
id: P:Autodesk.Revit.UI.RibbonItemData.ToolTipImage
source: html/ab1eb8b1-9b09-1afe-7473-9911af6fef1b.htm
---
# Autodesk.Revit.UI.RibbonItemData.ToolTipImage Property

The image to show as a part of the button extended tooltip

## Syntax (C#)
```csharp
public ImageSource ToolTipImage { get; set; }
```

## Remarks
Shown when the cursor hovers over the command. 
If neither this property nor LongDescription is supplied, the button will not have 
an extended tooltip. Maximum height or width is 355 pixels.
SplitButton and RadioButtonGroup cannot display the tooltip set by this method. SplitButton
shows the current PushButton tooltip and RadioButtonGroup has no tooltip.

