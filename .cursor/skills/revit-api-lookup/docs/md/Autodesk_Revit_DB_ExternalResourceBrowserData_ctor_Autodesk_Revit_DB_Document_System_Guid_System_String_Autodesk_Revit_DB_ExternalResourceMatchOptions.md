---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceBrowserData.#ctor(Autodesk.Revit.DB.Document,System.Guid,System.String,Autodesk.Revit.DB.ExternalResourceMatchOptions)
source: html/eabd8602-8d03-9d9f-455e-bda1d0667f18.htm
---
# Autodesk.Revit.DB.ExternalResourceBrowserData.#ctor Method

Constructs a new ExternalResourceBrowserData using the given document(optional), server id, folder path and match options.

## Syntax (C#)
```csharp
public ExternalResourceBrowserData(
	Document document,
	Guid serverId,
	string folderPath,
	ExternalResourceMatchOptions matchOptions
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for which the external resource browser data is requested.
 The document can be Nothing nullptr a null reference ( Nothing in Visual Basic) , if so, the getCallingDocumentModelPath() will not return ModelPath.
- **serverId** (`System.Guid`) - The id of IExternalResourceServer which handles the external resource browsing and loading.
- **folderPath** (`System.String`) - The folder path to which the external resources and subfolders belong.
 The folder separator should always be "/" and "/" always represents the root folder for the server. The interpretation of what a folder represents is up to the server.
 For example, the folder "/English/Keynote" might be a physical folder on a disk, or a table or key in a database.
- **matchOptions** (`Autodesk.Revit.DB.ExternalResourceMatchOptions`) - The options to match the external resources and folders.
 Generally, the returned resources should match the options, otherwise the resource may be regarded
 as invalid which may not be available in browser dialogs.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

