---
kind: property
id: P:Autodesk.Revit.DB.Connector.Radius
zh: 连接件、接口
source: html/92e32588-26c0-9330-b079-86ae46d705bd.htm
---
# Autodesk.Revit.DB.Connector.Radius Property

**中文**: 连接件、接口

The radius of the connector.

## Syntax (C#)
```csharp
public virtual double Radius { get; set; }
```

## Remarks
In order to set this property, it must be mapped to a writable instance parameter in the family definition.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's shape is not round.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the argument is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to set radius.

