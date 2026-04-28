---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.IsValidCategoryForEmbeddedSchedule(Autodesk.Revit.DB.ElementId)
source: html/b0996b95-7ec3-82fe-91dd-224058266e30.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.IsValidCategoryForEmbeddedSchedule Method

Indicates if a category can be used for an embedded ScheduleDefinition
 in this ScheduleDefinition.

## Syntax (C#)
```csharp
public bool IsValidCategoryForEmbeddedSchedule(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category ID to check.

## Returns
True if the category can be used for an embedded ScheduleDefinition,
 false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

