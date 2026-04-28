---
kind: property
id: P:Autodesk.Revit.DB.Document.FamilyManager
zh: 文档、文件
source: html/478fde66-c9f0-86b5-204a-c95f18b69ca1.htm
---
# Autodesk.Revit.DB.Document.FamilyManager Property

**中文**: 文档、文件

The family manager object provides access to family types and parameters.

## Syntax (C#)
```csharp
public FamilyManager FamilyManager { get; }
```

## Remarks
This property is available when the document is a family document.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the current document is project document.

