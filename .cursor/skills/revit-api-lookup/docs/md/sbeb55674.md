---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleTemplate.IsValidPanelConfiguration(Autodesk.Revit.DB.Electrical.PanelScheduleType,Autodesk.Revit.DB.Electrical.PanelConfiguration)
source: html/d665ea95-a150-8f0b-43bf-6894bb9c0f5d.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleTemplate.IsValidPanelConfiguration Method

Checks if given panel configuration is valid for given panel schedule type.

## Syntax (C#)
```csharp
public static bool IsValidPanelConfiguration(
	PanelScheduleType scheduleType,
	PanelConfiguration configuration
)
```

## Parameters
- **scheduleType** (`Autodesk.Revit.DB.Electrical.PanelScheduleType`) - The panel schedule type.
- **configuration** (`Autodesk.Revit.DB.Electrical.PanelConfiguration`) - The given configuration to check.

## Returns
True if panel schedule template can have a valid configuration assigned, false otherwise.

## Remarks
If the panel schedule type is branch panel, the valid panel configurations are:
 PanelConfiguration::Enum::OneColumn
 PanelConfiguration::Enum::TwoColumnsCircuitsAcross
 PanelConfiguration::Enum::TwoColumnsCircuitsDown
 If the panel schedule type is switchboard or data panel, the valid panel configuration is:
 PanelConfiguration::Enum::OneColumn

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

