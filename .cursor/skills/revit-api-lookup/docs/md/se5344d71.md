---
kind: property
id: P:Autodesk.Revit.DB.FabricationConnectorInfo.BodyConnectorId
source: html/a6d0e9ef-9b0e-d83e-1e62-7a4ddeaf4c2d.htm
---
# Autodesk.Revit.DB.FabricationConnectorInfo.BodyConnectorId Property

Fabrication body connector Id.

## Syntax (C#)
```csharp
public int BodyConnectorId { get; set; }
```

## Remarks
A reference to the fabrication configuration connectors.
 Setting the connector value will also set the connector lock.
 A value of 0 indicates the connector is set to none.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: bodyConnectorId is invalid based on the shape and domain.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: the connector cannot be modified on an owned fabrication part.
 -or-
 When setting this property: the connector is already connected.
 -or-
 When setting this property: the fabrication part is connected to more than one item.

