---
kind: property
id: P:Autodesk.Revit.DB.ScheduleField.MultipleValuesDisplayType
source: html/64592725-4f20-d2a0-010d-220a9315ff39.htm
---
# Autodesk.Revit.DB.ScheduleField.MultipleValuesDisplayType Property

Determines the type of multiple value indication to be used
 when the schedule field displays multiple element values.

## Syntax (C#)
```csharp
public ScheduleFieldMultipleValuesDisplayType MultipleValuesDisplayType { get; set; }
```

## Remarks
The default display type is Project ,
 indicating that the project [!:Autodesk::Revit::DB::MultipleValuesIndicationSettings::Value] setting will be used.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

