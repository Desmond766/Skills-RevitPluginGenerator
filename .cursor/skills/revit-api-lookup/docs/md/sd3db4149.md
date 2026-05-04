---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.IsValidCategoryForKeySchedule(Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/c74a52c2-0daf-2c3c-0097-f71a9f802dd0.htm
---
# Autodesk.Revit.DB.ViewSchedule.IsValidCategoryForKeySchedule Method

**中文**: 明细表

Checks whether a category can be used for a key schedule.

## Syntax (C#)
```csharp
public static bool IsValidCategoryForKeySchedule(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category ID to check.

## Returns
True if the category can be used for a key schedule,
 false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

