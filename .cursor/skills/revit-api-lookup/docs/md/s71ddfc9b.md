---
kind: method
id: M:Autodesk.Revit.DB.Document.AutoJoinElements
zh: 文档、文件
source: html/a3c929fb-6164-c7bb-d140-4178fb07fd4e.htm
---
# Autodesk.Revit.DB.Document.AutoJoinElements Method

**中文**: 文档、文件

Forces the elements in the Revit document to automatically join to their neighbors where appropriate.

## Syntax (C#)
```csharp
public void AutoJoinElements()
```

## Remarks
Use this method to force elements in the document to automatically join to their neighbors. Note that when a transaction 
is committed there is an automatic call to automatically join elements.

## Exceptions
- **Autodesk.Revit.Exceptions.AutoJoinFailedException** - Thrown when the operation fails.

