---
kind: method
id: M:Autodesk.Revit.DB.DividedSurface.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
zh: 创建、新建、生成、建立、新增
source: html/b90ea001-cbb4-0fdf-89a0-1635255bdfd2.htm
---
# Autodesk.Revit.DB.DividedSurface.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a divided surface with a default layout.

## Syntax (C#)
```csharp
public static DividedSurface Create(
	Document document,
	Reference faceReference
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **faceReference** (`Autodesk.Revit.DB.Reference`) - Reference that represents a face.

## Returns
The newly created divided surface.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document does not allow creation of a divided surface.
 -or-
 Reference is unstable import element
 -or-
 Reference does not represent a face
 -or-
 Reference already hosts a divided surface
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

