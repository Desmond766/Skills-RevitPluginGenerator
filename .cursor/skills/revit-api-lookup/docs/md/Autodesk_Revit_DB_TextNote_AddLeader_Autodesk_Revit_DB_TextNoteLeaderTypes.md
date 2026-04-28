---
kind: method
id: M:Autodesk.Revit.DB.TextNote.AddLeader(Autodesk.Revit.DB.TextNoteLeaderTypes)
zh: 注释、文字注释
source: html/c3cc0373-2963-3512-b308-7058d803d267.htm
---
# Autodesk.Revit.DB.TextNote.AddLeader Method

**中文**: 注释、文字注释

Adds a leader to the text note.

## Syntax (C#)
```csharp
public Leader AddLeader(
	TextNoteLeaderTypes leaderType
)
```

## Parameters
- **leaderType** (`Autodesk.Revit.DB.TextNoteLeaderTypes`) - Type of the leader being added.

## Returns
The newly added leader.

## Remarks
If the geometric type of the new leader (line vs arc.) differs
 from the type of existing leaders, then the type of the existing
 leaders will be changed to match the type of the newly created leader.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

