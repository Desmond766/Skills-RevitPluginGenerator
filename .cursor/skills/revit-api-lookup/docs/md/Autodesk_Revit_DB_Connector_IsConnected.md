---
kind: property
id: P:Autodesk.Revit.DB.Connector.IsConnected
zh: 连接件、接口
source: html/84d067ae-d08b-1345-55ce-8086c24cc538.htm
---
# Autodesk.Revit.DB.Connector.IsConnected Property

**中文**: 连接件、接口

Identifies if the connector is physically connected to a connector on another element.

## Syntax (C#)
```csharp
public bool IsConnected { get; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's type is LogicalConn.

