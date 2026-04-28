---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.RestoreImageSize
zh: 明细表
source: html/e9c47953-6070-46ac-5d24-cef0a9cd5b51.htm
---
# Autodesk.Revit.DB.ViewSchedule.RestoreImageSize Method

**中文**: 明细表

Restores all images to their original sizes.

## Syntax (C#)
```csharp
public void RestoreImageSize()
```

## Remarks
All images in the schedule will be restored to their original sizes when viewed as a ScheduleSheetInstance on a ViewSheet.
 This reverts any changes made by setting RowHeight . Calling this method has no effect if HasImageField is false. In the schedule view the column widths will be adjusted to match the image sizes, but only the name of the image will be shown.
 For example, the users can attach different images to the kinds of rebar instances. These images may have different sizes.
 When the users create the rebar schedule with this image field, by default the column width of this image field is equal to other fields,
 which means it is not associated with the image original sizes during the schedule creation.

