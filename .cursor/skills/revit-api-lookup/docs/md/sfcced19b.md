---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetMaterialGaugeByGUID(System.Guid,System.Int32)
source: html/0dcb90fe-5bce-a212-05b0-b107060dd381.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetMaterialGaugeByGUID Method

Gets the material gauge identifier by its GUID and material identifier.

## Syntax (C#)
```csharp
public int GetMaterialGaugeByGUID(
	Guid gaugeGUID,
	int materialId
)
```

## Parameters
- **gaugeGUID** (`System.Guid`) - The material gauge GUID.
- **materialId** (`System.Int32`) - The material identifier. The same material gauge GUID could have different material gauge identifiers for different materials.

## Returns
The gauge identifier. Returns 0 if not found.

