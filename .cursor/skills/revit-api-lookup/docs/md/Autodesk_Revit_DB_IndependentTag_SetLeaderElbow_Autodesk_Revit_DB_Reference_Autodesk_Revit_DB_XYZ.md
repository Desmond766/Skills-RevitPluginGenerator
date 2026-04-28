---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.SetLeaderElbow(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.XYZ)
zh: 标记、打标、标签
source: html/dd5a7d21-cb13-d3d7-6dd6-8e8e427e4873.htm
---
# Autodesk.Revit.DB.IndependentTag.SetLeaderElbow Method

**中文**: 标记、打标、标签

Set the position of the elbow of the tag's leader that points to specified reference.
 If this tag is a multileader tag and the elbows are merged, the input position will be set to all leaders.

## Syntax (C#)
```csharp
public void SetLeaderElbow(
	Reference referenceTagged,
	XYZ elbowPosition
)
```

## Parameters
- **referenceTagged** (`Autodesk.Revit.DB.Reference`) - The reference which is tagged.
- **elbowPosition** (`Autodesk.Revit.DB.XYZ`) - The position of the elbow.

## Remarks
Straight leaders do not have elbow points.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The specified reference is not currently tagged.
 -or-
 The leader for the tagged reference isn't visible.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The IndependentTag object does not have a tag behavior.

