---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.SetFieldOrder(System.Collections.Generic.IList{Autodesk.Revit.DB.ScheduleFieldId})
source: html/702cfbed-56b5-a060-0f71-adaa6bf51975.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.SetFieldOrder Method

Reorders the fields in the schedule.

## Syntax (C#)
```csharp
public void SetFieldOrder(
	IList<ScheduleFieldId> fieldIds
)
```

## Parameters
- **fieldIds** (`System.Collections.Generic.IList < ScheduleFieldId >`) - The field IDs in a new order.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - fieldIds does not contain exactly the same field IDs as this ScheduleDefinition currently contains.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

