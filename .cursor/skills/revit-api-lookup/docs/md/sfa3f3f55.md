---
kind: property
id: P:Autodesk.Revit.DB.Document.IsReadOnlyFile
zh: 文档、文件
source: html/c189f723-1465-0353-2ec1-57183905d73a.htm
---
# Autodesk.Revit.DB.Document.IsReadOnlyFile Property

**中文**: 文档、文件

Signals whether the document was opened from a read-only file.

## Syntax (C#)
```csharp
public bool IsReadOnlyFile { get; }
```

## Remarks
A document could be opened this way when, for example, at the time of opening
 the file was being used by another Revit user, or if the disk file has the read-only attribute set.
Although it will still be possible to modify the opened document,
 any changes made there will not be possible to save into the original file.
 If the changes are to be preserved, the document must be saved under a different
 name using the SaveAs() method.

