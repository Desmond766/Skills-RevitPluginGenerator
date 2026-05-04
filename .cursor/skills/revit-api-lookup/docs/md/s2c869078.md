---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.DeleteSegment(System.Int32)
zh: 明细表
source: html/39df2299-ba2f-2da0-7524-4ab5150a48ab.htm
---
# Autodesk.Revit.DB.ViewSchedule.DeleteSegment Method

**中文**: 明细表

Deletes a schedule segment.

## Syntax (C#)
```csharp
public void DeleteSegment(
	int segmentIndex
)
```

## Parameters
- **segmentIndex** (`System.Int32`) - Zero-based index of the segment.

## Remarks
If the last segment is deleted, the previous one will be the last one and its height will be modified to unlimited.
 If one segment is deleted when there are only two segments, all the instances will be deleted and the schedule
 will become unsplit again.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The segment index should start from 0 and be less than the total segment count.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This ViewSchedule is not split yet.

