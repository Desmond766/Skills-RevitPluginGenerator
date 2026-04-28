---
kind: method
id: M:Autodesk.Revit.DB.Document.GetCloudModelUrn
zh: 文档、文件
source: html/7c2bced8-b309-b67f-2b82-13299c617a0b.htm
---
# Autodesk.Revit.DB.Document.GetCloudModelUrn Method

**中文**: 文档、文件

A ForgeDM Urn identifying the model.

## Syntax (C#)
```csharp
public string GetCloudModelUrn()
```

## Remarks
It is empty for non-cloud model;
 It is cached in Revit model opened session after getting it;

## Exceptions
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - Thrown when cannot get data from ForgeDM.

