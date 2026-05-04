---
kind: property
id: P:Autodesk.Revit.DB.Connector.ElectricalSystemType
zh: 连接件、接口
source: html/cdaff8f1-2172-9ad5-aa94-2165a3ce851c.htm
---
# Autodesk.Revit.DB.Connector.ElectricalSystemType Property

**中文**: 连接件、接口

The electrical system type of the connector.

## Syntax (C#)
```csharp
public ElectricalSystemType ElectricalSystemType { get; }
```

## Remarks
Instantaneous system type at this connector, calculated according to system. For unconnected connectors,
system type is undefined.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's domain is not of DomainElectrical.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get electrical system type.

