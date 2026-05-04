---
kind: method
id: M:Autodesk.Revit.DB.ProjectLocation.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.String)
zh: 创建、新建、生成、建立、新增
source: html/b13b3906-f110-577b-e436-01949dc3239e.htm
---
# Autodesk.Revit.DB.ProjectLocation.Create Method

**中文**: 创建、新建、生成、建立、新增

Create an instance of ProjectLocation in the document.

## Syntax (C#)
```csharp
public static ProjectLocation Create(
	Document document,
	ElementId siteLocationId,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the new instance of ProjectLocation would be created in.
- **siteLocationId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the SiteLocation to which the new ProjectLocation would be created.
- **name** (`System.String`) - The name of the instance of ProjectLocation to be created.

## Returns
The newly created instance of ProjectLocation.

## Remarks
The created instace of ProjectLocation would have the specified name and an identity Transform .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 The element siteLocationId does not exist in the document
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 There is already a ProjectLocation with this name in the given SiteLocation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

