---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkInstance.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/f67e43f0-c799-394c-00a8-9d60a7f70a1b.htm
---
# Autodesk.Revit.DB.RevitLinkInstance.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a linked Revit project (RevitLinkType).

## Syntax (C#)
```csharp
public static RevitLinkInstance Create(
	Document document,
	ElementId revitLinkTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new instance should be created.
- **revitLinkTypeId** (`Autodesk.Revit.DB.ElementId`) - The element id of the RevitLinkType.

## Returns
The newly-created RevitLinkInstance.

## Remarks
Instances will be placed origin-to-origin.
This function cannot be used to create instances
 of nested links.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - revitLinkTypeId isn't a RevitLinkType.
 -or-
 revitLinkTypeId is not a top-level link.
 -or-
 revitLinkTypeId is not a loaded RevitLinkType
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

