---
kind: property
id: P:Autodesk.Revit.DB.TextElement.VerticalAlignment
source: html/9e494181-05e2-3565-5438-971936f08949.htm
---
# Autodesk.Revit.DB.TextElement.VerticalAlignment Property

Vertical alignment of the text.

## Syntax (C#)
```csharp
public VerticalTextAlignment VerticalAlignment { get; set; }
```

## Remarks
The vertical alignment determines the way text is positioned as the text height changes.
 For Top-aligned text the top of the text will remain in place. For Middle-aligned text the horizontal center line of the text will remain in place. For Bottom-aligned text the bottom of the text will remain in place. 
 Changing this property will not affect the position of the text element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

