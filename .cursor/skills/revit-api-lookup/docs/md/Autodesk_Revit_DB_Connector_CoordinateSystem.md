---
kind: property
id: P:Autodesk.Revit.DB.Connector.CoordinateSystem
zh: 连接件、接口
source: html/cb6d725d-654a-f6f3-fed0-96cc618a42f1.htm
---
# Autodesk.Revit.DB.Connector.CoordinateSystem Property

**中文**: 连接件、接口

The coordinate system of the connector.

## Syntax (C#)
```csharp
public virtual Transform CoordinateSystem { get; }
```

## Remarks
The coordinate system's origin is the location of the connector 
and the Z-axis is normal to the connector.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector is of logical type.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to get coordinate system.

