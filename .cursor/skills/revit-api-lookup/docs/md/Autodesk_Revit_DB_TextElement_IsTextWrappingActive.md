---
kind: property
id: P:Autodesk.Revit.DB.TextElement.IsTextWrappingActive
source: html/b14a09ef-3139-d902-35a9-35fc59224f79.htm
---
# Autodesk.Revit.DB.TextElement.IsTextWrappingActive Property

A flag identifying whether text-wrapping is currently active in this text element or not.
If text wrapping is active the width of the text box remains constant and the text will wrap.
 The height of the text box will automatically adjust to accomodate the height of the text.
If text wrapping is not active the text does not wrap and the width of the text box adjusts with
 the width of the longest line of text.
 As the text width changes, the position of the text may change depending on the
 HorizontalAlignment

## Syntax (C#)
```csharp
public bool IsTextWrappingActive { get; }
```

## Remarks
This is currently a read-only property and its value is set when the text element
 is created. If the element was created with a specified width or if an explicit width
 was set later, the wrapping would be automatically set as active. It means that any text
 line that is longer that the current width of the text-box will automatically wrapped
 onto the next line.

