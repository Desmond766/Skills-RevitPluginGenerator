---
kind: property
id: P:Autodesk.Revit.DB.FabricationConnectorInfo.DoubleWallConnectorId
source: html/25b9a7ec-905b-c842-3246-1cd2aacde7c2.htm
---
# Autodesk.Revit.DB.FabricationConnectorInfo.DoubleWallConnectorId Property

Fabrication double wall connector Id.

## Syntax (C#)
```csharp
public int DoubleWallConnectorId { get; set; }
```

## Remarks
A reference to the fabrication configuration connectors.
 Setting the connector value will also set the connector lock.
 A value of 0 indicates no connector.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: doubleWallConnectorId is invalid based on the shape and domain.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - No double wall connector available.
 -or-
 When setting this property: the connector cannot be modified on an owned fabrication part.
 -or-
 When setting this property: the connector is already connected.
 -or-
 When setting this property: the fabrication part is connected to more than one item.

