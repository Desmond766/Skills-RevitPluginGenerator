---
kind: property
id: P:Autodesk.Revit.DB.IndependentTag.HasLeader
zh: 标记、打标、标签
source: html/ce3fe3a9-4048-3b29-4dcb-57ca86de4267.htm
---
# Autodesk.Revit.DB.IndependentTag.HasLeader Property

**中文**: 标记、打标、标签

Identifies if a tag has at least one visible leader, or if all leaders are hidden.

## Syntax (C#)
```csharp
public bool HasLeader { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The IndependentTag object does not have a tag behavior.
 -or-
 When setting this property: For this tag leaders are not allowed.

