---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsElectricalAnalysisEnabled
source: html/37194fc8-1321-fe6b-3e24-ff42cfc71ced.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsElectricalAnalysisEnabled Property

Checks whether or not electrical analysis is enabled, and enable or disable it.

## Syntax (C#)
```csharp
public bool IsElectricalAnalysisEnabled { get; set; }
```

## Remarks
Enabling electrical analysis will not take effect unless the electrical discipline is also enabled.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The current product type is not ProductType.Revit and discipline controls are not enabled.

