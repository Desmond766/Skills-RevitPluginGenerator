---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetCellCombinedParameters(System.Int32,System.Collections.Generic.IList{Autodesk.Revit.DB.TableCellCombinedParameterData})
source: html/f4eb5c89-5ee7-0333-c23e-bd185e8809fd.htm
---
# Autodesk.Revit.DB.TableSectionData.SetCellCombinedParameters Method

Allows the caller to set combined parameter for a specified column

## Syntax (C#)
```csharp
public void SetCellCombinedParameters(
	int nCol,
	IList<TableCellCombinedParameterData> paramData
)
```

## Parameters
- **nCol** (`System.Int32`)
- **paramData** (`System.Collections.Generic.IList < TableCellCombinedParameterData >`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given column number nCol is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

