---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetAllMaterials(Autodesk.Revit.DB.FabricationPart)
source: html/f8e1ab05-467f-6ee6-3103-052d27e8af74.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetAllMaterials Method

Gets all material identifiers in the fabrication configuration.

## Syntax (C#)
```csharp
public IList<int> GetAllMaterials(
	FabricationPart part
)
```

## Parameters
- **part** (`Autodesk.Revit.DB.FabricationPart`) - The fabrication part.

## Returns
An array of material identifiers.

## Remarks
If a part is passed, only returns materials which are valid for the part, otherwise returns all materials.

