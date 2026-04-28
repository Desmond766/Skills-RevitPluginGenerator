---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.ClearCell(System.Int32,System.Int32)
source: html/2a3ab596-60fc-77b3-a459-380efef3dc12.htm
---
# Autodesk.Revit.DB.TableSectionData.ClearCell Method

Deletes text or image, or removes parameter of this cell.

## Syntax (C#)
```csharp
public void ClearCell(
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
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is forbidden for cells in standard schedule body sections.

