---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.GetRootId
source: html/f50ff34a-11db-04ae-8085-636be561031d.htm
---
# Autodesk.Revit.DB.RevitLinkType.GetRootId Method

Gets the id of the top-level link which this link is linked into.

## Syntax (C#)
```csharp
public ElementId GetRootId()
```

## Returns
The id of the top-level link which this link is ultimately linked under,
 or invalidElementId if this link is a top-level link.

## Remarks
This function will always return the id of a top-level link, or invalidElementId.
 Given the link structure A -> B -> C, then calling this function on
 C will return A's id. Call GetParentId to get B's id.

