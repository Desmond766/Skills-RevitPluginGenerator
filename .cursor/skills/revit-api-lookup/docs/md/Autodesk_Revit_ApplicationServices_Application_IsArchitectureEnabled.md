---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsArchitectureEnabled
source: html/17ce3253-b19f-25b5-9a04-b5401fa09c3e.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsArchitectureEnabled Property

Checks whether or not the architecture discipline is enabled, and enable or disable it.

## Syntax (C#)
```csharp
public bool IsArchitectureEnabled { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The current product type is not ProductType.Revit and discipline controls are not enabled.

