---
kind: method
id: M:Autodesk.Revit.DB.OBJExportOptions.#ctor(Autodesk.Revit.DB.ExportResolution)
source: html/47145edb-9e79-9cbf-8f33-d47528989442.htm
---
# Autodesk.Revit.DB.OBJExportOptions.#ctor Method

Constructs a new instance of OBJExportOptions with all predefined tessellation settings, depending on export resolution type.
 Note: in case of Custom resolution type, tessellation settings won't be predefined and will have default values.

## Syntax (C#)
```csharp
public OBJExportOptions(
	ExportResolution resolutionType
)
```

## Parameters
- **resolutionType** (`Autodesk.Revit.DB.ExportResolution`) - The type of export resolution.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

