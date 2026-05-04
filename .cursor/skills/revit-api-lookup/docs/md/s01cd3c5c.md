---
kind: method
id: M:Autodesk.Revit.DB.Document.GetWorksetTable
zh: 文档、文件
source: html/b02ace6c-4643-cea6-9545-ea41822731f3.htm
---
# Autodesk.Revit.DB.Document.GetWorksetTable Method

**中文**: 文档、文件

Get the WorksetTable of this document.

## Syntax (C#)
```csharp
public WorksetTable GetWorksetTable()
```

## Returns
The WorksetTable of this document.

## Remarks
There is one WorksetTable for each document.
 There will be at least one workset in the table, even if sharing has not yet been enabled for this document.

