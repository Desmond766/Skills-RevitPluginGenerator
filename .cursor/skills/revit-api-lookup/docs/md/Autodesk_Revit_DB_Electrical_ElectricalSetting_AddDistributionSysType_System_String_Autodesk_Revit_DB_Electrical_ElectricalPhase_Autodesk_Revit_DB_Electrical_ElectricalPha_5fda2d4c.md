---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSetting.AddDistributionSysType(System.String,Autodesk.Revit.DB.Electrical.ElectricalPhase,Autodesk.Revit.DB.Electrical.ElectricalPhaseConfiguration,System.Int32,Autodesk.Revit.DB.Electrical.VoltageType,Autodesk.Revit.DB.Electrical.VoltageType)
source: html/298ea72a-5647-a71d-d6d5-9da1dab5ecbd.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSetting.AddDistributionSysType Method

Add a new distribution system type to project.

## Syntax (C#)
```csharp
public DistributionSysType AddDistributionSysType(
	string name,
	ElectricalPhase phase,
	ElectricalPhaseConfiguration phaseConfig,
	int numWire,
	VoltageType volLineToLine,
	VoltageType volLineToGround
)
```

## Parameters
- **name** (`System.String`) - The name of new added distribution system type
- **phase** (`Autodesk.Revit.DB.Electrical.ElectricalPhase`) - Single or three phase this type is
- **phaseConfig** (`Autodesk.Revit.DB.Electrical.ElectricalPhaseConfiguration`) - Configuration property of given phase
- **numWire** (`System.Int32`) - Wire number of this distribution system
- **volLineToLine** (`Autodesk.Revit.DB.Electrical.VoltageType`) - Type of line to line voltage in this system
- **volLineToGround** (`Autodesk.Revit.DB.Electrical.VoltageType`) - Type of line to ground voltage in this system

## Returns
New added distribution system type object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The name can't be Nothing nullptr a null reference ( Nothing in Visual Basic) , empty string, or equal with any existing one,
phaseConfig should be defined and numWire can only be 3 or 4 in case of three phase,
numWire can only be 2 or 3 in case of single phase,
otherwise exception will be thrown.

