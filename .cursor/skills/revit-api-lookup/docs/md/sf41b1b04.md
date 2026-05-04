---
kind: property
id: P:Autodesk.Revit.DB.TextElement.Coord
source: html/c76a355a-5356-33f4-eeeb-ae73fc463189.htm
---
# Autodesk.Revit.DB.TextElement.Coord Property

Position of the text (in model coordinates.)

## Syntax (C#)
```csharp
public XYZ Coord { get; set; }
```

## Remarks
The position defines a point on the edge of the text area,
 not a point on the border (if a border is defined for the style.)
 It means that if the width of the border gets changed, the
 position of the text area remains unchanged. The relation of the position point with respect
 to the text area depends on the text alignment as follows: For Left-aligned text the point is at the Left-Top corned of the box. For Center-aligned text the point is at the Middle-Top corned of the box. For Right-aligned text the point is at the Right-Top corned of the box.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: A valid point must not be father then 10 miles (approx. 16 km) from the origin.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

