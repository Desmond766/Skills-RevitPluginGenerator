---
kind: method
id: M:Autodesk.Revit.DB.IndependentTag.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Reference,System.Boolean,Autodesk.Revit.DB.TagOrientation,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/b8e8eec2-8e3b-08f2-a9a5-89f24465c8b9.htm
---
# Autodesk.Revit.DB.IndependentTag.Create Method

**中文**: 创建、新建、生成、建立、新增

Places a tag on an element or subelement.

## Syntax (C#)
```csharp
public static IndependentTag Create(
	Document document,
	ElementId symId,
	ElementId ownerDBViewId,
	Reference referenceToTag,
	bool addLeader,
	TagOrientation tagOrientation,
	XYZ pnt
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the tag will be added.
- **symId** (`Autodesk.Revit.DB.ElementId`) - The id for the FamilySymbol which determines the tag's type.
- **ownerDBViewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the tag will be visible.
- **referenceToTag** (`Autodesk.Revit.DB.Reference`) - The host reference of the tag. The reference can be to an element or subelement in a local or linked document.
- **addLeader** (`System.Boolean`) - When true, the tag will be created with a straight leader with an attached end.
- **tagOrientation** (`Autodesk.Revit.DB.TagOrientation`) - The orientation of the tag's head.
- **pnt** (`Autodesk.Revit.DB.XYZ`) - For tags without leaders, this point is the position of the tag head.
 For tags with leaders, this point is the end point of the leader,
 and a leader of default length will be created from this point to the tag head.

## Returns
If successful the new tag is returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId ownerDBViewId does not correspond to a View.
 -or-
 The ElementId ownerDBViewId is a view template.
 -or-
 The ElementId ownerDBViewId is a perspective view.
 -or-
 The 3D view ownerDBViewId is not locked.
 -or-
 The ElementId symId does not correspond to a FamilySymbol.
 -or-
 The reference can not be tagged.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InternalException** - Tag creation failed.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

