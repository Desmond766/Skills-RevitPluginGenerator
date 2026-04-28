---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.SetLibraryPaths(System.Collections.Generic.IDictionary{System.String,System.String})
source: html/67893fd8-1081-4d01-8ce3-6ea21b511a8a.htm
---
# Autodesk.Revit.ApplicationServices.Application.SetLibraryPaths Method

Sets path information identifying where Revit searches for content.

## Syntax (C#)
```csharp
public void SetLibraryPaths(
	IDictionary<string, string> paths
)
```

## Parameters
- **paths** (`System.Collections.Generic.IDictionary < String , String >`) - The map of library paths.

## Remarks
The map that
 is returned should contain a key that is purpose of the path, such as Material Libraries and the value
 in the map is the fully qualified path to be used for that search path.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

