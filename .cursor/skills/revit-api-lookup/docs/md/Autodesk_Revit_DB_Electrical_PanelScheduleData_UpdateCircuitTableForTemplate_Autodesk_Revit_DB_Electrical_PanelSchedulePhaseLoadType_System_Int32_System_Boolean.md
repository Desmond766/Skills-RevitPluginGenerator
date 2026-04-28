---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleData.UpdateCircuitTableForTemplate(Autodesk.Revit.DB.Electrical.PanelSchedulePhaseLoadType,System.Int32,System.Boolean)
source: html/9453a173-c467-0c49-9c1e-a5f413d95dec.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleData.UpdateCircuitTableForTemplate Method

Redraw the circuit table for a template with the given parameter updates

## Syntax (C#)
```csharp
public void UpdateCircuitTableForTemplate(
	PanelSchedulePhaseLoadType newType,
	int nNumSlots,
	bool bPhasesAsCurrents
)
```

## Parameters
- **newType** (`Autodesk.Revit.DB.Electrical.PanelSchedulePhaseLoadType`) - The new phase load type of the circuit table
- **nNumSlots** (`System.Int32`) - The number of circuit slots
- **bPhasesAsCurrents** (`System.Boolean`) - True if the phase columns should be currents, false if they should be loads

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

