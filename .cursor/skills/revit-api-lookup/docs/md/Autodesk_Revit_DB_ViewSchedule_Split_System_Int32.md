---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.Split(System.Int32)
zh: 拆分、打断、分割
source: html/336fbd5a-0b10-9a6f-37fa-85763ad8f0fa.htm
---
# Autodesk.Revit.DB.ViewSchedule.Split Method

**中文**: 拆分、打断、分割

Splits the schedule into several segments by given segment number.

## Syntax (C#)
```csharp
public void Split(
	int segmentNumber
)
```

## Parameters
- **segmentNumber** (`System.Int32`) - The segment number.

## Remarks
The segment number must be greater than 0. A schedule can be split only when it is not split yet. A titleblock revision schedule cannot be split. Once a sheet specific schedule, i.e., the schedule is filtered by sheet, is split,
 the segments will be placed on its sheet view immediately. After split, all segments will have even height limits based on the schedule height and segment number
 except the last segment shown on the sheet view. The height limit of the last segment cannot be set, because the height of the schedule
 instances of the last segment will be determined by the schedule instances of previous
 segments and the height of the whole schedule. Check SetSegmentHeight(Int32, Double) to see more about segment height.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The segment number must be greater than 1.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Revision schedules cannot be split.
 -or-
 A schedule filtered by sheet can't be split.
 -or-
 This ViewSchedule is split.

