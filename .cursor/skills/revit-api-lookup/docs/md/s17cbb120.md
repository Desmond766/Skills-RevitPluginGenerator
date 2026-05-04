---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkInstance.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ImportPlacement)
zh: 创建、新建、生成、建立、新增
source: html/8ec3d668-271b-8333-b4d3-b56d50f4ef98.htm
---
# Autodesk.Revit.DB.RevitLinkInstance.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a linked Revit project (RevitLinkType).

## Syntax (C#)
```csharp
public static RevitLinkInstance Create(
	Document document,
	ElementId revitLinkTypeId,
	ImportPlacement placement
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new instance should be created.
- **revitLinkTypeId** (`Autodesk.Revit.DB.ElementId`) - The element id of the RevitLinkType.
- **placement** (`Autodesk.Revit.DB.ImportPlacement`) - The mode where to place the RevitLinkInstance.
 Set this option to place the view at the origin or by shared coordinates.

## Returns
The newly-created RevitLinkInstance.

## Remarks
Instances will be placed origin-to-origin or by shared coordinates.
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
 -or-
 placement isn't supported.Only Origin or Shared placement is supported.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The placement is Shared, and the host model and the link do not share the same coordinate system.
 Or the placement is Shared, and the shared coordinates of the host model do not match the GIS coordinate system of the linked file.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

