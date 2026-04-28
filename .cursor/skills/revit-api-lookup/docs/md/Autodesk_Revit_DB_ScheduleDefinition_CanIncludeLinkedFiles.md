---
kind: method
id: M:Autodesk.Revit.DB.ScheduleDefinition.CanIncludeLinkedFiles
source: html/357f0b43-1409-0208-fc7c-7088e8c14754.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.CanIncludeLinkedFiles Method

Checks whether the schedule is a type that supports
 including elements from linked files.

## Syntax (C#)
```csharp
public bool CanIncludeLinkedFiles()
```

## Returns
True if elements from linked files can be included, false otherwise.

## Remarks
Elements from linked files can be included in schedules of normal
 model elements and in sheet lists, but not in most other specialized
 kinds of schedules.

