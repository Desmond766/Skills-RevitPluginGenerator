---
kind: method
id: M:Autodesk.Revit.DB.Family.IsAppropriateCategoryId(Autodesk.Revit.DB.ElementId)
zh: 族
source: html/430baffa-8a85-0745-5c37-72ae41386b74.htm
---
# Autodesk.Revit.DB.Family.IsAppropriateCategoryId Method

**中文**: 族

Identifies if the input category id can be assigned as the new category for this family.

## Syntax (C#)
```csharp
public bool IsAppropriateCategoryId(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category id.

## Returns
True if the input category id can be assigned as the new category for this family, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

