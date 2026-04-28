---
kind: property
id: P:Autodesk.Revit.DB.Document.WorksharingCentralGUID
zh: 文档、文件
source: html/93287b85-2c12-ff55-177e-2a419fa893df.htm
---
# Autodesk.Revit.DB.Document.WorksharingCentralGUID Property

**中文**: 文档、文件

The central GUID of the server-based model.

## Syntax (C#)
```csharp
public Guid WorksharingCentralGUID { get; }
```

## Remarks
The central model of this document that is file-based model or saved in a release prior to Revit 2013 did not have this GUID.
 Only the central model saved in Revit 2013 or later and stored on Revit Server will be able to provide this value.

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - Thrown when the central model of this document is not a server-based model that created in Revit 2013 or later release.

