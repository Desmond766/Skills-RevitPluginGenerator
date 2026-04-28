---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetCellFormatOptions(System.Int32,System.Int32,Autodesk.Revit.DB.FormatOptions)
source: html/12c775d7-bdc3-6530-308d-8bac54ce6fcb.htm
---
# Autodesk.Revit.DB.TableSectionData.SetCellFormatOptions Method

Sets a cell's FormatOptions.

## Syntax (C#)
```csharp
public void SetCellFormatOptions(
	int nRow,
	int nCol,
	FormatOptions options
)
```

## Parameters
- **nRow** (`System.Int32`) - The row index of the cell
- **nCol** (`System.Int32`) - The column index of the cell
- **options** (`Autodesk.Revit.DB.FormatOptions`) - The format option to assign

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.
 -or-
 The display unit in options is not a valid display unit for the unit type of the cell, or the rounding method in options is not set to Nearest. See UnitUtils.IsValidDisplayUnit(UnitType, DisplayUnitType), UnitUtils.GetValidDisplayUnits(UnitType) and FormatOptions.RoundingMethod.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

