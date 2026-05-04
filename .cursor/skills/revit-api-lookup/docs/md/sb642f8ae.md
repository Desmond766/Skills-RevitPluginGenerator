---
kind: property
id: P:Autodesk.Revit.DB.ScheduleDefinition.IncludeLinkedFiles
source: html/d8ad7404-f33b-de75-c76d-395c61cf0c5a.htm
---
# Autodesk.Revit.DB.ScheduleDefinition.IncludeLinkedFiles Property

Indicates if the schedule includes elements from linked files.

## Syntax (C#)
```csharp
public bool IncludeLinkedFiles { get; set; }
```

## Remarks
For an embedded ScheduleDefinition, this setting is controlled
 by the primary ScheduleDefinition and cannot be set in the embedded
 ScheduleDefinition.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This ScheduleDefinition does not support including elements from linked files.
 -or-
 When setting this property: This ScheduleDefinition is an embedded ScheduleDefinition.

