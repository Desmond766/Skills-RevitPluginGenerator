---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalEquipment.CircuitNamingSchemeId
source: html/dc4fafa0-17d5-2283-91e1-ef70c7b13aa5.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalEquipment.CircuitNamingSchemeId Property

The CircuitNamingSchemeId used in the Electrical Equipment.
 The CircuitNamingSchemeId is used to retrieve the circuit naming scheme id of the Electrical Equipment.

## Syntax (C#)
```csharp
public ElementId CircuitNamingSchemeId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The circuit naming scheme id is invalid for the Electrical Equipment.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

