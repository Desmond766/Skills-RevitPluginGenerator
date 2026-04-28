---
kind: property
id: P:Autodesk.Revit.DB.Connector.Demand
zh: 连接件、接口
source: html/13d8bd21-12d4-e82a-835b-4de9d75b88b3.htm
---
# Autodesk.Revit.DB.Connector.Demand Property

**中文**: 连接件、接口

The demand of the connector.

## Syntax (C#)
```csharp
public double Demand { get; }
```

## Remarks
Instantaneous demand at this connector, calculated according to system.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's domain is not DomainPiping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get demand.

