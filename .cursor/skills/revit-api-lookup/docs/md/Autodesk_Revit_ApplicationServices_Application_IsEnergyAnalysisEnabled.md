---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsEnergyAnalysisEnabled
source: html/04772251-1e06-a50b-d487-60c56d6071bf.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsEnergyAnalysisEnabled Property

Checks whether or not energy analysis is enabled, and enable or disable it.

## Syntax (C#)
```csharp
public bool IsEnergyAnalysisEnabled { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The current product type is not ProductType.Revit and discipline controls are not enabled.

