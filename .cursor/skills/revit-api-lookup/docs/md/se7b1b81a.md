---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetCellSpec(System.Int32,System.Int32)
source: html/7c7faf47-ba51-d7a4-5ed4-ebe0ae6ebe3b.htm
---
# Autodesk.Revit.DB.TableSectionData.GetCellSpec Method

Gets the spec describing values of a cell, if applicable.

## Syntax (C#)
```csharp
public ForgeTypeId GetCellSpec(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - The row index of the cell
- **nCol** (`System.Int32`) - The column index of the cell

## Returns
Identifier of the spec, or empty if the cell does not contain a number with units.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.

