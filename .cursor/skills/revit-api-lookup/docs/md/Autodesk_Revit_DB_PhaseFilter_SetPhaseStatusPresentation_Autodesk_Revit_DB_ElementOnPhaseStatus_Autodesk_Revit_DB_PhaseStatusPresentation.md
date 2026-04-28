---
kind: method
id: M:Autodesk.Revit.DB.PhaseFilter.SetPhaseStatusPresentation(Autodesk.Revit.DB.ElementOnPhaseStatus,Autodesk.Revit.DB.PhaseStatusPresentation)
source: html/a0554313-bda4-9036-0320-2d9294c2bde6.htm
---
# Autodesk.Revit.DB.PhaseFilter.SetPhaseStatusPresentation Method

Sets the phase status presentation.

## Syntax (C#)
```csharp
public void SetPhaseStatusPresentation(
	ElementOnPhaseStatus status,
	PhaseStatusPresentation presentation
)
```

## Parameters
- **status** (`Autodesk.Revit.DB.ElementOnPhaseStatus`) - The element phase status.
- **presentation** (`Autodesk.Revit.DB.PhaseStatusPresentation`) - The phase status presentation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - status is invalid for presentation query.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

