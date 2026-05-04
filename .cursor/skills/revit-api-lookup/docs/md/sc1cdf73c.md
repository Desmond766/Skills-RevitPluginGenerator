---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.GetParentId
source: html/937f7497-a73c-f97c-dc49-1da47d098200.htm
---
# Autodesk.Revit.DB.RevitLinkType.GetParentId Method

Gets the id of this link's immediate parent.

## Syntax (C#)
```csharp
public ElementId GetParentId()
```

## Returns
The id of the immediate parent of this link, or invalidElementId if
 this link is a top-level link.

## Remarks
This function returns the immediate parent id. Given the link
 structure A -> B -> C, then calling this function on C will return
 B's id. Call GetRootId to get A's id.

