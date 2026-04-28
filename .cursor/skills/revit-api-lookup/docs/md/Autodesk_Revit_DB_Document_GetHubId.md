---
kind: method
id: M:Autodesk.Revit.DB.Document.GetHubId
zh: 文档、文件
source: html/e9756087-8232-88ca-c2ac-90ba51a87914.htm
---
# Autodesk.Revit.DB.Document.GetHubId Method

**中文**: 文档、文件

Gets ForgeDM hub id where the model locates. It is cached in session.

## Syntax (C#)
```csharp
public string GetHubId()
```

## Remarks
It is empty for non-cloud model;
 It is cached in Revit model opened session after getting it;

## Exceptions
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - Thrown when cannot get data from ForgeDM for Revit cloud model.

