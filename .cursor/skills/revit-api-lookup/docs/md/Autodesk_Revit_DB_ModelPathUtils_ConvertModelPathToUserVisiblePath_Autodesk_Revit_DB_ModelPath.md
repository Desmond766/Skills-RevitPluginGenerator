---
kind: method
id: M:Autodesk.Revit.DB.ModelPathUtils.ConvertModelPathToUserVisiblePath(Autodesk.Revit.DB.ModelPath)
source: html/7ca1694a-6795-1ee0-5c24-9236a43c5405.htm
---
# Autodesk.Revit.DB.ModelPathUtils.ConvertModelPathToUserVisiblePath Method

Gets a string version of the path of a given ModelPath.

## Syntax (C#)
```csharp
public static string ConvertModelPathToUserVisiblePath(
	ModelPath path
)
```

## Parameters
- **path** (`Autodesk.Revit.DB.ModelPath`) - A ModelPath representing a file path or a server path.

## Returns
The path in string form

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

