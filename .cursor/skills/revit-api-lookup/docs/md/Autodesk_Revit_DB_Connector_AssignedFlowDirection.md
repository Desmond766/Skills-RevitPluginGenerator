---
kind: property
id: P:Autodesk.Revit.DB.Connector.AssignedFlowDirection
zh: 连接件、接口
source: html/17222532-ea11-5ce8-9529-be2a17202693.htm
---
# Autodesk.Revit.DB.Connector.AssignedFlowDirection Property

**中文**: 连接件、接口

The assigned flow direction of the connector.

## Syntax (C#)
```csharp
public FlowDirectionType AssignedFlowDirection { get; }
```

## Remarks
Flow direction may be assigned for connectors of some family instances.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector is not in a family instance.
Thrown when the connector's domain is not DomainHvac or DomainPiping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get assigned flow direction.

