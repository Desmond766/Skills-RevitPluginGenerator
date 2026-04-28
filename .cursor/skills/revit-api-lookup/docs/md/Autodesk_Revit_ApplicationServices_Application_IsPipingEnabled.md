---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsPipingEnabled
source: html/4e39799b-6409-29dc-30fb-fe0616c38a74.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsPipingEnabled Property

Checks whether or not the piping discipline is enabled, and enable or disable it.

## Syntax (C#)
```csharp
public bool IsPipingEnabled { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The current product type is not ProductType.Revit and discipline controls are not enabled.

