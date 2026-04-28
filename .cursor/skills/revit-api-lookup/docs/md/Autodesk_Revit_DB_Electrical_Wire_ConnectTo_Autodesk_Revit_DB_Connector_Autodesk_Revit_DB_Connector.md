---
kind: method
id: M:Autodesk.Revit.DB.Electrical.Wire.ConnectTo(Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
source: html/a008dc1e-81a9-8e1c-cc9e-c014a68c2bd9.htm
---
# Autodesk.Revit.DB.Electrical.Wire.ConnectTo Method

Connects the wire to other elements.

## Syntax (C#)
```csharp
public void ConnectTo(
	Connector startConnectorTo,
	Connector endConnectorTo
)
```

## Parameters
- **startConnectorTo** (`Autodesk.Revit.DB.Connector`) - The connector that the start connector of the wire connects to.
- **endConnectorTo** (`Autodesk.Revit.DB.Connector`) - The connector that the end connector of the wire connects to.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - startConnectorTo cannot be connected to a wire, as it is not an electrical connector.
 -or-
 endConnectorTo cannot be connected to a wire, as it is not an electrical connector.
 -or-
 startConnectorTo or/and endConnectorTo cannot be connected to a wire, as wire can't connect both connectors to same wire or same connector.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot connect the wire to the start connector or the end connector.

