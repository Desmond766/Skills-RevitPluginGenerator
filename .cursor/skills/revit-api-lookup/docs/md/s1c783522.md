---
kind: property
id: P:Autodesk.Revit.DB.ViewSchedule.ImageRowHeight
zh: 明细表
source: html/e3ef7e6f-1ad0-c3f9-386b-8bc2cdac5df8.htm
---
# Autodesk.Revit.DB.ViewSchedule.ImageRowHeight Property

**中文**: 明细表

Defines the image row height in the schedule.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This property is deprecated in Revit 2024 and my be removed in a later version of Revit. We suggest you use the 'RowHeight' property instead.")]
public double ImageRowHeight { get; set; }
```

## Remarks
If there is at least one image field in the schedule, then setting this property will force all rows containing images to be
 resized to the indicated height value (when viewed as a ScheduleSheetInstance on a ViewSheet). Setting this property will have
 no effect if HasImageField returns false. This height will be maintained until the user or application restores the original image sizes (in API: RestoreImageSize () () () ).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for imageRowHeight must be greater than 0 and no more than 30000 feet.

