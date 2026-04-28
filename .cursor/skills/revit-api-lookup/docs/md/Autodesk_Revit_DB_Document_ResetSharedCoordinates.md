---
kind: method
id: M:Autodesk.Revit.DB.Document.ResetSharedCoordinates
zh: 文档、文件
source: html/9d41f633-f649-c77b-5c30-463f8ebb01a3.htm
---
# Autodesk.Revit.DB.Document.ResetSharedCoordinates Method

**中文**: 文档、文件

Reset shared coordinates for the host model/file.

## Syntax (C#)
```csharp
public void ResetSharedCoordinates()
```

## Remarks
When you reset shared coordinates, the shared coordinates of the host model will be erased.
 The shared relationship with all the linked models will be eliminated.
 Survey point will be reset back to startup location, where it coincides with the Internal Origin.
 The rotation angle between Project North and True North will be reset back to 0.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Document is not a primary document, it is a linked document.
 -or-
 This Document is not a project document.
 -or-
 This Document is in an edit mode.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

