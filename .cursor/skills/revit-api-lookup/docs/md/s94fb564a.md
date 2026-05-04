---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetCellType(System.Int32)
source: html/ee8324d4-ec1b-c905-d596-3f731b48622e.htm
---
# Autodesk.Revit.DB.TableSectionData.GetCellType Method

Returns a column's cell type and if no type exists for this column,
 it would come from the section

## Syntax (C#)
```csharp
public CellType GetCellType(
	int nCol
)
```

## Parameters
- **nCol** (`System.Int32`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given column number nCol is invalid.

