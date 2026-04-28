---
kind: type
id: T:Autodesk.Revit.DB.ExternalResourceUIBrowseResultType
source: html/87f3e9ad-042d-6ef8-a1f7-c12ebfcac7d7.htm
---
# Autodesk.Revit.DB.ExternalResourceUIBrowseResultType

Describes the type of external resource browsing result.

## Syntax (C#)
```csharp
public enum ExternalResourceUIBrowseResultType
```

## Remarks
This enum is used to describe the type of external resources browsing operation result ( the browsing operation
 include list folders and resources of an external server or a folder, or open an external resource in browsing dialog.)
The meaning of each enum value:
 There is no predefined error happened during this browse operation. The DB server can store any errors itself in this case. FolderNotFound means the external resource folder want to browse could not be founded in external server. ResourceNotFound means the external resource want to open could not be founded in external server.

