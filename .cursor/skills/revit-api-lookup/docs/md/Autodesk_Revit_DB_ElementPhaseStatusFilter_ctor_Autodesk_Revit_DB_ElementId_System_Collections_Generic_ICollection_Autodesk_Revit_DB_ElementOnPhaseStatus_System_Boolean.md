---
kind: method
id: M:Autodesk.Revit.DB.ElementPhaseStatusFilter.#ctor(Autodesk.Revit.DB.ElementId,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementOnPhaseStatus},System.Boolean)
source: html/83b9c6ff-4eba-9314-ff97-f607a698a374.htm
---
# Autodesk.Revit.DB.ElementPhaseStatusFilter.#ctor Method

Constructs a new instance of a file to match elements that have a given phase statuses on the input phase, with the option
 to match all elements that have a phase status other than the input statuses.

## Syntax (C#)
```csharp
public ElementPhaseStatusFilter(
	ElementId phaseId,
	ICollection<ElementOnPhaseStatus> phaseStatuses,
	bool inverted
)
```

## Parameters
- **phaseId** (`Autodesk.Revit.DB.ElementId`) - Id of the phase.
- **phaseStatuses** (`System.Collections.Generic.ICollection < ElementOnPhaseStatus >`) - Target statuses.
- **inverted** (`System.Boolean`) - True to match all phase statuses other than the input statuses.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

