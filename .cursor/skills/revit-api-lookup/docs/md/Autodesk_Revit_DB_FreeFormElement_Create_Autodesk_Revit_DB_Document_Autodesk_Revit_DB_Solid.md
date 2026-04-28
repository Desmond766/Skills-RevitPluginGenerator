---
kind: method
id: M:Autodesk.Revit.DB.FreeFormElement.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Solid)
zh: 创建、新建、生成、建立、新增
source: html/a8aa4123-03a0-14c7-f4e5-7bc5a076aa8d.htm
---
# Autodesk.Revit.DB.FreeFormElement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new FreeFormElement from a copy of the input geometry.

## Syntax (C#)
```csharp
public static FreeFormElement Create(
	Document document,
	Solid geometry
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the element is to be created.
- **geometry** (`Autodesk.Revit.DB.Solid`) - The input geometry.

## Returns
returns a new FreeFormElement

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a family document, nor a document editing an in-place family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

