---
kind: property
id: P:Autodesk.Revit.DB.Connector.DuctSystemType
zh: 连接件、接口
source: html/36b43f14-8bd2-4a76-4661-0e13a90ea0e8.htm
---
# Autodesk.Revit.DB.Connector.DuctSystemType Property

**中文**: 连接件、接口

The duct system type of the connector.

## Syntax (C#)
```csharp
public DuctSystemType DuctSystemType { get; }
```

## Remarks
This is the instantaneous system type at this connector, calculated according to system. For unconnected connectors,
the system type is undefined.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's domain is not DomainHvac.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get duct system type.

