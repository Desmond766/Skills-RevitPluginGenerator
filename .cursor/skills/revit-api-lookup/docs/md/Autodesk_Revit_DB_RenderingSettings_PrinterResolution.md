---
kind: property
id: P:Autodesk.Revit.DB.RenderingSettings.PrinterResolution
source: html/e72698ad-f421-2c2f-8cc3-f10c4134bd57.htm
---
# Autodesk.Revit.DB.RenderingSettings.PrinterResolution Property

The resolution level when using printer.

## Syntax (C#)
```csharp
public PrinterResolution PrinterResolution { get; set; }
```

## Remarks
The suitable resolution value is decided by default. You may obtain it from the ResolutionValue property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The resolution target is not printer.

