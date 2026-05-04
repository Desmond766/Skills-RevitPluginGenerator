---
kind: property
id: P:Autodesk.Revit.DB.Connector.PipeSystemType
zh: 连接件、接口
source: html/0483979e-b7e4-ffaa-d74d-698657d3c42f.htm
---
# Autodesk.Revit.DB.Connector.PipeSystemType Property

**中文**: 连接件、接口

The pipe system type of the connector.

## Syntax (C#)
```csharp
public PipeSystemType PipeSystemType { get; }
```

## Remarks
Instantaneous system type at this connector, calculated according to system. For unconnected connectors,
system type is undefined.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's domain is not DomainPiping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get pipe system type.

