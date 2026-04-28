---
kind: property
id: P:Autodesk.Revit.DB.IndependentTag.TagText
zh: 标记、打标、标签
source: html/8e297dee-920d-f620-6198-0bed494e3f04.htm
---
# Autodesk.Revit.DB.IndependentTag.TagText Property

**中文**: 标记、打标、标签

The text associated with the tag. If there are several strings assiciated with the tag, the strings will be returned concatenated.

## Syntax (C#)
```csharp
public string TagText { get; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The IndependentTag object does not have a tag behavior.
 -or-
 The tagging element is in the link.

