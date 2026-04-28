---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetCellCombinedParameters(System.Int32,System.Int32)
source: html/ba732c4f-4b6e-14f8-439e-e802ad2aa2db.htm
---
# Autodesk.Revit.DB.TableSectionData.GetCellCombinedParameters Method

Returns an array of combined parameter data for the specified cell

## Syntax (C#)
```csharp
public IList<TableCellCombinedParameterData> GetCellCombinedParameters(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`)
- **nCol** (`System.Int32`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.

