---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsRouteAnalysisEnabled
source: html/1a49f909-b046-97da-57b2-f22b44fa55aa.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsRouteAnalysisEnabled Property

Checks whether or not route analysis is enabled, and enable or disable it.

## Syntax (C#)
```csharp
public bool IsRouteAnalysisEnabled { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The current product type is not ProductType.Revit and discipline controls are not enabled.

