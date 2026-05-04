---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetAllInsulationSpecifications(Autodesk.Revit.DB.FabricationPart)
source: html/daaeb400-b013-36e5-f4f1-d697b668a712.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetAllInsulationSpecifications Method

Gets all insulation specification identifiers in the fabrication configuration.

## Syntax (C#)
```csharp
public IList<int> GetAllInsulationSpecifications(
	FabricationPart pFabPart
)
```

## Parameters
- **pFabPart** (`Autodesk.Revit.DB.FabricationPart`) - The fabrication part.

## Returns
An array of insulation specification identifiers.

## Remarks
If a part is passed, only returns insulation specification which are valid for the part, otherwise returns all insulation specifications.

