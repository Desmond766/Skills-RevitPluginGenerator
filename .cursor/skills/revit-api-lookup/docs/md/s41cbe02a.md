---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.IsLeaderVisible(Autodesk.Revit.DB.Reference)
zh: 标记、打标、标签
source: html/8ad822df-1fb8-938f-66d4-60ade8983c40.htm
---
# Autodesk.Revit.DB.IndependentTag.IsLeaderVisible Method

**中文**: 标记、打标、标签

Returns if leader that points to specified reference is visible or not.

## Syntax (C#)
```csharp
public bool IsLeaderVisible(
	Reference referenceTagged
)
```

## Parameters
- **referenceTagged** (`Autodesk.Revit.DB.Reference`) - The reference which is tagged.

## Returns
Returns true if leader that points to specified reference is visible, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The specified reference is not currently tagged.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The IndependentTag object does not have a tag behavior.

