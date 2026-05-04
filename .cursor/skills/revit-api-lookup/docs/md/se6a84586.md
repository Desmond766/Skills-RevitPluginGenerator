---
kind: property
id: P:Autodesk.Revit.DB.ViewSchedule.KeyScheduleParameterName
zh: 明细表
source: html/c6fce00e-ec7c-dccb-7dcc-7297ab6368a9.htm
---
# Autodesk.Revit.DB.ViewSchedule.KeyScheduleParameterName Property

**中文**: 明细表

In a key schedule, the name of the parameter for choosing one of the keys.

## Syntax (C#)
```csharp
public string KeyScheduleParameterName { get; set; }
```

## Remarks
When a key schedule is created, elements of the schedule's category
 receive a new parameter for choosing one of the keys defined in the key schedule.
 This is the name of that parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This ViewSchedule is not key schedule.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - When setting this property: The document containing this ViewSchedule is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 When setting this property: The document containing this ViewSchedule is being loaded, or is in the midst of another
 sensitive process.
 -or-
 When setting this property: This ViewSchedule is an internal element, such as a component of a
 loaded family or a group type.
 -or-
 When setting this property: The document containing this ViewSchedule is in Group Edit Mode,
 Sketch Edit Mode, or Paste Mode, and the element is not a
 member of the group, sketch, or clipboard.
 -or-
 When setting this property: This ViewSchedule is a member of a group or sketch, and the document
 is not currently editing the group or sketch.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - When setting this property: The document containing this ViewSchedule has no open transaction.

