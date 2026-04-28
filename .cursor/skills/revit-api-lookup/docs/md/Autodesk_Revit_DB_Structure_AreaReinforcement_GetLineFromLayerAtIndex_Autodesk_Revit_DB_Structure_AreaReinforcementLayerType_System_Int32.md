---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.GetLineFromLayerAtIndex(Autodesk.Revit.DB.Structure.AreaReinforcementLayerType,System.Int32)
source: html/8fa3c4da-89e0-28a5-d6dc-30f675dbb04b.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.GetLineFromLayerAtIndex Method

Gets the line from the desired layer at the specified index.

## Syntax (C#)
```csharp
public Line GetLineFromLayerAtIndex(
	AreaReinforcementLayerType layer,
	int linePositionIndex
)
```

## Parameters
- **layer** (`Autodesk.Revit.DB.Structure.AreaReinforcementLayerType`) - The layer on which the line stays.
- **linePositionIndex** (`System.Int32`) - The index of the line from the desired layer. It should be an index between 0 and (NumberOfLines-1).

## Returns
Returns the line from the desired layer at the specified index.

## Remarks
This method will return the line even if it isn't included.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - linePositionIndex is not in the range [ 0, NumberOfLines-1 ].
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InapplicableDataException** - The layer layer isn't active.

