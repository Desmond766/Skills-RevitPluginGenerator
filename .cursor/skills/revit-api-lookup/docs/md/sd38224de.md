---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceBrowserData.AddSubFolder(System.String,System.String)
source: html/6a60f937-fa5f-55e7-7b16-cc009283990f.htm
---
# Autodesk.Revit.DB.ExternalResourceBrowserData.AddSubFolder Method

Adds a subfolder to the folder path with the given name and icon type.

## Syntax (C#)
```csharp
public void AddSubFolder(
	string folderName,
	string iconPath
)
```

## Parameters
- **folderName** (`System.String`) - The name of the folder.
- **iconPath** (`System.String`) - Icon path.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The folderName is not a valid folder name used to display in Revit external resource browse UI.
 The name should be a unique non-empty short name and it should not contain any invalid character of \\/:*?"<>|.
 The length of combined path(server name + folder path) should not exceeds 259.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

