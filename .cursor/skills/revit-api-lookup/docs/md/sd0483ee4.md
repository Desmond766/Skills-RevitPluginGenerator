---
kind: property
id: P:Autodesk.Revit.UI.RibbonItem.ToolTipImage
source: html/dd4010ef-a6dd-6ad4-90fd-570b4a9add4d.htm
---
# Autodesk.Revit.UI.RibbonItem.ToolTipImage Property

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

