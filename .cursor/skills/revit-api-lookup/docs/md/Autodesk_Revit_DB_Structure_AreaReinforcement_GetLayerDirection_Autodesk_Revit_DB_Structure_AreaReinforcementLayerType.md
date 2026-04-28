---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.GetLayerDirection(Autodesk.Revit.DB.Structure.AreaReinforcementLayerType)
source: html/bccd4ced-ea99-d3ba-0865-7fd8f8466d29.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.GetLayerDirection Method

Gets the direction of the layer. The lines are distributed along this direction.

## Syntax (C#)
```csharp
public XYZ GetLayerDirection(
	AreaReinforcementLayerType layer
)
```

## Parameters
- **layer** (`Autodesk.Revit.DB.Structure.AreaReinforcementLayerType`) - The layer type.

## Returns
Returns the direction of the desired layer.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InapplicableDataException** - The layer layer isn't active.

