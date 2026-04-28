---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.SplitSegment(System.Int32,System.Collections.Generic.IList{System.Double})
zh: 明细表
source: html/1ff6fd89-a9bc-c51e-e8c8-dc808add5af3.htm
---
# Autodesk.Revit.DB.ViewSchedule.SplitSegment Method

**中文**: 明细表

Splits the schedule segment by the given heights of new segments.

## Syntax (C#)
```csharp
public void SplitSegment(
	int segmentIndex,
	IList<double> segmentHeights
)
```

## Parameters
- **segmentIndex** (`System.Int32`) - The index of segment, starting with 0.
- **segmentHeights** (`System.Collections.Generic.IList < Double >`) - An array contains the height for each new segment except the last segment.
 The height of the last segment will be determined by the height of previous new segments and the height of the split segment.

## Remarks
The height values are used to set the height of schedule instance for each segment shown on sheet view.
 Each input height must be greater than 0 and the total height must be less than the height of the split segment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The height of a schedule segment must be greater than 0. The total height must be less than the split segment height.
 The total segment count must be greater than 0 and less than 10000.
 -or-
 The segment index should start from 0 and be less than the total segment count.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This ViewSchedule is not split yet.

