---
kind: method
id: M:Autodesk.Revit.DB.Analysis.AnalysisResultSchema.SetUnits(System.Collections.Generic.IList{System.String},System.Collections.Generic.IList{System.Double})
source: html/3d8eb5c1-8154-1211-4308-f33a3dd92ec2.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisResultSchema.SetUnits Method

Sets names and multipliers of all units for result visualization

## Syntax (C#)
```csharp
public void SetUnits(
	IList<string> names,
	IList<double> multipliers
)
```

## Parameters
- **names** (`System.Collections.Generic.IList < String >`) - Unit names for all units (e.g., "Lb" and "Kg")
- **multipliers** (`System.Collections.Generic.IList < Double >`) - Numerical coefficients mapped to unit names.
 They adjust measurement values shown in the legend and display (e.g., 1.0 and 0.451 - if actual measurements are in Lb)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - names is zero-length or contains duplicate or empty names
 -or-
 multipliers contains non-positive numbers, or its length is not equal to the length of names

