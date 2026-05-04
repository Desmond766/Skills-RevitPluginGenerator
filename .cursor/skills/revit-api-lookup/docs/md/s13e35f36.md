---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetRowHeightInPixels(System.Int32,System.Int32)
source: html/cce5d19c-90a1-020b-3b23-090664508ac0.htm
---
# Autodesk.Revit.DB.TableSectionData.SetRowHeightInPixels Method

This sets a row's height in logical pixels

## Syntax (C#)
```csharp
public void SetRowHeightInPixels(
	int nRow,
	int height
)
```

## Parameters
- **nRow** (`System.Int32`)
- **height** (`System.Int32`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The row height is outside of acceptable range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is forbidden for cells in standard schedule body sections.

