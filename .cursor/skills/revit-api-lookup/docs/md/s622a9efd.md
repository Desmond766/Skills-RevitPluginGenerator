---
kind: type
id: T:Autodesk.Revit.DB.ScheduleDefinition
source: html/420696e3-f3ec-1a1d-1205-36a8119d81e5.htm
---
# Autodesk.Revit.DB.ScheduleDefinition

Settings that define the contents of a schedule.

## Syntax (C#)
```csharp
public class ScheduleDefinition : IDisposable
```

## Remarks
The ScheduleDefinition class contains various settings that
 define the contents of a schedule view, including: The schedule's category and other basic properties that determine the type of schedule. A set of fields that become the columns of the schedule. Filters that restrict the set of elements visible in the schedule. Sorting and grouping criteria. Most schedules contain a single ScheduleDefinition. In Revit MEP,
 schedules of certain categories can contain an "embedded schedule" containing
 elements associated with the elements in the primary schedule, for example a
 room schedule showing the elements inside each room or a duct system schedule
 showing the elements associated with each system. An embedded schedule has
 its own category, fields, filters, etc. Those settings are stored in a
 second ScheduleDefinition object.

