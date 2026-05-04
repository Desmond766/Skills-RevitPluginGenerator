---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.GetLeaderElbow(Autodesk.Revit.DB.Reference)
zh: 标记、打标、标签
source: html/cb3f9617-d5a4-7c45-1686-d7c2f60effad.htm
---
# Autodesk.Revit.DB.IndependentTag.GetLeaderElbow Method

**中文**: 标记、打标、标签

Returns the position of the elbow of the tag's leader that points to specified reference.
 Position of leader's elbow.

## Syntax (C#)
```csharp
public XYZ GetLeaderElbow(
	Reference referenceTagged
)
```

## Parameters
- **referenceTagged** (`Autodesk.Revit.DB.Reference`) - The reference which is tagged.

## Remarks
Straight leaders do not have elbow points.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The specified reference does not have a leader or its leader is straight.
 -or-
 The specified reference is not currently tagged.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The IndependentTag object does not have a tag behavior.

