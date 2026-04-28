---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.CanLeaderEndConditionBeAssigned(Autodesk.Revit.DB.LeaderEndCondition)
zh: 标记、打标、标签
source: html/83343fd7-5244-12ae-faa0-3fcf082d483e.htm
---
# Autodesk.Revit.DB.IndependentTag.CanLeaderEndConditionBeAssigned Method

**中文**: 标记、打标、标签

Checks whether the LeaderEndCondition can be changed.

## Syntax (C#)
```csharp
public bool CanLeaderEndConditionBeAssigned(
	LeaderEndCondition leaderEndCondition
)
```

## Parameters
- **leaderEndCondition** (`Autodesk.Revit.DB.LeaderEndCondition`) - The leader end condition to check.

## Returns
True if the leader end condition of the tag can be assigned, or false otherwise.

## Remarks
Material tags and material keynotes can only use the free end condition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

