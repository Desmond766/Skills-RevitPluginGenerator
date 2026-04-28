---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.GetTaggedLocalElementIds
zh: 标记、打标、标签
source: html/142026b1-69d5-7b1e-f5b3-3360abc0f9be.htm
---
# Autodesk.Revit.DB.IndependentTag.GetTaggedLocalElementIds Method

**中文**: 标记、打标、标签

Returns a set of IDs for all tagged local elements, if any. A local element ID will be provided for each
 subelement that is being referenced by the tag.
 Set of all the element ids in the local file.
 For each subelement a local element id will be provided.

## Syntax (C#)
```csharp
public ISet<ElementId> GetTaggedLocalElementIds()
```

