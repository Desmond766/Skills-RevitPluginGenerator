---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceBrowserData.AddResource(System.String)
source: html/94069c9b-d720-6826-bf13-7663e73b08cb.htm
---
# Autodesk.Revit.DB.ExternalResourceBrowserData.AddResource Method

Adds an external resource to the folder path by supplying the resource name.

## Syntax (C#)
```csharp
public void AddResource(
	string resourceName
)
```

## Parameters
- **resourceName** (`System.String`) - The unique short name of external resource.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The resourceName is not a valid resource name used to display in Revit external resource browse UI.
 The name should be a unique non-empty short name and it should not contain any invalid character of \\/:*?"<>|.
 The length of combined path(server name + folder path + resourceName) should not exceeds 259.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

