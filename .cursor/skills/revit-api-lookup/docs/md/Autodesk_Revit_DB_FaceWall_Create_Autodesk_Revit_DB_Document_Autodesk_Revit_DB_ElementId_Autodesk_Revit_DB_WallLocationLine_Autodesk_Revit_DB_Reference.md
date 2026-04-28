---
kind: method
id: M:Autodesk.Revit.DB.FaceWall.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.WallLocationLine,Autodesk.Revit.DB.Reference)
zh: 创建、新建、生成、建立、新增
source: html/751ee1bb-878d-da68-9a70-57f051f4d13e.htm
---
# Autodesk.Revit.DB.FaceWall.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a wall attached to a non-vertical massing face.

## Syntax (C#)
```csharp
public static FaceWall Create(
	Document document,
	ElementId wallType,
	WallLocationLine locationLine,
	Reference faceReference
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **wallType** (`Autodesk.Revit.DB.ElementId`) - The wall type. This must be a wall type accepted by IsWallTypeValidForFaceWall()
- **locationLine** (`Autodesk.Revit.DB.WallLocationLine`) - The alignment of the wall location line.
- **faceReference** (`Autodesk.Revit.DB.Reference`) - The reference from the massing face. This must pass IsValidFaceReferenceForFaceWall()

## Returns
The newly created face wall.

## Remarks
This method will regenerate the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element wallType does not exist in the document
 -or-
 document is not a project document.
 -or-
 This wall type cannot be applied to a face wall.
 -or-
 This reference cannot be applied to a face wall.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - During a dynamic update, the newly created face wall is going to be joined to surrounding structures.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The element is a member of a loaded family.
 -or-
 The element is a member of a group type that is
 not being edited.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

