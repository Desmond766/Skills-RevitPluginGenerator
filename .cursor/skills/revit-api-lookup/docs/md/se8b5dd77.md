---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.IsLineIncluded(Autodesk.Revit.DB.Structure.AreaReinforcementLayerType,System.Int32)
source: html/8ee8ebea-8c10-9feb-c76d-735d5ade33a0.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.IsLineIncluded Method

Checks whether the line from the desired layer at the specified position is included or not.

## Syntax (C#)
```csharp
public bool IsLineIncluded(
	AreaReinforcementLayerType layer,
	int linePositionIndex
)
```

## Parameters
- **layer** (`Autodesk.Revit.DB.Structure.AreaReinforcementLayerType`) - The layer on which the line stays.
- **linePositionIndex** (`System.Int32`) - The index of the line from the desired layer. It should be an index between 0 and (NumberOfLines-1).

## Returns
Returns true if the line from the desired layer at the specified position is included, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - linePositionIndex is not in the range [ 0, NumberOfLines-1 ].
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InapplicableDataException** - The layer layer isn't active.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This AreaReinforcement does not host Rebar.

