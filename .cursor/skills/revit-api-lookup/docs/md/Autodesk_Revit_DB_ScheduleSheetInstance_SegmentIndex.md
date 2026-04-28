---
kind: property
id: P:Autodesk.Revit.DB.ScheduleSheetInstance.SegmentIndex
source: html/69ecefc6-2bc3-d1b1-0777-b6ada9c4f789.htm
---
# Autodesk.Revit.DB.ScheduleSheetInstance.SegmentIndex Property

The schedule segment index of this ScheduleSheetInstance.

## Syntax (C#)
```csharp
public int SegmentIndex { get; set; }
```

## Remarks
This property represents which schedule segment is referred to by this ScheduleSheetInstance. It normally starts with 0 and
 is less than the total number of the schedule segments, but there're some speccial cases:
 The segment index value could be -1, which means referring to the whole schedule but not a specific segment. The segment index value 0 should be considered the same as -1 if the referenced schedule is not split in normal cases. The segment index value must be 0 if the schedule is a revision schedule and in a family. The segment index value can't be modified if the schedule is filter by sheet. (In fact, The segment
 is referenced to is belongs to an internal schedule that only valid in the current view in this case.)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: segmentIndex is not a valid segment index.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The schedule of this ScheduleSheetInstance is a titleblock revision schedule or a sheet specific schedule.

