---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.SetLayerActive(System.Boolean,Autodesk.Revit.DB.Structure.AreaReinforcementLayerType)
source: html/47b31cd0-84ba-13e3-4a6d-66a3356d3b75.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.SetLayerActive Method

Sets if the desired layer is active or not.

## Syntax (C#)
```csharp
public void SetLayerActive(
	bool active,
	AreaReinforcementLayerType layer
)
```

## Parameters
- **active** (`System.Boolean`) - True to set the layer to be active, false otherwise.
- **layer** (`Autodesk.Revit.DB.Structure.AreaReinforcementLayerType`) - The layer type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

