---
kind: property
id: P:Autodesk.Revit.DB.Document.FamilyCreate
zh: 文档、文件
source: html/693b2a55-b3a2-5d18-fcc4-e24448a16039.htm
---
# Autodesk.Revit.DB.Document.FamilyCreate Property

**中文**: 文档、文件

An object that can be used to create new instances of Autodesk Revit API elements
within a family document.

## Syntax (C#)
```csharp
public FamilyItemFactory FamilyCreate { get; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the current document is project document.

