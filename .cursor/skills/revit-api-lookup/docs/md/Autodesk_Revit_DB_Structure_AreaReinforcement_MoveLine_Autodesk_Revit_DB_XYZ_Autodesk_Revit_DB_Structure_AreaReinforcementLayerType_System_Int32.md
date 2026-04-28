---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.MoveLine(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Structure.AreaReinforcementLayerType,System.Int32)
source: html/4fe8818c-3647-3e08-3bad-34452230ee1a.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.MoveLine Method

This method applies the translation to the line from the desired layer, at the specified position.
 If the line was already moved, the method will concatenate the translation with the existing movement.
 The line will be translated only along the direction of the specified layer.

## Syntax (C#)
```csharp
public void MoveLine(
	XYZ translation,
	AreaReinforcementLayerType layer,
	int linePositionIndex
)
```

## Parameters
- **translation** (`Autodesk.Revit.DB.XYZ`) - The translation vector.
- **layer** (`Autodesk.Revit.DB.Structure.AreaReinforcementLayerType`) - The layer on which the line stays.
- **linePositionIndex** (`System.Int32`) - The index of the line from the desired layer. It should be an index between 0 and (NumberOfLines-1).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - linePositionIndex is not in the range [ 0, NumberOfLines-1 ].
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InapplicableDataException** - The layer layer isn't active.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This AreaReinforcement does not host Rebar.

