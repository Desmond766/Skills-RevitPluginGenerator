---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.GetLibraryPaths
source: html/4782f03c-9661-3bb5-0156-03ef96a2c69b.htm
---
# Autodesk.Revit.ApplicationServices.Application.GetLibraryPaths Method

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

