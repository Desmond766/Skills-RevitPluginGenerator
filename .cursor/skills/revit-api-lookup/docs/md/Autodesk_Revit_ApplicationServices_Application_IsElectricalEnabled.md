---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsElectricalEnabled
source: html/63e5db39-add7-0ea2-d935-2bd5d800f282.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsElectricalEnabled Property

Checks whether or not the electrical discipline is enabled, and enable or disable it.

## Syntax (C#)
```csharp
public bool IsElectricalEnabled { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The current product type is not ProductType.Revit and discipline controls are not enabled.

