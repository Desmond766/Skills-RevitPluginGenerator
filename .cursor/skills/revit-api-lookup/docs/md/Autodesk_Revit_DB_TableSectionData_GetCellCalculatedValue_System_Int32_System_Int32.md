---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetCellCalculatedValue(System.Int32,System.Int32)
source: html/639a0d4c-96ea-3b73-570e-456e84fa30fc.htm
---
# Autodesk.Revit.DB.TableSectionData.GetCellCalculatedValue Method

Gets the calculated value for the specified cell

## Syntax (C#)
```csharp
public TableCellCalculatedValueData GetCellCalculatedValue(
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

