---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarInSystem.Quantity
source: html/e8c55ade-5864-a1ec-4354-930f475f2414.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.Quantity Property

Identifies the number of bars in rebar set.

## Syntax (C#)
```csharp
public int Quantity { get; }
```

## Remarks
Quantity is equal to NumberOfBarPositions if all the bars are included.
 If any bars are excluded, they are not counted in the Quantity.

