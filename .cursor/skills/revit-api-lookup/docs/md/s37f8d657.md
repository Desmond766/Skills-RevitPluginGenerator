---
kind: property
id: P:Autodesk.Revit.DB.Structure.Rebar.Quantity
zh: 钢筋、配筋
source: html/6d042353-dea0-e851-bed7-1143559e03db.htm
---
# Autodesk.Revit.DB.Structure.Rebar.Quantity Property

**中文**: 钢筋、配筋

Identifies the number of bars in rebar set.

## Syntax (C#)
```csharp
public int Quantity { get; }
```

## Remarks
Quantity is equal to NumberOfBarPositions if all the bars are included.
 If any bars are excluded, they are not counted in the Quantity.

