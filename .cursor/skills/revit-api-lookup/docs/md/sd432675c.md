---
kind: property
id: P:Autodesk.Revit.DB.IndependentTag.IsOrphaned
zh: 标记、打标、标签
source: html/4906fa9c-e424-92e7-0b7e-15389726ca78.htm
---
# Autodesk.Revit.DB.IndependentTag.IsOrphaned Property

**中文**: 标记、打标、标签

Identifies if the tag is orphaned or not.

## Syntax (C#)
```csharp
public bool IsOrphaned { get; }
```

## Remarks
Orphaned tags are those tags that are associated with one or more linked host that is missing.
 Tags become orphaned when one or more associated linked host is missing from the link.

