---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSetting.AddWireType(System.String,Autodesk.Revit.DB.Electrical.WireMaterialType,Autodesk.Revit.DB.Electrical.TemperatureRatingType,Autodesk.Revit.DB.Electrical.InsulationType,Autodesk.Revit.DB.Electrical.WireSize,System.Double,System.Boolean,Autodesk.Revit.DB.Electrical.NeutralMode,Autodesk.Revit.DB.Electrical.WireConduitType)
source: html/96fef9f1-166b-082d-1ec7-e844ac51297f.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSetting.AddWireType Method

Add a new wire type to project.

## Syntax (C#)
```csharp
public WireType AddWireType(
	string name,
	WireMaterialType materialType,
	TemperatureRatingType temperatureRating,
	InsulationType insulation,
	WireSize maxSize,
	double neutralMultiplier,
	bool neutralRequired,
	NeutralMode neutralMode,
	WireConduitType conduit
)
```

## Parameters
- **name** (`System.String`) - Name of the new wire type.
- **materialType** (`Autodesk.Revit.DB.Electrical.WireMaterialType`) - Wire material of new wire type.
- **temperatureRating** (`Autodesk.Revit.DB.Electrical.TemperatureRatingType`) - Temperature rating type information of new wire type.
- **insulation** (`Autodesk.Revit.DB.Electrical.InsulationType`) - Insulation of new wire type.
- **maxSize** (`Autodesk.Revit.DB.Electrical.WireSize`) - Max wire size of new wire type.
- **neutralMultiplier** (`System.Double`) - Neutral multiplier of new wire type.
- **neutralRequired** (`System.Boolean`) - Specify whether neutral point is required.
- **neutralMode** (`Autodesk.Revit.DB.Electrical.NeutralMode`) - Specify neutral mode.
- **conduit** (`Autodesk.Revit.DB.Electrical.WireConduitType`) - Conduit type of new wire type.

## Returns
New added wire type object.

## Remarks
Parameter of temperatureRating should be retrieved from parameter of materialType, 
and parameters such as insulation and maxSize should be retrieved from temperatureRating.
otherwise, this add operation is most likely to fail.

