---
kind: method
id: M:Autodesk.Revit.DB.ScheduleField.CreatesCircularReferences(Autodesk.Revit.DB.ScheduleFieldId)
source: html/51554332-14f6-ea80-7d5a-ad1f8dc76627.htm
---
# Autodesk.Revit.DB.ScheduleField.CreatesCircularReferences Method

Checks whether a field ID would create a circular chain of references
 when used by the PercentageOf property of this field.

## Syntax (C#)
```csharp
public bool CreatesCircularReferences(
	ScheduleFieldId fieldId
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The field ID to check.

## Returns
True if the field ID would create a circular chain of references,
 false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fieldId is not InvalidScheduleFieldId or the ID of a field that can be
 used to calculated percentages.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

