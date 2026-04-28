---
kind: property
id: P:Autodesk.Revit.DB.Architecture.HandRailType.SupportNumber
source: html/b7bda910-80d6-549e-36c4-f35479910aca.htm
---
# Autodesk.Revit.DB.Architecture.HandRailType.SupportNumber Property

The number of supports of the handrail.

## Syntax (C#)
```csharp
public int SupportNumber { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for supportNumber is negative.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The rail has no support or the support layout is not fixed number so the data being set is not applicable.

