---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaReinforcement.GetNumberOfLines(Autodesk.Revit.DB.Structure.AreaReinforcementLayerType)
source: html/dff33b0e-1669-d318-5225-bd8472529eee.htm
---
# Autodesk.Revit.DB.Structure.AreaReinforcement.GetNumberOfLines Method

Gets the number of lines on the specified layer. It also counts the excluded ones.

## Syntax (C#)
```csharp
public int GetNumberOfLines(
	AreaReinforcementLayerType layer
)
```

## Parameters
- **layer** (`Autodesk.Revit.DB.Structure.AreaReinforcementLayerType`) - The layer type for which will return the number of lines.

## Returns
Returns the number of lines on the specified layer.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InapplicableDataException** - The layer layer isn't active.

