---
kind: method
id: M:Autodesk.Revit.DB.Viewport.CanAddViewToSheet(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/1da33e38-255f-a27a-0626-9891d897b29a.htm
---
# Autodesk.Revit.DB.Viewport.CanAddViewToSheet Method

Verifies that the view can be added to the ViewSheet.

## Syntax (C#)
```csharp
public static bool CanAddViewToSheet(
	Document document,
	ElementId viewSheetId,
	ElementId viewId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the views reside.
- **viewSheetId** (`Autodesk.Revit.DB.ElementId`) - The ViewSheet on which the view will be placed.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view which will be checked to see if it can be placed on the sheet.

## Returns
True if the view can be added to the ViewSheet, false otherwise.

## Remarks
Schedule views are not handled by the Viewport class. Refer to [!:Autodesk::Revit::DB::ScheduleSheetInstance::Create()] for information about adding schedules to sheets.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

