---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.GetChildIds
source: html/8336bb72-f686-c742-dbbe-b6245e6b33b4.htm
---
# Autodesk.Revit.DB.RevitLinkType.GetChildIds Method

Gets the ids of the immediate children of this link.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetChildIds()
```

## Returns
The element ids of all links which are linked directly into this one
 (immediate children)

## Remarks
This function only returns the ids of immediate children. Given
 the link structure A -> B -> C, then calling this function on A will
 only return B's id.

