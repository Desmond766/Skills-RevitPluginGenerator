---
kind: property
id: P:Autodesk.Revit.DB.Architecture.HandRailType.SupportSpacing
source: html/a8b83465-970d-e478-04ce-a6e9f331723f.htm
---
# Autodesk.Revit.DB.Architecture.HandRailType.SupportSpacing Property

The support spacing of the handrail.

## Syntax (C#)
```csharp
public double SupportSpacing { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for supportSpacing must be between 0 and 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The rail has no support or the support has inappropriate layout so the data being set is not applicable.

