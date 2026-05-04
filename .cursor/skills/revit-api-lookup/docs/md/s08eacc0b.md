---
kind: property
id: P:Autodesk.Revit.DB.Analysis.SystemsAnalysisOptions.WorkflowFile
source: html/f4634304-0c9c-421f-fea4-efa6e1d527a3.htm
---
# Autodesk.Revit.DB.Analysis.SystemsAnalysisOptions.WorkflowFile Property

The file name of the EnergyPlus workflow script.

## Syntax (C#)
```csharp
public string WorkflowFile { get; set; }
```

## Remarks
When requesting a new system analysis, it is okay to have an empty workflowFile in the SystemsAnalysisOption. In that case,
 the ViewSystemsAnalysisReport would supply the weather file with the default value "HVAC Systems Loads and Sizing.osw".

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The analysis requires a valid workflow file.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

