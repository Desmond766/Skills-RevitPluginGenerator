---
kind: method
id: M:Autodesk.Revit.DB.ElementPhaseStatusFilter.#ctor(Autodesk.Revit.DB.ElementId,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementOnPhaseStatus})
source: html/652f47dc-bce8-b3f2-9033-0fef14565fbb.htm
---
# Autodesk.Revit.DB.ElementPhaseStatusFilter.#ctor Method

Constructs a new instance of a file to match elements that have a given phase statuses on the input phase.

## Syntax (C#)
```csharp
public ElementPhaseStatusFilter(
	ElementId phaseId,
	ICollection<ElementOnPhaseStatus> phaseStatuses
)
```

## Parameters
- **phaseId** (`Autodesk.Revit.DB.ElementId`) - Id of the phase.
- **phaseStatuses** (`System.Collections.Generic.ICollection < ElementOnPhaseStatus >`) - Target statuses.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

