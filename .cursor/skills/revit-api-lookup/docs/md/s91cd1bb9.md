---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.GetLeaderEnd(Autodesk.Revit.DB.Reference)
zh: 标记、打标、标签
source: html/d6f69738-aa40-d45c-5ab5-ba02d55d0837.htm
---
# Autodesk.Revit.DB.IndependentTag.GetLeaderEnd Method

**中文**: 标记、打标、标签

Returns the end position of the tag's leader that points to specified reference.

## Syntax (C#)
```csharp
public XYZ GetLeaderEnd(
	Reference referenceTagged
)
```

## Parameters
- **referenceTagged** (`Autodesk.Revit.DB.Reference`) - The reference which is tagged.

## Returns
Point representing the end position of tag's leader

## Remarks
Tags with attached leaders or no leaders do not support leader ends.
 LeaderEndCondition for the tag's leader condition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is no leader end because the tag does not use a free end leader or the leader is not visible.
 -or-
 The specified reference is not currently tagged.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The IndependentTag object does not have a tag behavior.

