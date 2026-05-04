---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.CanFilterByValue(Autodesk.Revit.DB.ScheduleFieldId)
source: html/5732ee93-4f05-7d0f-f566-2de13efec6fd.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.CanFilterByValue Method

Checks whether a field can be used with a value-based filter.

## Syntax (C#)
```csharp
public bool CanFilterByValue(
	ScheduleFieldId fieldId
)
```

## Parameters
- **fieldId** (`Autodesk.Revit.DB.ScheduleFieldId`) - The ID of the field to check.

## Returns
True if the field can be used with a value based filter, false otherwise.

## Remarks
The value-based filter types are Equal, NotEqual,
 GreaterThan, GreaterThanOrEqual, LessThan and LessThanOrEqual. Only certain types of parameters can be filtered by value. Note that some fields (for example, Workset, Family, Type, Family and Type)
 only support Equal, NotEqual, but not GreaterThan, GreaterThanOrEqual, LessThan and LessThanOrEqual.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fieldId is not the ID of a field in this ScheduleDefinition.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

