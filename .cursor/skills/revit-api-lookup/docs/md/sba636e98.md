---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsType.MiddleSupportsNumber
source: html/d1f30d8c-ee9a-1d4c-448d-655b8c2580e3.htm
---
# Autodesk.Revit.DB.Architecture.StairsType.MiddleSupportsNumber Property

The number of middle supports used in the stair.

## Syntax (C#)
```csharp
public int MiddleSupportsNumber { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for supportsNumber is negative.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The stairs type has no middle support so the data being set is not applicable.

