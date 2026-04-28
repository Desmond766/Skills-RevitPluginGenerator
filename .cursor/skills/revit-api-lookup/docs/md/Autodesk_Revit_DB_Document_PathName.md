---
kind: property
id: P:Autodesk.Revit.DB.Document.PathName
zh: 文档、文件
source: html/8a92a6fd-ce25-cd86-2068-f9dcb24d72d6.htm
---
# Autodesk.Revit.DB.Document.PathName Property

**中文**: 文档、文件

The fully qualified path of the document's disk file.

## Syntax (C#)
```csharp
public string PathName { get; }
```

## Remarks
This string is empty if the project has not been saved
 or does not have a disk file associated with it yet.
 Note that the pathname will be empty if a document is detached. See IsDetached .

