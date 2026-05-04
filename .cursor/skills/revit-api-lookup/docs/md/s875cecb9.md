---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsInfrastructureEnabled
source: html/e283ad12-34e2-0853-6a0b-433eed9eacdf.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsInfrastructureEnabled Property

Checks whether or not infrastructure discipline is enabled, and enable or disable it.

## Syntax (C#)
```csharp
public bool IsInfrastructureEnabled { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The current product type is not ProductType.Revit and discipline controls are not enabled.

