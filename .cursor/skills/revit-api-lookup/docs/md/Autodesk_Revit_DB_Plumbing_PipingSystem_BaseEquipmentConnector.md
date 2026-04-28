---
kind: property
id: P:Autodesk.Revit.DB.Plumbing.PipingSystem.BaseEquipmentConnector
source: html/15ef1a11-38c9-04ca-a75d-92d63f129047.htm
---
# Autodesk.Revit.DB.Plumbing.PipingSystem.BaseEquipmentConnector Property

The connector within base equipment which is used to connect with system.

## Syntax (C#)
```csharp
public Connector BaseEquipmentConnector { get; set; }
```

## Remarks
Setting this property to Nothing nullptr a null reference ( Nothing in Visual Basic) will disconnect base equipment from system.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when assigning a connector which is used in a system,
or when the connector's owner is not of type 'mechanical equipment'.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the set operation failed.

