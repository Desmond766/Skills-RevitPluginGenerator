---
kind: method
id: M:Autodesk.Revit.DB.Document.GetDocumentVersion(Autodesk.Revit.DB.Document)
zh: 文档、文件
source: html/177e0f88-29a7-7e66-5db8-9f8ae03ae086.htm
---
# Autodesk.Revit.DB.Document.GetDocumentVersion Method

**中文**: 文档、文件

Gets the DocumentVersion that corresponds to a document.

## Syntax (C#)
```csharp
public static DocumentVersion GetDocumentVersion(
	Document doc
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document whose DocumentVersion will be returned.

## Returns
The DocumentVersion corresponding to the given document.

## Remarks
This function can be combined with IsModified 
 to see whether a document in memory is different from a version on disk. The documents
 are different if the document is modified or if the two DocumentVersions differ.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

