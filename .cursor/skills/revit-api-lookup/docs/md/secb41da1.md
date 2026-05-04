---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalSystem.CircuitConnectionType
source: html/bb0dbea9-3739-23e5-70ca-150b6a44a029.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.CircuitConnectionType Property

The circuit connection type of the electrical system.

## Syntax (C#)
```csharp
public CircuitConnectionType CircuitConnectionType { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - When setting this property: None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The connection type is invalid for this circuit.
 You can't assign Feed Through Lugs if the panel's Feed Through Lugs option is unchecked.
 If the circuit's base panel is not a data panel or transformer panel, the circuit connection type can't be set to NotApplicable.
 If the circuit's base panel is a data panel or transformer pane, it must be set to NotApplicable.
 If the circuit doesn't have a base panel, it must be set to NotApplicable.
 -or-
 When setting this property: Invalid connection type.

