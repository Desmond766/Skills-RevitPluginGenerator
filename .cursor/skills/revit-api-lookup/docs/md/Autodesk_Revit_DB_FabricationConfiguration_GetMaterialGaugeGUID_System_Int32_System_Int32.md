---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetMaterialGaugeGUID(System.Int32,System.Int32)
source: html/8a8c3761-d5ee-15a5-abc0-659d62845c0c.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetMaterialGaugeGUID Method

Gets the material gauge GUID by its material/gauge identifiers.

## Syntax (C#)
```csharp
public Guid GetMaterialGaugeGUID(
	int materialId,
	int gaugeId
)
```

## Parameters
- **materialId** (`System.Int32`) - The material identifier. The same material gauge GUID could have different material gauge identifiers for different materials.
- **gaugeId** (`System.Int32`) - The material gauge identifier.

## Returns
The material gauge GUID. Returns empty GUID if not found.

