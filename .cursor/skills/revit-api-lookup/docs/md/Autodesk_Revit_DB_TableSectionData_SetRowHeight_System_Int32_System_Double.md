---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetRowHeight(System.Int32,System.Double)
source: html/7639545c-24b0-28ca-48c7-e2a9e50483bf.htm
---
# Autodesk.Revit.DB.TableSectionData.SetRowHeight Method

Sets a row's height in feet

## Syntax (C#)
```csharp
public void SetRowHeight(
	int nRow,
	double height
)
```

## Parameters
- **nRow** (`System.Int32`)
- **height** (`System.Double`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The row height is outside of acceptable range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is forbidden for cells in standard schedule body sections.

