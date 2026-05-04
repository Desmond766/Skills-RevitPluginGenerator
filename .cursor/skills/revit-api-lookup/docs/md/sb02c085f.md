---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.SetLayoutAsNumberWithSpacing(System.Int32,System.Double,System.Boolean,System.Boolean,System.Boolean)
source: html/3d8b7f68-cfe0-c1ac-c8b3-532a80155e0d.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.SetLayoutAsNumberWithSpacing Method

Sets the Layout Rule property of rebar set to NumberWithSpacing

## Syntax (C#)
```csharp
public void SetLayoutAsNumberWithSpacing(
	int numberOfBarPositions,
	double spacing,
	bool barsOnNormalSide,
	bool includeFirstBar,
	bool includeLastBar
)
```

## Parameters
- **numberOfBarPositions** (`System.Int32`) - The number of bar positions in rebar set
- **spacing** (`System.Double`) - The maximum spacing between rebar in rebar set
- **barsOnNormalSide** (`System.Boolean`) - Identifies if the bars of the rebar set are on the same side of the rebar plane indicated by the normal
- **includeFirstBar** (`System.Boolean`) - Identifies if the first bar in rebar set is shown
- **includeLastBar** (`System.Boolean`) - Identifies if the last bar in rebar set is shown

## Remarks
When changing the layout rule to NumberWithSpacing, you must also simultaneously set NumberOfBarPositions,
 Spacing, BarsOnNormalSide, IncludeFirstBar, and IncludeLastBar properties.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the number of bar positions numberOfBarPositions is less than 1 or more than 1002.
 -or-
 The spacing isn't bigger than 0.0.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This RebarShapeDrivenAccessor is an instance of a spiral or multiplanar shape.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.

