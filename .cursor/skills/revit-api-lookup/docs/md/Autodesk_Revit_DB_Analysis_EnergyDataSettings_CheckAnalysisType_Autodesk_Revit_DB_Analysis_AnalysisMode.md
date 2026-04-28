---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckAnalysisType(Autodesk.Revit.DB.Analysis.AnalysisMode)
source: html/d0c7a1c6-96aa-482c-9b57-e1b0365b7f66.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckAnalysisType Method

Checks that the analysis type falls within an appropriate range.

## Syntax (C#)
```csharp
public static bool CheckAnalysisType(
	AnalysisMode analysisType
)
```

## Parameters
- **analysisType** (`Autodesk.Revit.DB.Analysis.AnalysisMode`) - The analysis type to be checked.

## Returns
True if the analysis type falls within an appropriate range, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

