---
kind: type
id: T:Autodesk.Revit.DB.ExternalResourceBrowserData
source: html/94a46450-5467-45f2-0228-4c9f9821b4c9.htm
---
# Autodesk.Revit.DB.ExternalResourceBrowserData

Represents a collection of external resources and external resource folders to be presented as
 the content of a folder in the file browser in Revit.

## Syntax (C#)
```csharp
public class ExternalResourceBrowserData : IDisposable
```

## Remarks
This data represents the contents to be shown to the user while they are browsing a specific folder in Revit. The folder path can be obtained from the FolderPath property. The external resource server is expected to populate all of the available resources and subfolders
 that should appear in the Revit file browser while the browser is open to this particular folder. If the user navigates to another folder, a different ExternalResourceBrowserData object will be
 provided to allow the server to populate resources at that location. When adding resource and subfolder, the resource and subfolder should not be added recursively. When adding resource and subfolder, the name should be unique short name(without folder). The name of resource and subfolder should not contain any invalid character of \/:*?"<>|. The length of resource combined path(server name + folder path + resource name) should not exceed 259;
 The length of subfolder also has same restriction.

