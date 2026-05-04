---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.ResetMovedLineTransform(Autodesk.Revit.DB.Structure.AreaReinforcementLayerType,System.Int32)
source: html/b44bf1dd-1cdb-50e2-59ab-b7894566019d.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.ResetMovedLineTransform Method

Reset the transformation representing the movement of the line relative to its default position along the direction of the specified layer. The moved line transform will be set to Identity.

## Syntax (C#)
```csharp
public void ResetMovedLineTransform(
	AreaReinforcementLayerType layer,
	int linePositionIndex
)
```

## Parameters
- **layer** (`Autodesk.Revit.DB.Structure.AreaReinforcementLayerType`) - The layer on which the line stays.
- **linePositionIndex** (`System.Int32`) - The index of the line from the desired layer. It should be an index between 0 and (NumberOfLines-1).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - linePositionIndex is not in the range [ 0, NumberOfLines-1 ].
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InapplicableDataException** - The layer layer isn't active.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This AreaReinforcement does not host Rebar.

