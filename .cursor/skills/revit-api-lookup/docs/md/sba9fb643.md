---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.SetIsLeaderVisible(Autodesk.Revit.DB.Reference,System.Boolean)
zh: 标记、打标、标签
source: html/b0b7f9bc-163b-01a6-9a8c-fa7cfc6c61a0.htm
---
# Autodesk.Revit.DB.IndependentTag.SetIsLeaderVisible Method

**中文**: 标记、打标、标签

Set tag's leader that points to specified reference to be visible or not. This option can be set only if the LeadersPresentationMode is ShowSpecificLeaders.

## Syntax (C#)
```csharp
public void SetIsLeaderVisible(
	Reference referenceTagged,
	bool visible
)
```

## Parameters
- **referenceTagged** (`Autodesk.Revit.DB.Reference`) - The reference which is tagged.
- **visible** (`System.Boolean`) - True for showing the leader, false to hide it.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The specified reference is not currently tagged.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The IndependentTag object does not have a tag behavior.
 -or-
 The LeadersPresentationMode should be set to ShowSpecificLeaders.

