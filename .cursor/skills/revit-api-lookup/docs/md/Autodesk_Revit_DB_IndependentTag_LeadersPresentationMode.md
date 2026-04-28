---
kind: property
id: P:Autodesk.Revit.DB.IndependentTag.LeadersPresentationMode
zh: 标记、打标、标签
source: html/f0d5e29e-0407-cdc0-cdf7-69ea516bd632.htm
---
# Autodesk.Revit.DB.IndependentTag.LeadersPresentationMode Property

**中文**: 标记、打标、标签

Identifies the Presentation Mode that is applied to tag leaders.

## Syntax (C#)
```csharp
public LeadersPresentationMode LeadersPresentationMode { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The LeadersPresentationMode LeadersPresentationMode.ShowOnlyOne or LeadersPresentationMode.ShowSpecificLeaders can't be set to a tag with only one leader.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The IndependentTag object does not have a tag behavior.
 -or-
 When setting this property: For this tag leaders are not allowed.

