---
kind: property
id: P:Autodesk.Revit.DB.Structure.Rebar.NumberOfBarPositions
zh: 钢筋、配筋
source: html/f063cb6e-c159-f0e8-519f-666a797fa53c.htm
---
# Autodesk.Revit.DB.Structure.Rebar.NumberOfBarPositions Property

**中文**: 钢筋、配筋

The number of potential bars in the set.

## Syntax (C#)
```csharp
public int NumberOfBarPositions { get; set; }
```

## Remarks
The number of positions is equal to the number of actual bars (the Quantity), plus the number of bars that are excluded.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: the number of bar positions numberOfBarPositions is less than 1 or more than 1002.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: This rebar element represents a single bar (the layout rule is Single).

