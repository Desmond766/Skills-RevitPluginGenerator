---
kind: property
id: P:Autodesk.Revit.DB.Document.Title
zh: 文档、文件
source: html/4cee7916-d799-fc83-daf3-97cb03900b72.htm
---
# Autodesk.Revit.DB.Document.Title Property

**中文**: 文档、文件

The document's title.

## Syntax (C#)
```csharp
public string Title { get; }
```

## Remarks
Title is derived from the document's filename, not including the filename extension.
 Note that returned title will be defaulted if no document saved.
 Note that returned string may be empty if a document is detached. See IsDetached .

