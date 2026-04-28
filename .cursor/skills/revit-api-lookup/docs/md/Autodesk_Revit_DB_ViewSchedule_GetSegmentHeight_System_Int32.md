---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetSegmentHeight(System.Int32)
zh: 明细表
source: html/7b673a5c-b8d7-d239-0870-6d789aaf4558.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetSegmentHeight Method

**中文**: 明细表

Gets the segment height.

## Syntax (C#)
```csharp
public double GetSegmentHeight(
	int segmentIndex
)
```

## Parameters
- **segmentIndex** (`System.Int32`) - Zero-based index of the segment.

## Returns
The segment height value.

## Remarks
The height is Revit's internal units value of schedule header and segment body.
 The real height of segment on sheet may be less than the segment height get here.
 It is the border height of segment instance on sheet.
 The last segment height get here is the max value of double as the last segment height is not set
 to a fix value. It will be determined by whole schedule height and other segments' heights. And the border for it is max value of double.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The segment index should start from 0 and be less than the total segment count.

