---
kind: method
id: M:Autodesk.Revit.DB.Connector.DisconnectFrom(Autodesk.Revit.DB.Connector)
zh: 连接件、接口
source: html/bf1b1a52-ae96-d4b7-d2d6-cc43cf57e88e.htm
---
# Autodesk.Revit.DB.Connector.DisconnectFrom Method

**中文**: 连接件、接口

Remove connection between two connectors.

## Syntax (C#)
```csharp
public void DisconnectFrom(
	Connector connector
)
```

## Parameters
- **connector** (`Autodesk.Revit.DB.Connector`) - Indicate the connector, connection will be removed from.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Argument is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when no connection between these two connector.
Thrown on failure to remove the connection between these two connectors.

