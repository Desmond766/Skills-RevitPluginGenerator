---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.GetTaggedElementIds
zh: 标记、打标、标签
source: html/43260944-f46c-d5df-c9ea-f3a44e24d1a2.htm
---
# Autodesk.Revit.DB.IndependentTag.GetTaggedElementIds Method

**中文**: 标记、打标、标签

Returns a set of LinkElementId for all tagged elements, if any. A LinkElementId will be provided for each
 subelement that is being referenced by the tag.

## Syntax (C#)
```csharp
public ICollection<LinkElementId> GetTaggedElementIds()
```

## Returns
Set of all the tagged elements ids for both local and linked files.

## Remarks
All the returned LinkElementIds will be valid even when IsOrphaned is true.

