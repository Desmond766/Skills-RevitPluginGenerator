---
kind: property
id: P:Autodesk.Revit.UI.TextBox.ShowImageAsButton
source: html/81add97d-5d3b-170c-cfdf-01efeeb9a73a.htm
---
# Autodesk.Revit.UI.TextBox.ShowImageAsButton Property

Gets or sets a value that indicates if the Image set 
in the text box should be displayed as a clickable button.

## Syntax (C#)
```csharp
public bool ShowImageAsButton { get; set; }
```

## Remarks
If this property is true, the image will shown as a button inside the textbox.
Clicking this button will trigger the EnterPressed event. The default value 
is false.

