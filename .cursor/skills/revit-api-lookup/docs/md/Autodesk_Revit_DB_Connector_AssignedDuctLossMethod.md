---
kind: property
id: P:Autodesk.Revit.DB.Connector.AssignedDuctLossMethod
zh: 连接件、接口
source: html/8a48b4c9-97ad-24d2-dc14-8d899846ed96.htm
---
# Autodesk.Revit.DB.Connector.AssignedDuctLossMethod Property

**中文**: 连接件、接口

The duct loss method of the connector.

## Syntax (C#)
```csharp
public DuctLossMethodType AssignedDuctLossMethod { get; }
```

## Remarks
Assigned duct loss method may be assigned for connectors of some family instances.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's domain is not DomainHvac.
Thrown when the connector is not in family instance.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get duct loss method.

