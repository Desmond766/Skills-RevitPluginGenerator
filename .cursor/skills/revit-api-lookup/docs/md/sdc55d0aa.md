---
kind: method
id: M:Autodesk.Revit.DB.ScheduleSheetInstance.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/8402dc3c-8bdc-40f5-be54-da08bc69d0cd.htm
---
# Autodesk.Revit.DB.ScheduleSheetInstance.Create Method

**中文**: 创建、新建、生成、建立、新增

Create an instance of a schedule on a sheet.

## Syntax (C#)
```csharp
public static ScheduleSheetInstance Create(
	Document document,
	ElementId viewSheetId,
	ElementId scheduleId,
	XYZ origin
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document
- **viewSheetId** (`Autodesk.Revit.DB.ElementId`) - The id of the sheet where the schedule will be placed.
- **scheduleId** (`Autodesk.Revit.DB.ElementId`) - The id of the schedule view.
- **origin** (`Autodesk.Revit.DB.XYZ`) - Location on the sheet where the schedule will be placed.

## Returns
The new ScheduleInstance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - scheduleId is not a ViewSchedule that can be added to sheets. "Internal" schedules are not user-visible but are filtered by sheet or used to manage Revisions, which cannot be added to sheets.
 -or-
 viewSheetId is not a ViewSheet.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

