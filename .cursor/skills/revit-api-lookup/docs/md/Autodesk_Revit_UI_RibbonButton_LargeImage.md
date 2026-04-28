---
kind: property
id: P:Autodesk.Revit.UI.RibbonButton.LargeImage
source: html/558a403d-2002-10e9-30d8-c0160f5115dc.htm
---
# Autodesk.Revit.UI.RibbonButton.LargeImage Property

The large image shown on the button.

## Syntax (C#)
```csharp
public ImageSource LargeImage { get; set; }
```

## Remarks
The image will be shown on the button in the Ribbon panel if the button is not a part of a stacked set. 
It will also be shown if the button is added to a pulldown button. The image should be 32 x 32 pixels. If the image is larger
it will be adjusted to fit the button.

