---
kind: property
id: P:Autodesk.Revit.DB.TextNote.LeaderRightAttachment
zh: 注释、文字注释
source: html/74a79a79-cfcc-c001-4554-59691beb69cc.htm
---
# Autodesk.Revit.DB.TextNote.LeaderRightAttachment Property

**中文**: 注释、文字注释

Attachment position of leaders on the right side of the text note.

## Syntax (C#)
```csharp
public LeaderAtachement LeaderRightAttachment { get; set; }
```

## Remarks
The property controls the vertical position of leaders attached to the right side of the note. Change of the value will affect all leaders currently attached to the right side.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

