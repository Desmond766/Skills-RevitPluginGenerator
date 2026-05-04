---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.GetDistributionPath
source: html/07a6bc0a-4f85-2d2b-c877-426e5024b4a8.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.GetDistributionPath Method

The distribution path of a rebar set.

## Syntax (C#)
```csharp
public Line GetDistributionPath()
```

## Returns
A line beginning at (0, 0, 0) and representing the direction and
 length of the set.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.

