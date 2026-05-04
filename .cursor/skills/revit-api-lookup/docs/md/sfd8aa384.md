---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.DividedSurfaceFailures.DividedSurfaceIgnoresSplitters
source: html/460af8bc-51c2-2332-74ee-b311ed146056.htm
---
# Autodesk.Revit.DB.BuiltInFailures.DividedSurfaceFailures.DividedSurfaceIgnoresSplitters Property

Revit cannot create a rectangular grid by intersecting the current selection of elements (levels, reference planes, or curves drawn on reference planes) with the surface. Make sure that curves do not form closed loops. It is helpful if curves start and end outside the surface, rather than inside it.

## Syntax (C#)
```csharp
public static FailureDefinitionId DividedSurfaceIgnoresSplitters { get; }
```

