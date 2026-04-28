---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsMassingEnabled
source: html/a71d8bc5-6c07-8388-ce24-f9227ca046b8.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsMassingEnabled Property

Checks whether or not the massing and site tools are enabled, and enable or disable them.

## Syntax (C#)
```csharp
public bool IsMassingEnabled { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The current product type is not ProductType.Revit and discipline controls are not enabled.

