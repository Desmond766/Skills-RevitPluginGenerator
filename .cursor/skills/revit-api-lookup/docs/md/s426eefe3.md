---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.SetLineIncluded(System.Boolean,Autodesk.Revit.DB.Structure.AreaReinforcementLayerType,System.Int32)
source: html/c735a91d-97a6-7944-1456-4fa495ac1609.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.SetLineIncluded Method

Sets if the line from desired layer at the specified position is included or not.

## Syntax (C#)
```csharp
public void SetLineIncluded(
	bool include,
	AreaReinforcementLayerType layer,
	int linePositionIndex
)
```

## Parameters
- **include** (`System.Boolean`) - True to include the line, false to exclude the line.
- **layer** (`Autodesk.Revit.DB.Structure.AreaReinforcementLayerType`) - The layer on which the line stays.
- **linePositionIndex** (`System.Int32`) - The index of the line from the desired layer. It should be an index between 0 and (NumberOfLines-1).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - linePositionIndex is not in the range [ 0, NumberOfLines-1 ].
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InapplicableDataException** - The layer layer isn't active.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This AreaReinforcement does not host Rebar.

