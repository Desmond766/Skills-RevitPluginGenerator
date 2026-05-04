---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.IsLayerActive(Autodesk.Revit.DB.Structure.AreaReinforcementLayerType)
source: html/547599ea-6b67-5d1e-7486-207e2764df70.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.IsLayerActive Method

Identifies if the layer is active or not.

## Syntax (C#)
```csharp
public bool IsLayerActive(
	AreaReinforcementLayerType layer
)
```

## Parameters
- **layer** (`Autodesk.Revit.DB.Structure.AreaReinforcementLayerType`) - The layer that will be tested.

## Returns
Returns true if the input layer is active, false otherwise

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

