---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.GetTaggedLocalElements
zh: 标记、打标、标签
source: html/f238e2c7-e184-172c-546a-7dd694857e56.htm
---
# Autodesk.Revit.DB.IndependentTag.GetTaggedLocalElements Method

**中文**: 标记、打标、标签

Get the tagged local elements, if any.
 An Element will be provided for each subelement that is being referenced by the tag.

## Syntax (C#)
```csharp
public ICollection<Element> GetTaggedLocalElements()
```

## Returns
All tagged elements from the local document, or Nothing nullptr a null reference ( Nothing in Visual Basic) for orphan tags and tagged elements in linked documents.

