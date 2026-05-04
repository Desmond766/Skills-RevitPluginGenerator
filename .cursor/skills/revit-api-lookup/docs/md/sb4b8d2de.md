---
kind: property
id: P:Autodesk.Revit.DB.Connector.AssignedLossCoefficient
zh: 连接件、接口
source: html/f802ede5-376e-039d-baac-a5f2a8c1a8bb.htm
---
# Autodesk.Revit.DB.Connector.AssignedLossCoefficient Property

**中文**: 连接件、接口

The assigned loss coefficient of the connector.

## Syntax (C#)
```csharp
public double AssignedLossCoefficient { get; set; }
```

## Remarks
Assigned loss coefficient may be assigned for connectors of some family instances, for more information.
In order to set this property, it must be mapped to a writable instance parameter in the family definition.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's domain is not DomainHvac.
Thrown when the connector is not in a family instance.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when set an invalid value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get or set assigned loss coefficient.

