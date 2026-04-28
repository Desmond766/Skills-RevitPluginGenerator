---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsPipingAnalysisEnabled
source: html/2f926f7e-f816-6933-a125-53c856a25d8c.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsPipingAnalysisEnabled Property

Checks whether or not piping analysis is enabled, and enable or disable it.

## Syntax (C#)
```csharp
public bool IsPipingAnalysisEnabled { get; set; }
```

## Remarks
Enabling piping analysis will not take effect unless the piping discipline is also enabled.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The current product type is not ProductType.Revit and discipline controls are not enabled.

