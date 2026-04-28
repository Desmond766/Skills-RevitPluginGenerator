---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.SetLayoutAsFixedNumber(System.Int32,System.Double,System.Boolean,System.Boolean,System.Boolean)
source: html/7c171f9c-694b-ca7f-9666-d468e51493b9.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.SetLayoutAsFixedNumber Method

Sets the Layout Rule property of rebar set to FixedNumber.

## Syntax (C#)
```csharp
public void SetLayoutAsFixedNumber(
	int numberOfBarPositions,
	double arrayLength,
	bool barsOnNormalSide,
	bool includeFirstBar,
	bool includeLastBar
)
```

## Parameters
- **numberOfBarPositions** (`System.Int32`) - The number of bar positions in rebar set
- **arrayLength** (`System.Double`) - The distribution length of rebar set
- **barsOnNormalSide** (`System.Boolean`) - Identifies if the bars of the rebar set are on the same side of the rebar plane indicated by the normal
- **includeFirstBar** (`System.Boolean`) - Identifies if the first bar in rebar set is shown
- **includeLastBar** (`System.Boolean`) - Identifies if the last bar in rebar set is shown

## Remarks
When changing the layout rule to FixedNumber, you must also simultaneously set NumberOfBarPositions,
 SetLength, BarsOnNormalSide, IncludeFirstBar, and IncludeLastBar properties.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the number of bar positions numberOfBarPositions is less than 1 or more than 1002.
 -or-
 the set length arrayLength isn't acceptable.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This RebarContainerItem is an instance of a spiral or multiplanar shape.

