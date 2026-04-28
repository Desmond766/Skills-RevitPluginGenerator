---
kind: method
id: M:Autodesk.Revit.DB.STLExportOptions.SetTessellationSettings(Autodesk.Revit.DB.ExportResolution)
source: html/05429687-e49f-97c7-946c-d176bb6f7123.htm
---
# Autodesk.Revit.DB.STLExportOptions.SetTessellationSettings Method

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

