---
kind: type
id: T:Autodesk.Revit.DB.ViewSchedule
zh: 明细表
source: html/0dae24ba-5dcb-9a34-cccc-0cf8cc52bcd3.htm
---
# Autodesk.Revit.DB.ViewSchedule

**中文**: 明细表

A schedule view.

## Syntax (C#)
```csharp
public class ViewSchedule : TableView
```

## Remarks
The ViewSchedule class represents schedules and other schedule-like views,
 including single-category and multi-category schedules, key schedules,
 material takeoffs, view lists, sheet lists, keynote legends, revision schedules,
 and note blocks. The ViewSchedule class is not used for panel schedules
 (see PanelScheduleView) or graphical column schedules. A schedule is a tabular representation of data. A typical
 schedule shows all elements of a category (doors, rooms, etc.)
 with each row representing an element and each column representing a
 parameter. This basic structure can be modified using filters, sorting,
 grouping, totals, formulas, and other features. The ScheduleDefinition class contains most settings that determine
 the contents of a schedule, including category, fields, filters, and sorting. A graphical representation of a schedule can be placed on a sheet
 using the ScheduleSheetInstance class.

