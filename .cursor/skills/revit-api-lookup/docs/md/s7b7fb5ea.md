---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.SetSegmentHeight(System.Int32,System.Double)
zh: 明细表
source: html/a1f5c540-42a8-a236-7b97-dbf027a7c5d7.htm
---
# Autodesk.Revit.DB.ViewSchedule.SetSegmentHeight Method

**中文**: 明细表

Sets the segment height.

## Syntax (C#)
```csharp
public void SetSegmentHeight(
	int segmentIndex,
	double height
)
```

## Parameters
- **segmentIndex** (`System.Int32`) - Index of the segment.
- **height** (`System.Double`) - New height for the segment.

## Remarks
The height is Revit's internal units value of schedule header and segment body.
 The last segment can not set height. Its height will be determined by whole schedule height and other segments' heights.
 The height will not be the exact segment height on sheet. It will be the border height of the instance. The real height
 will be determined by the segment content. If the row cannot be shown within the instance boder, it will flow to the next segment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - segmentIndex must be between 0 and the last second of all segments.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for height must be greater than 0 and no more than 30000 feet.

