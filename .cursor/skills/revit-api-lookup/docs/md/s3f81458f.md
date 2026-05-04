---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetCellParamIdAndCategoryId(System.Int32,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/16c975b1-6bd4-c30d-03ff-aa9e36a800cb.htm
---
# Autodesk.Revit.DB.TableSectionData.SetCellParamIdAndCategoryId Method

Sets a column's category and parameter Id

## Syntax (C#)
```csharp
public void SetCellParamIdAndCategoryId(
	int nCol,
	ElementId paramId,
	ElementId categoryId
)
```

## Parameters
- **nCol** (`System.Int32`)
- **paramId** (`Autodesk.Revit.DB.ElementId`)
- **categoryId** (`Autodesk.Revit.DB.ElementId`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given column number nCol is invalid.
 -or-
 The paramId or categoryId is not acceptable.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is forbidden for cells in standard schedule body sections.

