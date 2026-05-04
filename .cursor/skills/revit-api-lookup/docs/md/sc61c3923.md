---
kind: method
id: M:Autodesk.Revit.DB.Document.GetProjectId
zh: 文档、文件
source: html/902d5aa9-9f3f-a9e9-0d0a-4c95fa820890.htm
---
# Autodesk.Revit.DB.Document.GetProjectId Method

**中文**: 文档、文件

Gets ForgeDM project id where the model locates.

## Syntax (C#)
```csharp
public string GetProjectId()
```

## Remarks
It is empty for non-cloud model;
 It is cached in Revit model opened session after getting it;

## Exceptions
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - Thrown when cannot get data from ForgeDM for Revit cloud model.

