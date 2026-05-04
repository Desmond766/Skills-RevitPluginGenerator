---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceBrowserData.AddResource(System.String,System.String)
source: html/62f87583-84e5-1481-35a6-f8610bc4f448.htm
---
# Autodesk.Revit.DB.ExternalResourceBrowserData.AddResource Method

Adds an external resource to the folder path by supplying the resource name and version.

## Syntax (C#)
```csharp
public void AddResource(
	string resourceName,
	string version
)
```

## Parameters
- **resourceName** (`System.String`) - The unique short name of external resource.
- **version** (`System.String`) - The version of external resource.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The resourceName is not a valid resource name used to display in Revit external resource browse UI.
 The name should be a unique non-empty short name and it should not contain any invalid character of \\/:*?"<>|.
 The length of combined path(server name + folder path + resourceName) should not exceeds 259.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

