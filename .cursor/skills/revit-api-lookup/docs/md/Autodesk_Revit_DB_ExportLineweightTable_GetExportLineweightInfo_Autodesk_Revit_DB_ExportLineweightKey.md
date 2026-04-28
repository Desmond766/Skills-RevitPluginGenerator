---
kind: method
id: M:Autodesk.Revit.DB.ExportLineweightTable.GetExportLineweightInfo(Autodesk.Revit.DB.ExportLineweightKey)
source: html/03b391a2-c9ca-f501-28cb-f109966df57f.htm
---
# Autodesk.Revit.DB.ExportLineweightTable.GetExportLineweightInfo Method

Gets a copy of the ExportLineweightInfo corresponding to the given ExportLineweightKey.

## Syntax (C#)
```csharp
public ExportLineweightInfo GetExportLineweightInfo(
	ExportLineweightKey exportLineweightKey
)
```

## Parameters
- **exportLineweightKey** (`Autodesk.Revit.DB.ExportLineweightKey`) - The export line weight Key.

## Returns
Returns the line weight info for this key.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - An entry with the given key is not present in the table.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

