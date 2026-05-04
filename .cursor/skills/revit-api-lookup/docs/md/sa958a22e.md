---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetCellCalculatedValue(System.Int32,Autodesk.Revit.DB.TableCellCalculatedValueData)
source: html/09390cf2-1109-aca6-d67e-24be3e74bc46.htm
---
# Autodesk.Revit.DB.TableSectionData.SetCellCalculatedValue Method

Allows the caller to set the calculated value for a specified column

## Syntax (C#)
```csharp
public void SetCellCalculatedValue(
	int nCol,
	TableCellCalculatedValueData pCalcValue
)
```

## Parameters
- **nCol** (`System.Int32`)
- **pCalcValue** (`Autodesk.Revit.DB.TableCellCalculatedValueData`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given column number nCol is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is forbidden for cells in standard schedule header sections.
 -or-
 This operation is forbidden for cells in standard schedule body sections.

