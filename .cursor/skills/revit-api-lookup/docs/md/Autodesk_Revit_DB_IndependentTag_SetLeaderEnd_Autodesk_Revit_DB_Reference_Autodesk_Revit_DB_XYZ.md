---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.SetLeaderEnd(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.XYZ)
zh: 标记、打标、标签
source: html/fb54c007-6873-68f4-4772-e777609a441b.htm
---
# Autodesk.Revit.DB.IndependentTag.SetLeaderEnd Method

**中文**: 标记、打标、标签

Set the end position of the tag's leader that points to specified reference.

## Syntax (C#)
```csharp
public void SetLeaderEnd(
	Reference referenceTagged,
	XYZ pointEnd
)
```

## Parameters
- **referenceTagged** (`Autodesk.Revit.DB.Reference`) - The reference which is tagged.
- **pointEnd** (`Autodesk.Revit.DB.XYZ`) - Point representing the end position of tag's leader

## Remarks
Tags with attached leaders or no leaders do not support leader ends.
 LeaderEndCondition for the tag's leader condition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is no leader end because the tag does not use a free end leader or the leader is not visible.
 -or-
 The specified reference is not currently tagged.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The IndependentTag object does not have a tag behavior.

