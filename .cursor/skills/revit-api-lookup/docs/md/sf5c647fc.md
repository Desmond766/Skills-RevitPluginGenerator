---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceBrowserData.AddSubFolder(System.String)
source: html/b4156741-2375-50f9-1c33-7efaa42b8b06.htm
---
# Autodesk.Revit.DB.ExternalResourceBrowserData.AddSubFolder Method

Adds a subfolder to the folder path with the given name.

## Syntax (C#)
```csharp
public void AddSubFolder(
	string folderName
)
```

## Parameters
- **folderName** (`System.String`) - The name of the folder.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The folderName is not a valid folder name used to display in Revit external resource browse UI.
 The name should be a unique non-empty short name and it should not contain any invalid character of \\/:*?"<>|.
 The length of combined path(server name + folder path) should not exceeds 259.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

