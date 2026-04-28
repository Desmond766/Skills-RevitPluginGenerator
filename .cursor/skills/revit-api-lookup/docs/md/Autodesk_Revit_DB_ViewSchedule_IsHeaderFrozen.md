---
kind: property
id: P:Autodesk.Revit.DB.ViewSchedule.IsHeaderFrozen
zh: 明细表
source: html/f7cef912-84ae-e4cc-94dc-784f4e182874.htm
---
# Autodesk.Revit.DB.ViewSchedule.IsHeaderFrozen Property

**中文**: 明细表

A static property defining if the schedule header frozen setting is turned on or off in current Revit Application Session.

## Syntax (C#)
```csharp
public static bool IsHeaderFrozen { get; set; }
```

## Remarks
The setting will be written into Revit.ini if users set the value.
 If users start multiple Revit sessions, the schedule header frozen setting might be different in each session.
 Revit.ini file stores the lastest setting no matter what the Revit session is.

