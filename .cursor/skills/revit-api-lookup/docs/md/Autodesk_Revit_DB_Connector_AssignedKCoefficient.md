---
kind: property
id: P:Autodesk.Revit.DB.Connector.AssignedKCoefficient
zh: 连接件、接口
source: html/b359a317-fa13-b4c3-9fc2-80603391e3d4.htm
---
# Autodesk.Revit.DB.Connector.AssignedKCoefficient Property

**中文**: 连接件、接口

The assigned kCoefficient of the connector.

## Syntax (C#)
```csharp
public double AssignedKCoefficient { get; set; }
```

## Remarks
Assigned kCoefficient may be assigned for connectors of some family instances, for more information.
In order to set this property, it must be mapped to a writable instance parameter in the family definition.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's domain is not DomainPiping.
Thrown when the connector is not in a family instance.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when set an invalid value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get or set kCoefficient.

