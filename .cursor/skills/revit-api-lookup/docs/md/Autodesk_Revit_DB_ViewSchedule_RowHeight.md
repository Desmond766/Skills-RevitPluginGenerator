---
kind: property
id: P:Autodesk.Revit.DB.ViewSchedule.RowHeight
zh: 明细表
source: html/aca396e1-2fec-666c-005d-7e36d5153999.htm
---
# Autodesk.Revit.DB.ViewSchedule.RowHeight Property

**中文**: 明细表

Defines the schedule body rows height.

## Syntax (C#)
```csharp
public double RowHeight { get; set; }
```

## Remarks
Setting this property will force all or image only (depending on how RowHeightOverride is defined) schedule body rows to be resized to the indicated height value (when viewed as a ScheduleSheetInstance on a ViewSheet).
 If the value that is set is smaller than the height of the text (single or multi line), then that value is not taken into account.
 To access or set this property the RowHeightOverride property should not be None

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for rowHeight must be between 0 and 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The RowHeightOverride property is set to RowHeightOverrideOptions.None.

