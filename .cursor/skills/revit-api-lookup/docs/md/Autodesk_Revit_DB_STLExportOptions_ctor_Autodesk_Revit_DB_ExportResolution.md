---
kind: method
id: M:Autodesk.Revit.DB.STLExportOptions.#ctor(Autodesk.Revit.DB.ExportResolution)
source: html/8fadfd48-c01f-fb58-0761-baa6cee59cb9.htm
---
# Autodesk.Revit.DB.STLExportOptions.#ctor Method

Constructs a new instance of STLExportOptions with all predefined tessellation settings, depending on export resolution type.
 Note: in case of Custom resolution type, tessellation settings won't be predefined and will have default values.

## Syntax (C#)
```csharp
public STLExportOptions(
	ExportResolution resolutionType
)
```

## Parameters
- **resolutionType** (`Autodesk.Revit.DB.ExportResolution`) - The type of export resolution.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

