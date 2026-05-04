---
kind: property
id: P:Autodesk.Revit.DB.Document.IsDetached
zh: 文档、文件
source: html/0792283e-f112-0a57-d0d9-e79e6b9ea5b9.htm
---
# Autodesk.Revit.DB.Document.IsDetached Property

**中文**: 文档、文件

Identifies if a workshared document is detached.
 Also, see IsWorkshared

## Syntax (C#)
```csharp
public bool IsDetached { get; }
```

## Remarks
Note that Title and PathName will be empty strings if a document is detached.

