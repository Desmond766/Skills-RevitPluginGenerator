---
kind: property
id: P:Autodesk.Revit.DB.TextNote.LeaderLeftAttachment
zh: 注释、文字注释
source: html/8092e650-ad46-a556-ef45-7fdaac22bfc7.htm
---
# Autodesk.Revit.DB.TextNote.LeaderLeftAttachment Property

**中文**: 注释、文字注释

Attachment position of leaders on the left side of the text note.

## Syntax (C#)
```csharp
public LeaderAtachement LeaderLeftAttachment { get; set; }
```

## Remarks
The property controls the vertical position of leaders attached to the left side of the note. Change of the value will affect all leaders currently attached to the left side.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

