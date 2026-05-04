---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetCellParamIdAndCategoryId(System.Int32,System.Int32,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/79baf023-e8b6-dfc2-d598-7d5eb434260a.htm
---
# Autodesk.Revit.DB.TableSectionData.SetCellParamIdAndCategoryId Method

Sets a cell's category and parameter Id

## Syntax (C#)
```csharp
public void SetCellParamIdAndCategoryId(
	int nRow,
	int nCol,
	ElementId paramId,
	ElementId categoryId
)
```

## Parameters
- **nRow** (`System.Int32`)
- **nCol** (`System.Int32`)
- **paramId** (`Autodesk.Revit.DB.ElementId`)
- **categoryId** (`Autodesk.Revit.DB.ElementId`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.
 -or-
 The paramId or categoryId is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

