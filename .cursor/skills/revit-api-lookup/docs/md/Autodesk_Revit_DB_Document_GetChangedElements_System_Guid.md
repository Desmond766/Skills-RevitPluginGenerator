---
kind: method
id: M:Autodesk.Revit.DB.Document.GetChangedElements(System.Guid)
zh: 文档、文件
source: html/0799eb9e-5ce8-2668-eb3d-aecfd121b2d6.htm
---
# Autodesk.Revit.DB.Document.GetChangedElements Method

**中文**: 文档、文件

Extracts a collection containing the ids of elements that have been created, modified or deleted between the input baseVersion and the document's current version.

## Syntax (C#)
```csharp
public DocumentDifference GetChangedElements(
	Guid baseVersionGUID
)
```

## Parameters
- **baseVersionGUID** (`System.Guid`) - GUID of base version(excluded) to compare. This GUID should be retrieved from property [!:Autodesk::Revit::DB::DocumentVersion::VersoinGUID] .
 Empty GUID is allowed to retrieve changes of each version in the document.

## Returns
An object containing collections of the created, modified and deleted ids between the input version and current version.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This GUID is invalid in the given document.

