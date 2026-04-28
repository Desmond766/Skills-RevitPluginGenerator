---
kind: property
id: P:Autodesk.Revit.DB.TextElement.Width
zh: 宽度
source: html/ce0e3089-231a-31ac-ee52-ad912b9ea331.htm
---
# Autodesk.Revit.DB.TextElement.Width Property

**中文**: 宽度

Width of the area of the text content.

## Syntax (C#)
```csharp
public double Width { get; set; }
```

## Remarks
This property supersedes the older [!:LineWidth] property which has been deprecated. The value is in sheet units, meaning it is as when measured on a printed sheet.
 The measurement is of the text content only; the border around it (if specified) is excluded. For a text element which does is set not to use text wrapping the width is calculated
 to fit the longest line (a single line, typically) of the text. A setting the width explicitly
 by assigning value to this property will automatically activate text-wrapping for the element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given width is not valid. A valid value must be within the range
 returned by the methods GetMinimumAllowedWidth and GetMaximumAllowedWidth.

