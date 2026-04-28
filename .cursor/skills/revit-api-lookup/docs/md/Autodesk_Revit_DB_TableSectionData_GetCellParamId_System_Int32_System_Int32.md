---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetCellParamId(System.Int32,System.Int32)
source: html/37c92801-ee18-7bd8-067b-e53ba87da947.htm
---
# Autodesk.Revit.DB.TableSectionData.GetCellParamId Method

Returns a cell's ParamId and if no ParamId exists for this cell,
 it would come from the column

## Syntax (C#)
```csharp
public ElementId GetCellParamId(
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

