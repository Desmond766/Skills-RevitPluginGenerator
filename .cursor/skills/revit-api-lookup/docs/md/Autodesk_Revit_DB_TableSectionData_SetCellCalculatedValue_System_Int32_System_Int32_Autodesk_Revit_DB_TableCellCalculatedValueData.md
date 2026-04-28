---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetCellCalculatedValue(System.Int32,System.Int32,Autodesk.Revit.DB.TableCellCalculatedValueData)
source: html/95894490-9897-c1aa-fd11-e3802756ead4.htm
---
# Autodesk.Revit.DB.TableSectionData.SetCellCalculatedValue Method

Allows the caller to set the calculated value for a specified cell

## Syntax (C#)
```csharp
public void SetCellCalculatedValue(
	int nRow,
	int nCol,
	TableCellCalculatedValueData pCalcValue
)
```

## Parameters
- **nRow** (`System.Int32`)
- **nCol** (`System.Int32`)
- **pCalcValue** (`Autodesk.Revit.DB.TableCellCalculatedValueData`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is forbidden for cells in standard schedule header sections.
 -or-
 This operation is forbidden for cells in standard schedule body sections.

