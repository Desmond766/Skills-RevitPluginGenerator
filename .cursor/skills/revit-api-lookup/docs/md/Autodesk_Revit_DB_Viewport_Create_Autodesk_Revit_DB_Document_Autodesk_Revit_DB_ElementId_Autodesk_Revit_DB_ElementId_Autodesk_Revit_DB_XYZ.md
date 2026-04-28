---
kind: method
id: M:Autodesk.Revit.DB.Viewport.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/0f951f28-eb6b-2a37-668a-b248bfb7de97.htm
---
# Autodesk.Revit.DB.Viewport.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new Viewport at a given location on a sheet.

## Syntax (C#)
```csharp
public static Viewport Create(
	Document document,
	ElementId viewSheetId,
	ElementId viewId,
	XYZ point
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new Viewport will be added.
- **viewSheetId** (`Autodesk.Revit.DB.ElementId`) - The ViewSheet on which the new Viewport will be placed.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view shown in the Viewport.
- **point** (`Autodesk.Revit.DB.XYZ`) - The new Viewport will be centered on this point.

## Returns
The new Viewport.

## Remarks
Use [!:Autodesk::Revit::DB::ScheduleSheetInstance::Create()] to add schedules to sheets.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - viewSheetId is not a ViewSheet.
 -or-
 viewId cannot be added to the ViewSheet.
 -or-
 Plan view creation is not allowed in this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - This method may not be called during dynamic update.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

