---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.IsValidCategoryForSchedule(Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/6998c7b9-a44d-9b8e-839e-fb1d23ae26d1.htm
---
# Autodesk.Revit.DB.ViewSchedule.IsValidCategoryForSchedule Method

**中文**: 明细表

Checks whether a category can be used for a regular schedule.

## Syntax (C#)
```csharp
public static bool IsValidCategoryForSchedule(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category ID to check.

## Returns
True if the category can be used for a regular schedule,
 false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

