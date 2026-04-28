---
kind: method
id: M:Autodesk.Revit.DB.Document.GetCloudFolderId(System.Boolean)
zh: 文档、文件
source: html/e4177a0c-9c2a-5cd4-2f53-11d2c95004eb.htm
---
# Autodesk.Revit.DB.Document.GetCloudFolderId Method

**中文**: 文档、文件

Gets ForgeDM folder id where the model locates.

## Syntax (C#)
```csharp
public string GetCloudFolderId(
	bool forceRefresh
)
```

## Parameters
- **forceRefresh** (`System.Boolean`) - Cached value will be refreshed by sending a service call when forceRefresh is true.

## Remarks
It is empty for non-cloud model;
 It is cached in Revit model opened session after getting it if forceRefresh is false;
 ForgeDM folder id can be changed during Revit model opened session, set forceRefresh as 'true' to get new value.

## Exceptions
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - Thrown when cannot get data from ForgeDM for Revit cloud model.

