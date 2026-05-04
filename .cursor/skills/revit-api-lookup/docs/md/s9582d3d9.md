---
kind: method
id: M:Autodesk.Revit.DB.ElementPhaseStatusFilter.#ctor(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementOnPhaseStatus)
source: html/289d18b3-49be-82f4-dc08-01957ba168e3.htm
---
# Autodesk.Revit.DB.ElementPhaseStatusFilter.#ctor Method

Constructs a new instance of a file to match elements that have a given phase status on the input phase.

## Syntax (C#)
```csharp
public ElementPhaseStatusFilter(
	ElementId phaseId,
	ElementOnPhaseStatus phaseStatus
)
```

## Parameters
- **phaseId** (`Autodesk.Revit.DB.ElementId`) - Id of the phase.
- **phaseStatus** (`Autodesk.Revit.DB.ElementOnPhaseStatus`) - Target status.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

