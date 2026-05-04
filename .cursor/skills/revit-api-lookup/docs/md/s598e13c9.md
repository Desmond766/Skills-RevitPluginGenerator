---
kind: property
id: P:Autodesk.Revit.DB.IndependentTag.LeaderEndCondition
zh: 标记、打标、标签
source: html/0b0575d6-446d-d3e8-3ef7-12faed553b20.htm
---
# Autodesk.Revit.DB.IndependentTag.LeaderEndCondition Property

**中文**: 标记、打标、标签

The leader end condition of the tag, such as if the end of the leader is attached to the host or free floating.

## Syntax (C#)
```csharp
public LeaderEndCondition LeaderEndCondition { get; set; }
```

## Remarks
LeaderEndCondition enumerates the supported leader end conditions.
 Material tags and material keynotes can only use the free end condition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: LeaderEndCondition cannot be assigned.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The IndependentTag object does not have a tag behavior.

