---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckProjectPhase(Autodesk.Revit.DB.ElementId)
source: html/c6ab5f88-0895-3812-8d3e-89b6fd1103fa.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckProjectPhase Method

Checks that the input element is a project phase.

## Syntax (C#)
```csharp
public bool CheckProjectPhase(
	ElementId projectPhaseId
)
```

## Parameters
- **projectPhaseId** (`Autodesk.Revit.DB.ElementId`) - The element to be checked.

## Returns
True if the input element is a project phase, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

