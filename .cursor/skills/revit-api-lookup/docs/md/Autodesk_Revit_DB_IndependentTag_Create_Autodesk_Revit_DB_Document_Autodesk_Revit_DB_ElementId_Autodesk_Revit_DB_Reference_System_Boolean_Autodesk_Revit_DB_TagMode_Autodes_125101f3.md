---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Reference,System.Boolean,Autodesk.Revit.DB.TagMode,Autodesk.Revit.DB.TagOrientation,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/1f622654-786a-b8fd-1f81-278698bacd5b.htm
---
# Autodesk.Revit.DB.IndependentTag.Create Method

**中文**: 创建、新建、生成、建立、新增

Places a tag on an element or subelement.

## Syntax (C#)
```csharp
public static IndependentTag Create(
	Document document,
	ElementId ownerDBViewId,
	Reference referenceToTag,
	bool addLeader,
	TagMode tagMode,
	TagOrientation tagOrientation,
	XYZ pnt
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the tag will be added.
- **ownerDBViewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the tag will be visible.
- **referenceToTag** (`Autodesk.Revit.DB.Reference`) - The host reference of the tag. The reference can be to an element or subelement in a local or linked document.
- **addLeader** (`System.Boolean`) - When true, the tag will be created with a straight leader with an attached end.
- **tagMode** (`Autodesk.Revit.DB.TagMode`) - This argument determines the type of tag that will be created. Tag by category, multi-category tag, and material tag are allowed.
- **tagOrientation** (`Autodesk.Revit.DB.TagOrientation`) - The orientation of the tag's head.
- **pnt** (`Autodesk.Revit.DB.XYZ`) - For tags without leaders, this point is the position of the tag head.
 For tags with leaders, this point is the end point of the leader, and a leader of default length will be created from this point to the tag head.

## Returns
If successful the new tag is returned.

## Remarks
Single category tags, multi-category tags and material tags can be placed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId ownerDBViewId does not correspond to a View.
 -or-
 The ElementId ownerDBViewId is a view template.
 -or-
 The ElementId ownerDBViewId is a perspective view.
 -or-
 The 3D view ownerDBViewId is not locked.
 -or-
 The reference can not be tagged.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InternalException** - Tag creation failed.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - There is no loaded tag type that can be used when tagging referenceToTag with tagMode.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

