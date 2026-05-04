---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.SetLayoutAsMinimumClearSpacing(System.Double,System.Double,System.Boolean,System.Boolean,System.Boolean)
source: html/fafd15e8-dc6b-7cc3-b6ec-c4ce9eb4b1af.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.SetLayoutAsMinimumClearSpacing Method

Sets the Layout Rule property of rebar set to MinimumClearSpacing

## Syntax (C#)
```csharp
public void SetLayoutAsMinimumClearSpacing(
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
When changing the layout rule to MinimumClearSpacing, you must also simultaneously set Spacing,
 SetLength, BarsOnNormalSide, IncludeFirstBar, and IncludeLastBar properties.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The spacing isn't bigger than 0.0.
 -or-
 the set length arrayLength isn't acceptable.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This RebarShapeDrivenAccessor is an instance of a spiral or multiplanar shape.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.

