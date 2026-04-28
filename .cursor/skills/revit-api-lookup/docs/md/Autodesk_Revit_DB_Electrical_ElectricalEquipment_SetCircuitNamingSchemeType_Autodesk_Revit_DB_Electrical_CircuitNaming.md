---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalEquipment.SetCircuitNamingSchemeType(Autodesk.Revit.DB.Electrical.CircuitNaming)
source: html/701adb85-93d5-f0f7-1041-5f5ae5a20ef3.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalEquipment.SetCircuitNamingSchemeType Method

Sets the circuit naming scheme for Electrical Equipment.

## Syntax (C#)
```csharp
public void SetCircuitNamingSchemeType(
	CircuitNaming circuitNamingType
)
```

## Parameters
- **circuitNamingType** (`Autodesk.Revit.DB.Electrical.CircuitNaming`) - The enumerated type of circuit naming scheme to be set.

## Remarks
The following circuit naming scheme type can be set: CircuitNaming::Prefixed CircuitNaming::Standard CircuitNaming::PanelName CircuitNaming::Phase CircuitNaming::ProjectSetting For a customized circuit naming scheme, set its id directly with SetCircuitNamingSchemeId method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The circuit naming scheme enumerated type is invalid for the Electrical Equipment.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

