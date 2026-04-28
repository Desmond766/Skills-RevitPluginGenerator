---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceBrowserData.AddResource(System.String,System.Collections.Generic.IDictionary{System.String,System.String})
source: html/44f19e8a-789f-1181-3ec1-def94c1e1a3d.htm
---
# Autodesk.Revit.DB.ExternalResourceBrowserData.AddResource Method

Adds an external resource to the folder path by supplying the resource name and reference information.

## Syntax (C#)
```csharp
public void AddResource(
	string resourceName,
	IDictionary<string, string> referenceInformation
)
```

## Parameters
- **resourceName** (`System.String`) - The unique short name of external resource.
- **referenceInformation** (`System.Collections.Generic.IDictionary < String , String >`) - The (String, String) map containing reference or lookup information that will
 be stored in Revit.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The resourceName is not a valid resource name used to display in Revit external resource browse UI.
 The name should be a unique non-empty short name and it should not contain any invalid character of \\/:*?"<>|.
 The length of combined path(server name + folder path + resourceName) should not exceeds 259.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

