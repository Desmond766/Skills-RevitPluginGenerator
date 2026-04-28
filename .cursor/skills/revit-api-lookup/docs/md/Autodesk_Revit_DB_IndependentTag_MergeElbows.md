---
kind: property
id: P:Autodesk.Revit.DB.IndependentTag.MergeElbows
zh: 标记、打标、标签
source: html/5c5ad800-7512-be12-dc1a-ebcda5513622.htm
---
# Autodesk.Revit.DB.IndependentTag.MergeElbows Property

**中文**: 标记、打标、标签

Identifies if the leaders' elbows are merged or not. If they are are merged, all elbows are in the same point and they move together.

## Syntax (C#)
```csharp
public bool MergeElbows { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The IndependentTag object does not have a tag behavior.
 -or-
 When setting this property: For this tag leaders are not allowed.
 -or-
 When setting this property: Can't merge elbows for tags that are part of a multi-reference annotation.

