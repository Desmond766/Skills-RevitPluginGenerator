---
kind: method
id: M:Autodesk.Revit.DB.PhaseFilter.GetPhaseStatusPresentation(Autodesk.Revit.DB.ElementOnPhaseStatus)
source: html/6f6bf5a7-eea0-faa5-c35d-8c421388eeea.htm
---
# Autodesk.Revit.DB.PhaseFilter.GetPhaseStatusPresentation Method

Gets the phase status presentation.

## Syntax (C#)
```csharp
public PhaseStatusPresentation GetPhaseStatusPresentation(
	ElementOnPhaseStatus status
)
```

## Parameters
- **status** (`Autodesk.Revit.DB.ElementOnPhaseStatus`) - The element phase status.

## Returns
The phase status presentation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - status is invalid for presentation query.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

