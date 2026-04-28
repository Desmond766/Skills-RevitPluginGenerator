---
kind: method
id: M:Autodesk.Revit.DB.ElementPhaseStatusFilter.#ctor(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementOnPhaseStatus,System.Boolean)
source: html/5f0a0056-7ecb-372c-4c7b-7543e682aec4.htm
---
# Autodesk.Revit.DB.ElementPhaseStatusFilter.#ctor Method

Constructs a new instance of a file to match elements that have a given phase status on the input phase, with the option
 to match all elements that have a phase status other than the input status.

## Syntax (C#)
```csharp
public ElementPhaseStatusFilter(
	ElementId phaseId,
	ElementOnPhaseStatus phaseStatus,
	bool inverted
)
```

## Parameters
- **phaseId** (`Autodesk.Revit.DB.ElementId`) - Id of the phase.
- **phaseStatus** (`Autodesk.Revit.DB.ElementOnPhaseStatus`) - Target status.
- **inverted** (`System.Boolean`) - True to match all phase statuses other than the input status.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

