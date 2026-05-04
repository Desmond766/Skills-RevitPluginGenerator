---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarContainerItem.NumberOfBarPositions
source: html/ed0dc2dd-b3eb-4f4d-75d0-e9d75cea444e.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.NumberOfBarPositions Property

The number of potential bars in the set.

## Syntax (C#)
```csharp
public int NumberOfBarPositions { get; set; }
```

## Remarks
The number of positions is equal to the number of actual
 bars (the Quantity), plus one or two more positions depending
 on IncludeFistBar and IncludeLastBar.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: the number of bar positions numberOfBarPositions is less than 1 or more than 1002.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: This rebar element represents a single bar (the layout rule is Single).

