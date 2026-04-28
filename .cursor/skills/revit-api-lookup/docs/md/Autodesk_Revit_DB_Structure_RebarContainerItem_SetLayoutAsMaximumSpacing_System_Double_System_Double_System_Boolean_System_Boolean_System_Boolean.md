---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.SetLayoutAsMaximumSpacing(System.Double,System.Double,System.Boolean,System.Boolean,System.Boolean)
source: html/d88219dd-f484-4738-5c1d-46a676fac072.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.SetLayoutAsMaximumSpacing Method

Sets the Layout Rule property of rebar set to MaximumSpacing

## Syntax (C#)
```csharp
public void SetLayoutAsMaximumSpacing(
	double spacing,
	double arrayLength,
	bool barsOnNormalSide,
	bool includeFirstBar,
	bool includeLastBar
)
```

## Parameters
- **spacing** (`System.Double`) - The maximum spacing between rebar in rebar set
- **arrayLength** (`System.Double`) - The distribution length of rebar set
- **barsOnNormalSide** (`System.Boolean`) - Identifies if the bars of the rebar set are on the same side of the rebar plane indicated by the normal
- **includeFirstBar** (`System.Boolean`) - Identifies if the first bar in rebar set is shown
- **includeLastBar** (`System.Boolean`) - Identifies if the last bar in rebar set is shown

## Remarks
When changing the layout rule to MaximumSpacing, you must also simultaneously set Spacing,
 SetLength, BarsOnNormalSide, IncludeFirstBar, and IncludeLastBar properties.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The spacing isn't bigger than 0.0.
 -or-
 the set length arrayLength isn't acceptable.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This RebarContainerItem is an instance of a spiral or multiplanar shape.

