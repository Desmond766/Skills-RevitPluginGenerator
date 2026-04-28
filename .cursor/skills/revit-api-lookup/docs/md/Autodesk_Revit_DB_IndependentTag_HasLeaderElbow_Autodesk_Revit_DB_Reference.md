---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.HasLeaderElbow(Autodesk.Revit.DB.Reference)
zh: 标记、打标、标签
source: html/f4febfed-3134-a5c0-0f8e-d4e6c5b4b675.htm
---
# Autodesk.Revit.DB.IndependentTag.HasLeaderElbow Method

**中文**: 标记、打标、标签

Whether the tag's leader that points to the reference has an elbow point or not.

## Syntax (C#)
```csharp
public bool HasLeaderElbow(
	Reference referenceTagged
)
```

## Parameters
- **referenceTagged** (`Autodesk.Revit.DB.Reference`)

## Returns
True if the reference has a leader with an elbow point, or false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The specified reference is not currently tagged.
 -or-
 The leader for the tagged reference isn't visible.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The IndependentTag object does not have a tag behavior.

