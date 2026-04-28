---
kind: property
id: P:Autodesk.Revit.DB.TextElement.Height
zh: 高度
source: html/824eac10-294a-bc52-22ea-24fa7a90be31.htm
---
# Autodesk.Revit.DB.TextElement.Height Property

**中文**: 高度

Height of the area of the text content.

## Syntax (C#)
```csharp
public double Height { get; }
```

## Remarks
The value is in sheet units, meaning it is as when measured on a printed sheet.
 The measurement is of the text content only; the border around it (if specified) is excluded. This is a read-only property, for the height of the text area
 is calculated depending on the text content and its wrapping.

