---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.Split(System.Collections.Generic.IList{System.Double})
zh: 拆分、打断、分割
source: html/c3f8f4e7-8430-f471-3a82-39e5c8f36bb8.htm
---
# Autodesk.Revit.DB.ViewSchedule.Split Method

**中文**: 拆分、打断、分割

Splits the schedule into several segments by given height of each segment.

## Syntax (C#)
```csharp
public void Split(
	IList<double> segmentHeights
)
```

## Parameters
- **segmentHeights** (`System.Collections.Generic.IList < Double >`) - An array contains the height limit of each segment except the last segment.
 The height is the value for segment body.
 The height is Revit's internal units value.

## Remarks
A schedule can be split only when it is not split yet. A titleblock revision schedule cannot be split. Once a sheet specific schedule, i.e., the schedule is filtered by sheet, is split,
 the segments will be placed on its sheet view immediately. The height values are used to set the height limits of the schedule instances of each segment
 except the last segment shown on the sheet view. The height limit of the last segment cannot be set, because the height of the schedule instances of the last segment
 will be determined by the schedule instances of previous segments and the height of the whole schedule. All height values must be greater than 0. Also check [!:setSegmentHeight] .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The height of a schedule segment must be greater than 0 and no more than 30000 feet. The total segment count must be greater than 0 and less than 10000.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Revision schedules cannot be split.
 -or-
 A schedule filtered by sheet can't be split.
 -or-
 This ViewSchedule is split.

