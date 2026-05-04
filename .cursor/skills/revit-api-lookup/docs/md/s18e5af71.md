---
kind: property
id: P:Autodesk.Revit.DB.Connector.AssignedPipeFlowConfiguration
zh: 连接件、接口
source: html/904fc50d-6d76-94a6-ed06-5e34d1cbba40.htm
---
# Autodesk.Revit.DB.Connector.AssignedPipeFlowConfiguration Property

**中文**: 连接件、接口

The pipe flow configuration type of the connector.

## Syntax (C#)
```csharp
public PipeFlowConfigurationType AssignedPipeFlowConfiguration { get; }
```

## Remarks
Assigned pipe flow configuration may be assigned for connectors of some family instances.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's domain is not DomainPiping.
Thrown when the connector is not in a family instance.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get pipe flow configuration.

