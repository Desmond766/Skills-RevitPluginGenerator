---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceBrowserData.AddResource(System.String,System.String,System.Collections.Generic.IDictionary{System.String,System.String})
source: html/60ea723b-3c92-8408-26f6-08788f29bc25.htm
---
# Autodesk.Revit.DB.ExternalResourceBrowserData.AddResource Method

Adds an external resource to the folder path by supplying the resource name, version and reference information.

## Syntax (C#)
```csharp
public void AddResource(
	string resourceName,
	string version,
	IDictionary<string, string> referenceInformation
)
```

## Parameters
- **resourceName** (`System.String`) - The unique short name of external resource.
- **version** (`System.String`) - The version of external resource.
- **referenceInformation** (`System.Collections.Generic.IDictionary < String , String >`) - The (String, String) map containing reference or lookup information that will
 be stored in Revit.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The resourceName is not a valid resource name used to display in Revit external resource browse UI.
 The name should be a unique non-empty short name and it should not contain any invalid character of \\/:*?"<>|.
 The length of combined path(server name + folder path + resourceName) should not exceeds 259.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

