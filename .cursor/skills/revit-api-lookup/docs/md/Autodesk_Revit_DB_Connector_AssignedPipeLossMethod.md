---
kind: property
id: P:Autodesk.Revit.DB.Connector.AssignedPipeLossMethod
zh: 连接件、接口
source: html/26f5d9ad-ee88-7f89-11ee-63ef0dc40fcc.htm
---
# Autodesk.Revit.DB.Connector.AssignedPipeLossMethod Property

**中文**: 连接件、接口

The pipe loss method of the connector.

## Syntax (C#)
```csharp
public PipeLossMethodType AssignedPipeLossMethod { get; }
```

## Remarks
Assigned duct pipe loss method may be assigned for connectors of some family instances.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's domain is not DomainPiping.
Thrown when the connector is not in a family instance.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get pipe loss method.

