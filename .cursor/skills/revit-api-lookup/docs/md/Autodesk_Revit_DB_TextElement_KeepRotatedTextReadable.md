---
kind: property
id: P:Autodesk.Revit.DB.TextElement.KeepRotatedTextReadable
source: html/c139cc83-2903-74f5-ca1b-9f74bdb0cc45.htm
---
# Autodesk.Revit.DB.TextElement.KeepRotatedTextReadable Property

A flag to control how text behaves inside a rotated text element.

## Syntax (C#)
```csharp
public bool KeepRotatedTextReadable { get; set; }
```

## Remarks
If the property is True then the text inside the text box gets oriented
 so it is readable when looking straight up at the sheet or from its right side;
 in other words, the text would never be upside down. If the value is False, however, the text's orientation strictly follows
 the rotation of the text box, which means the text may be upside down when
 viewed on screen or printed on a sheet.

