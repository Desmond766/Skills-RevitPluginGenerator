---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.IsAcceptableParamIdAndCategoryId(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/67848d71-0ed1-63f3-da2d-1ecf6fa900e1.htm
---
# Autodesk.Revit.DB.TableSectionData.IsAcceptableParamIdAndCategoryId Method

Identifies if the given parameter id and category id can be assigned to a cell in this table.

## Syntax (C#)
```csharp
public bool IsAcceptableParamIdAndCategoryId(
	ElementId paramId,
	ElementId categoryId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`)
- **categoryId** (`Autodesk.Revit.DB.ElementId`)

## Returns
True if the ParamId and CategoryId are all acceptable.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

