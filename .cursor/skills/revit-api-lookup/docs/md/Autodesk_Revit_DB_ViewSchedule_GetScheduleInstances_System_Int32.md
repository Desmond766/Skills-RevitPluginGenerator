---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetScheduleInstances(System.Int32)
zh: 明细表
source: html/58b62eb9-893a-56d3-f689-c7837a50ab02.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetScheduleInstances Method

**中文**: 明细表

Gets the instances ids of schedule or schedule segment.

## Syntax (C#)
```csharp
public IList<ElementId> GetScheduleInstances(
	int segmentIndex
)
```

## Parameters
- **segmentIndex** (`System.Int32`) - Index of the segment.

## Returns
The array of schedule sheet instance element ids of schedule or schedule segment.

## Remarks
The segment index value could be -1, it means to get schedule instances for the entire schedule.
When a (primary) schedule is set to filter by sheet and placed on a sheet, it will create a new schedule with elements visible
 in the Viewport(s) on that sheet. The instance created belongs to the newly created schedule. Calls to GetScheduleInstances()
 will return instances of the newly created schedule but no instances of the primary schedule.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The segment index should start from -1 and be less than the total segment count.

