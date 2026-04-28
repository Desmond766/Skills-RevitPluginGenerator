---
kind: method
id: M:Autodesk.Revit.DB.ExportLinetypeTable.GetExportLinetypeInfo(Autodesk.Revit.DB.ExportLinetypeKey)
source: html/3699c956-98ce-c66f-3558-da5b037eff34.htm
---
# Autodesk.Revit.DB.ExportLinetypeTable.GetExportLinetypeInfo Method

Gets a copy of the ExportLinetypeInfo corresponding to the given ExportLinetypeKey.

## Syntax (C#)
```csharp
public ExportLinetypeInfo GetExportLinetypeInfo(
	ExportLinetypeKey exportLinetypeKey
)
```

## Parameters
- **exportLinetypeKey** (`Autodesk.Revit.DB.ExportLinetypeKey`) - The export line type Key.

## Returns
Returns the line type info for this key.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - An entry with the given key is not present in the table.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

