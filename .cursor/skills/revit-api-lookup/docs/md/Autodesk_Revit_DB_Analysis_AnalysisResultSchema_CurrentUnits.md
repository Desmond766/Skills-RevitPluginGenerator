---
kind: property
id: P:Autodesk.Revit.DB.Analysis.AnalysisResultSchema.CurrentUnits
source: html/586633c6-5875-915f-7d26-2580069e1504.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisResultSchema.CurrentUnits Property

Stores the index in the array of applicable units

## Syntax (C#)
```csharp
public int CurrentUnits { get; set; }
```

## Remarks
Must be between 0 and (number of applicable units - 1)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: currentUnits is not in the range from 0 to (number of applicable units - 1)

