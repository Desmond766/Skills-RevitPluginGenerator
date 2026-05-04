---
kind: property
id: P:Autodesk.Revit.UI.ButtonData.LargeImage
source: html/f63f7b0c-e200-e4ad-6d0d-4716d12ed243.htm
---
# Autodesk.Revit.UI.ButtonData.LargeImage Property

The large image of the button.

## Syntax (C#)
```csharp
public ImageSource LargeImage { get; set; }
```

## Remarks
The image will be shown on the button in the Ribbon panel if the button is not a part of a stacked set. 
It will also be shown on a push button added to a pulldown button. The best size is 32 x 32 pixels; if larger, 
the image will be adjusted to fit the button.

