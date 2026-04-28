---
kind: property
id: P:Autodesk.Revit.DB.Document.ReactionsAreUpToDate
zh: 文档、文件
source: html/55afb606-0de5-3f44-04e7-ccbe4a852c6a.htm
---
# Autodesk.Revit.DB.Document.ReactionsAreUpToDate Property

**中文**: 文档、文件

Reports if the analytical model has regenerated in a document with reaction loads.

## Syntax (C#)
```csharp
public bool ReactionsAreUpToDate { get; }
```

## Remarks
Revit sets this property to False after regeneration of the analytical model if the document contains loads that have isReaction=True.
This results in a user-visible warning that exists until there are no longer loads with isReaction=True.

