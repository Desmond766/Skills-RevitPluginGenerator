---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSetting.AddVoltageType(System.String,System.Double,System.Double,System.Double)
source: html/49eaeba6-d43d-5af8-a80e-4f0259d137c7.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSetting.AddVoltageType Method

Add a new type definition of voltage into project.

## Syntax (C#)
```csharp
public VoltageType AddVoltageType(
	string name,
	double actualValue,
	double minValue,
	double maxValue
)
```

## Parameters
- **name** (`System.String`) - Specify voltage type name
- **actualValue** (`System.Double`) - Specify actual value of voltage type.
- **minValue** (`System.Double`) - Specify acceptable minimum value of the voltage type.
- **maxValue** (`System.Double`) - Specify acceptable maximum value of the voltage type.

## Returns
New added voltage type object.

