---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsStructureEnabled
source: html/74fd9e8e-1178-e153-02c7-0703c2703191.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsStructureEnabled Property

Checks whether or not the structure discipline is enabled, and enable or disable it.

## Syntax (C#)
```csharp
public bool IsStructureEnabled { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The current product type is not ProductType.Revit and discipline controls are not enabled.

