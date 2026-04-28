---
kind: method
id: M:Autodesk.Revit.ApplicationServices.ControlledApplication.GetLibraryPaths
source: html/c73eca5e-72d7-b75b-d47e-7ea2565b3920.htm
---
# Autodesk.Revit.ApplicationServices.ControlledApplication.GetLibraryPaths Method

Returns path information identifying where Revit searches for content.

## Syntax (C#)
```csharp
public IDictionary<string, string> GetLibraryPaths()
```

## Returns
The map of library paths.

## Remarks
The map that
 is returned contains a key that is purpose of the path, such as Material Libraries and the value
 in the map is the fully qualified path that is used for that search path.

