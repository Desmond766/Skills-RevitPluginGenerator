---
kind: method
id: M:Autodesk.Revit.DB.ImportInstance.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.View)
zh: 创建、新建、生成、建立、新增
source: html/272fbd90-bc15-991a-894e-c52d46613719.htm
---
# Autodesk.Revit.DB.ImportInstance.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of an existing DWG link type.

## Syntax (C#)
```csharp
public static ImportInstance Create(
	Document document,
	ElementId typeId,
	View DBView
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the new instacne of DWG link type.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The element id of the existing DWG link type.
- **DBView** (`Autodesk.Revit.DB.View`) - The view into which the new instance of DWG link type will be created.

## Returns
The new instance of the given DWG link type.

## Remarks
This function regenerates the input document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 document is in an edit mode.
 -or-
 The view is not printable.
 -or-
 The element id is not of a valid CADLinkType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

