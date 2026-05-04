---
kind: property
id: P:Autodesk.Revit.DB.TextNode.IsKeptReadable
source: html/5e96ceea-7c72-4612-de24-581e51e51998.htm
---
# Autodesk.Revit.DB.TextNode.IsKeptReadable Property

Indicates text behavior inside a rotated text object.

## Syntax (C#)
```csharp
public bool IsKeptReadable { get; }
```

## Remarks
If the property is True then the text inside the text box gets oriented
 so it is readable when looking straight up at the sheet or from its right side;
 in other words, the text would never be upside down. If the value is False, however, the text's orientation strictly follows
 the rotation of the text box, which means the text may be upside down when
 viewed on screen or printed on a sheet.

