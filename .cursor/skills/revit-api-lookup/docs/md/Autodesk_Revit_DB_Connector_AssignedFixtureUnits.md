---
kind: property
id: P:Autodesk.Revit.DB.Connector.AssignedFixtureUnits
zh: 连接件、接口
source: html/0cac35c7-bdee-b54b-3940-e33942eabc57.htm
---
# Autodesk.Revit.DB.Connector.AssignedFixtureUnits Property

**中文**: 连接件、接口

The assigned fixture units of the connector.

## Syntax (C#)
```csharp
public double AssignedFixtureUnits { get; set; }
```

## Remarks
Assigned fixture units may be assigned for connectors of some family instances.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's domain is not DomainPiping.
Thrown when the connector is not in a family instance.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when set an invalid value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get or set assigned fixture units.

