---
kind: property
id: P:Autodesk.Revit.DB.Document.IsReadOnly
zh: 文档、文件
source: html/7e813a1b-9163-2509-f280-82572598432b.htm
---
# Autodesk.Revit.DB.Document.IsReadOnly Property

**中文**: 文档、文件

Identifies if the document is read-only or can possibly be modified.

## Syntax (C#)
```csharp
public bool IsReadOnly { get; }
```

## Remarks
Like the IsModifiable , IsReadOnly is also a dynamic property.
 It's value can change depending on the state a document is currently in.
 There are various factors that may affect this property.
 The most probable reason for this property to return 'true' is when Revit is currently processing failures (recoverable or not).
 Another possibility is when an external command is executed in read-only mode.
 If a document is in a read-only state, then not only the model cannot be modified at the moment, but even a new transaction may not be started.
 Attempting to do so will raise an InvalidOperationException.

