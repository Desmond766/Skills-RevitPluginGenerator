---
kind: method
id: M:Autodesk.Revit.DB.IExternalResourceServer.GetShortName
source: html/a6a074b3-3b57-e954-83d4-64ca4e973852.htm
---
# Autodesk.Revit.DB.IExternalResourceServer.GetShortName Method

Implement this method to return the short name of the server.

## Syntax (C#)
```csharp
string GetShortName()
```

## Returns
The short name of the server.

## Remarks
The name is a unique path prefix included in full paths to external resources provided by this server.
 It is recommended that the short name length is at least 3 characters to make it useful for
 users to identify the server easily.
 To ensure the server can be registered successfully, the name should match restrictions below: The name cannot be empty or consist of only whitespace characters. The name should not include any invalid characters such as \/:*?"<>|. The name cannot duplicate any other external resource server names. The name should not duplicate a Revit reserved path prefix(case insensitive), including:
 RSN, A360, buzzsaw, vault, redspark, ftp, http, https, files, file.

