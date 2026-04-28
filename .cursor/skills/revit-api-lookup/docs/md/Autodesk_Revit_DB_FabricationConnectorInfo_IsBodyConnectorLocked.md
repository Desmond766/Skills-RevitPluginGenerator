---
kind: property
id: P:Autodesk.Revit.DB.FabricationConnectorInfo.IsBodyConnectorLocked
source: html/02471b4d-b14b-e85e-0a62-2d7c7f2d9774.htm
---
# Autodesk.Revit.DB.FabricationConnectorInfo.IsBodyConnectorLocked Property

Fabrication body connector lock.

## Syntax (C#)
```csharp
public bool IsBodyConnectorLocked { get; set; }
```

## Remarks
If set this prevents the connector value being overridden by the fabrication specification.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: the connector cannot be modified on an owned fabrication part.
 -or-
 When setting this property: the connector is already connected.
 -or-
 When setting this property: the fabrication part is connected to more than one item.

