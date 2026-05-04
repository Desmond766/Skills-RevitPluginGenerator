---
kind: property
id: P:Autodesk.Revit.DB.Analysis.SystemsAnalysisOptions.OutputFolder
source: html/d980a989-f63a-17a4-b431-596b8884afb5.htm
---
# Autodesk.Revit.DB.Analysis.SystemsAnalysisOptions.OutputFolder Property

The path of the output folder for systems analysis.

## Syntax (C#)
```csharp
public string OutputFolder { get; set; }
```

## Remarks
When requesting a new system analysis, it is okay to have an empty output folder in the SystemsAnalysisOption. In that case,
 the ViewSystemsAnalysisReport would supply the output folder, typically at the system TEMP folder.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The analysis requires a valid output folder.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

