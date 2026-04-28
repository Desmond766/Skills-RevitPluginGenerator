---
kind: property
id: P:Autodesk.Revit.DB.Connector.AssignedDuctFlowConfiguration
zh: 连接件、接口
source: html/44c79e5e-0993-3189-0c3a-0490ccecdab0.htm
---
# Autodesk.Revit.DB.Connector.AssignedDuctFlowConfiguration Property

**中文**: 连接件、接口

The assigned duct flow configuration of the connector.

## Syntax (C#)
```csharp
public DuctFlowConfigurationType AssignedDuctFlowConfiguration { get; }
```

## Remarks
Assigned duct flow configuration may be assigned for connectors of some family instances.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's domain is not DomainHvac.
Thrown when the connector is not in a family instance.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get duct flow configuration.

