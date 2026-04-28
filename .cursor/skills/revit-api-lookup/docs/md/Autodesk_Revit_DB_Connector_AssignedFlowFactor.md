---
kind: property
id: P:Autodesk.Revit.DB.Connector.AssignedFlowFactor
zh: 连接件、接口
source: html/e648b30d-bc24-05e6-ae83-fa837a0dbde1.htm
---
# Autodesk.Revit.DB.Connector.AssignedFlowFactor Property

**中文**: 连接件、接口

The assigned flow factor of this connector.

## Syntax (C#)
```csharp
public double AssignedFlowFactor { get; set; }
```

## Remarks
Assigned flow factor may be assigned for connectors of some family instances.
In order to set this property, it must be mapped to a writable instance parameter in the family definition.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when get assigned flow factor from a connector not in family instance.
Thrown when the connector's domain is not DomainHvac or DomainPiping.
- **Autodesk.Revit.Exceptions.ArgumentException** - Throw when set an invalid value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get or set assigned flow factor.

