---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.GetMovedLineTransform(Autodesk.Revit.DB.Structure.AreaReinforcementLayerType,System.Int32)
source: html/d07d2b3b-98ae-6ede-cc91-2d0bde1a4044.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.GetMovedLineTransform Method

Returns a transform representing the movement of the line relative to its default position along the direction of the desired layer.

## Syntax (C#)
```csharp
public Transform GetMovedLineTransform(
	AreaReinforcementLayerType layer,
	int linePositionIndex
)
```

## Parameters
- **layer** (`Autodesk.Revit.DB.Structure.AreaReinforcementLayerType`) - The layer on which the line stays.
- **linePositionIndex** (`System.Int32`) - The index of the line from the desired layer. It should be an index between 0 and (NumberOfLines-1).

## Returns
The transform representing the movement of the line relative to its default position along the direction of the desired layer.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - linePositionIndex is not in the range [ 0, NumberOfLines-1 ].
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InapplicableDataException** - The layer layer isn't active.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This AreaReinforcement does not host Rebar.

