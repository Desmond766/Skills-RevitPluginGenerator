---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetCellStyle(System.Int32,Autodesk.Revit.DB.TableCellStyle)
source: html/1da06745-c099-f4e2-8a3d-200bd761e289.htm
---
# Autodesk.Revit.DB.TableSectionData.SetCellStyle Method

Sets a column's style.

## Syntax (C#)
```csharp
public void SetCellStyle(
	int nCol,
	TableCellStyle Style
)
```

## Parameters
- **nCol** (`System.Int32`)
- **Style** (`Autodesk.Revit.DB.TableCellStyle`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given column number nCol is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

