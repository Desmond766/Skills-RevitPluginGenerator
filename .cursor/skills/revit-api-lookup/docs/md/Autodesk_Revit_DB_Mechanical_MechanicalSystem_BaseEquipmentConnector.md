---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.MechanicalSystem.BaseEquipmentConnector
source: html/0aa90e49-871d-89e5-4af0-c20472df9729.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalSystem.BaseEquipmentConnector Property

The connector within the base equipment which is used to connect with the system.

## Syntax (C#)
```csharp
public Connector BaseEquipmentConnector { get; set; }
```

## Remarks
Assigning Nothing nullptr a null reference ( Nothing in Visual Basic) to the base equipment connector will disconnect the base equipment from the system.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when assigning a connector which is used in a system, 
or when the connector's owner is not of type 'mechanical equipment'.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the set operation failed.

