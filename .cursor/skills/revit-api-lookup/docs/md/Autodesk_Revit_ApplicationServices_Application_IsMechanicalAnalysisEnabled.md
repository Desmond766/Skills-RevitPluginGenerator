---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsMechanicalAnalysisEnabled
source: html/5a3127c7-f77b-5a39-ffa3-e0c0bd960113.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsMechanicalAnalysisEnabled Property

Checks whether or not mechanical analysis is enabled, and enable or disable it.

## Syntax (C#)
```csharp
public bool IsMechanicalAnalysisEnabled { get; set; }
```

## Remarks
Enabling mechanical analysis will not take effect unless the mechanical discipline is also enabled.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The current product type is not ProductType.Revit and discipline controls are not enabled.

