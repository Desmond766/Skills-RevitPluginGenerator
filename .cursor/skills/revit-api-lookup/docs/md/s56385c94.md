---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/bc9e8be3-f3fd-97c2-2709-1d6eea3db775.htm
---
# Autodesk.Revit.DB.ViewSheet.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new ViewSheet.

## Syntax (C#)
```csharp
public static ViewSheet Create(
	Document document,
	ElementId titleBlockTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the ViewSheet will be added.
- **titleBlockTypeId** (`Autodesk.Revit.DB.ElementId`) - The type id of the TitleBlock type which will be used by the new ViewSheet.
 For no TitleBlock, pass invalid element ID.

## Returns
The new ViewSheet.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId titleBlockTypeId does not correspond to a TitleBlock type.
 -or-
 document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

