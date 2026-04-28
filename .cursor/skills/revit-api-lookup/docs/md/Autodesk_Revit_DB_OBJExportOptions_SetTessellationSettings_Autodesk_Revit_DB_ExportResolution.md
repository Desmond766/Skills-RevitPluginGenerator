---
kind: method
id: M:Autodesk.Revit.DB.OBJExportOptions.SetTessellationSettings(Autodesk.Revit.DB.ExportResolution)
source: html/69d6f0a1-0dc0-a607-4b87-503b4a3ed833.htm
---
# Autodesk.Revit.DB.OBJExportOptions.SetTessellationSettings Method

Sets all the tessellation parameters to its predefined values for the given resolution type.

## Syntax (C#)
```csharp
public void SetTessellationSettings(
	ExportResolution resolutionType
)
```

## Parameters
- **resolutionType** (`Autodesk.Revit.DB.ExportResolution`) - Type of exporting resolution.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

