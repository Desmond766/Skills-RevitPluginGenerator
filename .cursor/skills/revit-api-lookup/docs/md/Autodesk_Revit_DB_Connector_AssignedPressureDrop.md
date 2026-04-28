---
kind: property
id: P:Autodesk.Revit.DB.Connector.AssignedPressureDrop
zh: 连接件、接口
source: html/a09e2d7b-ff91-b9ea-b018-54ee8365c9c6.htm
---
# Autodesk.Revit.DB.Connector.AssignedPressureDrop Property

**中文**: 连接件、接口

The assigned pressure drop of the connector.

## Syntax (C#)
```csharp
public double AssignedPressureDrop { get; set; }
```

## Remarks
Assigned pressure drop may be assigned for connectors of some family instances.
In order to set this property, it must be mapped to a writable instance parameter in the family definition.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector is not in a family instance.
Thrown when the connector's domain is not DomainHvac or DomainPiping.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when set an invalid value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get or set assigned pressure drop.

