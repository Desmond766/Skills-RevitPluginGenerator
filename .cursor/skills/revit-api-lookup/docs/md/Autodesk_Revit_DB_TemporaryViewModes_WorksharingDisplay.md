---
kind: property
id: P:Autodesk.Revit.DB.TemporaryViewModes.WorksharingDisplay
source: html/86ddd37f-36ef-b63e-559c-ae9a916e89ae.htm
---
# Autodesk.Revit.DB.TemporaryViewModes.WorksharingDisplay Property

The current state of the WorksharingDisplay mode in the associated view.

## Syntax (C#)
```csharp
public WorksharingDisplayMode WorksharingDisplay { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The WorksharingDisplay mode is either disabled or inapplicable in the associated view.

