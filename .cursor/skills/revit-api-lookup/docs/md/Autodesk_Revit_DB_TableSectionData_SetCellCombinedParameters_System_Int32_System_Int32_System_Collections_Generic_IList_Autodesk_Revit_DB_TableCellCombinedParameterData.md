---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetCellCombinedParameters(System.Int32,System.Int32,System.Collections.Generic.IList{Autodesk.Revit.DB.TableCellCombinedParameterData})
source: html/0c716bc6-c6ba-66b5-f23e-b15141dc739e.htm
---
# Autodesk.Revit.DB.TableSectionData.SetCellCombinedParameters Method

Allows the caller to set combined parameter for a specified cell

## Syntax (C#)
```csharp
public void SetCellCombinedParameters(
	int nRow,
	int nCol,
	IList<TableCellCombinedParameterData> paramData
)
```

## Parameters
- **nRow** (`System.Int32`)
- **nCol** (`System.Int32`)
- **paramData** (`System.Collections.Generic.IList < TableCellCombinedParameterData >`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

