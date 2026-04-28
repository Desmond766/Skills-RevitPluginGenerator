---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarContainerItem.Quantity
source: html/5e0196f4-e72f-c940-9d51-eda1456b55d5.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.Quantity Property

Identifies the number of bars in rebar set.

## Syntax (C#)
```csharp
public int Quantity { get; }
```

## Remarks
Quantity is equal to NumberOfBarPositions if IncludeFirstBar and IncludeLastBar are set.
 If any end bars are excluded, they are not counted in the Quantity.

