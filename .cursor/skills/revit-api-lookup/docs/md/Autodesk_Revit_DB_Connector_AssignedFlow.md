---
kind: property
id: P:Autodesk.Revit.DB.Connector.AssignedFlow
zh: 连接件、接口
source: html/3029ebbb-6a31-58ce-ac30-5c17cbfec130.htm
---
# Autodesk.Revit.DB.Connector.AssignedFlow Property

**中文**: 连接件、接口

The assigned flow of the connector.

## Syntax (C#)
```csharp
public double AssignedFlow { get; set; }
```

## Remarks
Assigned flow may be assigned for connectors of some family instances.
In order to set this property, it must be mapped to a writable instance parameter in the family definition.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's domain is not DomainPiping or DomainHvac.
Thrown when the connector is not in a family instance.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when set an invalid value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get or set assigned flow.

