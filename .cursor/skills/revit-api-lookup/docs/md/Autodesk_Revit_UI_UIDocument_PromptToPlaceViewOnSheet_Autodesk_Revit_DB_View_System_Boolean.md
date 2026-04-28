---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.PromptToPlaceViewOnSheet(Autodesk.Revit.DB.View,System.Boolean)
source: html/32a59cc7-1e27-35b4-2dc3-2892f14dd760.htm
---
# Autodesk.Revit.UI.UIDocument.PromptToPlaceViewOnSheet Method

Prompts the user to place a specified view onto a sheet.

## Syntax (C#)
```csharp
public void PromptToPlaceViewOnSheet(
	View view,
	bool allowReplaceExistingSheetViewport
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view to insert onto a sheet.
- **allowReplaceExistingSheetViewport** (`System.Boolean`) - A indicator which allows the user to replace the existing viewport.
 If true, the viewport representing this view will be replaced by the new viewport created during placement.
 If the view is allowed only to be on one sheet, this will remove the viewport from the old sheet.
 If the view is allowed to be on multiple sheets, and the view is currently placed on the active sheet,
 the old viewport on this sheet will be replaced. 
 If false, if the view is only allowed to be on one sheet,
 or if the view is allowed to be on multiple sheets but is already on the active sheet, an exception will be thrown.

## Remarks
This method opens its own transaction, so it's not permitted to be invoked in an active transaction.
 In a single invocation, the user can place only one view onto the active sheet. The user is not permitted to change the active sheet view or the view to be placed
 during this placement operation (the operation will be cancelled). The user can cancel the placement operation by pressing Cancel or ESC or a click elsewhere in the UI. This method can't be used to place a schedule on a sheet.
 Use ScheduleSheetInstance Create() to add schedules to sheets.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This view is a view template.
 -or-
 view is a schedule.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This document is not the currently active one.
 -or-
 Starting a new transaction is not permitted. It could be because
 another transaction already started and has not been completed yet,
 or the document is in a state in which it cannot start a new transaction.
 -or-
 The active view isn't a sheet where a view can be placed.
 -or-
 The view can't be placed on the sheet. For schedule views use ScheduleSheetInstance::Create() to place them on sheets.
 -or-
 Thrown when replacing an existing viewport isn't allowed. See allowReplaceExistingSheetViewport parameter documentation for details.

