---
kind: property
id: P:Autodesk.Revit.DB.FabricationConnectorInfo.IsDoubleWallConnectorLocked
source: html/dde48673-bcba-5cb1-b85d-101337d92c5c.htm
---
# Autodesk.Revit.DB.FabricationConnectorInfo.IsDoubleWallConnectorLocked Property

Fabrication double wall connector lock.

## Syntax (C#)
```csharp
public bool IsDoubleWallConnectorLocked { get; set; }
```

## Remarks
If set this prevents the connector value being overridden by the fabrication specification.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - No double wall connector available.
 -or-
 When setting this property: the connector cannot be modified on an owned fabrication part.
 -or-
 When setting this property: the connector is already connected.
 -or-
 When setting this property: the fabrication part is connected to more than one item.

