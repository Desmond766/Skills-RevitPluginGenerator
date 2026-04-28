---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsMechanicalEnabled
source: html/0c10ad1b-9de1-baab-d019-99e022688a33.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsMechanicalEnabled Property

Checks whether or not the mechanical discipline is enabled, and enable or disable it.

## Syntax (C#)
```csharp
public bool IsMechanicalEnabled { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The current product type is not ProductType.Revit and discipline controls are not enabled.

