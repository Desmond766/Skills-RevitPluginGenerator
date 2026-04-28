---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetCellCategoryId(System.Int32)
source: html/5af5678f-9f6f-a135-b5c1-1448bdd17f7b.htm
---
# Autodesk.Revit.DB.TableSectionData.GetCellCategoryId Method

Returns a column's ParamId
 Associated with the paramId to find the correct element

## Syntax (C#)
```csharp
public ElementId GetCellCategoryId(
	int nCol
)
```

## Parameters
- **nCol** (`System.Int32`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given column number nCol is invalid.

