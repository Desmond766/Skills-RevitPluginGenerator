---
kind: property
id: P:Autodesk.Revit.DB.Leader.Anchor
source: html/2e8ccfe1-6336-5ad2-0a56-01fea76e4572.htm
---
# Autodesk.Revit.DB.Leader.Anchor Property

Anchor point of the Leader

## Syntax (C#)
```csharp
public XYZ Anchor { get; }
```

## Remarks
Anchor is the leader's point that is attached to an annotation (a tag, note, etc.)
 This is a read-only property, for the this point gets always computed based on various
 properties of the annotation element.

