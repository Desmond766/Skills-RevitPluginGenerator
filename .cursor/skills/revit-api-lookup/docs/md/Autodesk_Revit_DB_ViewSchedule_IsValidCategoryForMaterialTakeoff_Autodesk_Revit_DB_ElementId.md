---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.IsValidCategoryForMaterialTakeoff(Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/e2bb583d-f2e1-30af-4713-9a0edcc3cece.htm
---
# Autodesk.Revit.DB.ViewSchedule.IsValidCategoryForMaterialTakeoff Method

**中文**: 明细表

Checks whether a category can be used for a material takeoff.

## Syntax (C#)
```csharp
public static bool IsValidCategoryForMaterialTakeoff(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category ID to check.

## Returns
True if the category can be used for a material takeoff,
 false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

