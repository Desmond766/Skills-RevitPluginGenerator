---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSetting.AddWireMaterialType(System.String,Autodesk.Revit.DB.Electrical.WireMaterialType)
source: html/bda3127d-4237-2400-aae0-2e3d9d861a98.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSetting.AddWireMaterialType Method

Add a new type of wire material.

## Syntax (C#)
```csharp
public WireMaterialType AddWireMaterialType(
	string name,
	WireMaterialType baseMaterial
)
```

## Parameters
- **name** (`System.String`) - Name of new material type.
- **baseMaterial** (`Autodesk.Revit.DB.Electrical.WireMaterialType`) - Specify an existing material type which New material will be constructed based on.

## Returns
New added wire material type object.

