---
kind: method
id: M:Autodesk.Revit.DB.ScheduleSheetInstance.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,System.Int32)
zh: 创建、新建、生成、建立、新增
source: html/fe28901c-f078-2614-ab6a-1d09dfa18729.htm
---
# Autodesk.Revit.DB.ScheduleSheetInstance.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates an instance of a schedule segment on a sheet.

## Syntax (C#)
```csharp
public static ScheduleSheetInstance Create(
	Document document,
	ElementId viewSheetId,
	ElementId scheduleId,
	XYZ origin,
	int segmentIndex
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document
- **viewSheetId** (`Autodesk.Revit.DB.ElementId`) - The id of the sheet where the schedule segment will be placed.
- **scheduleId** (`Autodesk.Revit.DB.ElementId`) - The id of the schedule view.
- **origin** (`Autodesk.Revit.DB.XYZ`) - Location on the sheet where the schedule segment will be placed.
- **segmentIndex** (`System.Int32`) - The schedule segment index of the schedule instance.

## Returns
The new ScheduleInstance.

## Remarks
The segment index value could be -1, which means to create an instance for the entire schedule,
 see SegmentIndex property for more details.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - scheduleId is not a ViewSchedule that can be added to sheets. "Internal" schedules are not user-visible but are filtered by sheet or used to manage Revisions, which cannot be added to sheets.
 -or-
 viewSheetId is not a ViewSheet.
 -or-
 segmentIndex is not a valid segment index.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

