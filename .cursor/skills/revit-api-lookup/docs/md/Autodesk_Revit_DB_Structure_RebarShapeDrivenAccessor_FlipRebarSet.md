---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.FlipRebarSet
source: html/500208de-a4b7-2616-d0d9-96c1a9723604.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.FlipRebarSet Method

Flips the rebar set by changing the RebarPlane with the OutOfPlaneExtent and vice versa.

## Syntax (C#)
```csharp
public void FlipRebarSet()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar element represents a single bar (the layout rule is Single).
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.

