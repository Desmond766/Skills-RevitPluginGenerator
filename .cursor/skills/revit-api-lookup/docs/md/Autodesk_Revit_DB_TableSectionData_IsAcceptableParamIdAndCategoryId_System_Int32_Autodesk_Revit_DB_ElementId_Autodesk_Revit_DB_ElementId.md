---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.IsAcceptableParamIdAndCategoryId(System.Int32,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/be1c8560-08d2-fb73-da5c-3eca8fc65783.htm
---
# Autodesk.Revit.DB.TableSectionData.IsAcceptableParamIdAndCategoryId Method

Identifies if the given parameter id and category id can be assigned to a cell in the given row in this table.

## Syntax (C#)
```csharp
public bool IsAcceptableParamIdAndCategoryId(
	int nRow,
	ElementId paramId,
	ElementId categoryId
)
```

## Parameters
- **nRow** (`System.Int32`) - row index
- **paramId** (`Autodesk.Revit.DB.ElementId`)
- **categoryId** (`Autodesk.Revit.DB.ElementId`)

## Returns
True if the ParamId and CategoryId are all valid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

