---
kind: property
id: P:Autodesk.Revit.DB.TextNode.Position
source: html/36740103-d9cb-6451-c9ff-34e6880c9eeb.htm
---
# Autodesk.Revit.DB.TextNode.Position Property

Position of the text in model coordinates.

## Syntax (C#)
```csharp
public XYZ Position { get; }
```

## Remarks
The relation of the position point with respect
 to the text area depends on the text alignment. For example:
 For Left-Top-aligned text the point is at the Left-Top corner of the box. For Center-Bottom aligned text the point is at the Center-Bottom corner of the box.

