---
kind: property
id: P:Autodesk.Revit.DB.Connector.VelocityPressure
zh: 连接件、接口
source: html/e355642e-38a3-7dda-b752-91a24498c2b1.htm
---
# Autodesk.Revit.DB.Connector.VelocityPressure Property

**中文**: 连接件、接口

The velocity pressure of the connector.

## Syntax (C#)
```csharp
public double VelocityPressure { get; }
```

## Remarks
Instantaneous velocity pressure of this connector,calculated according to system.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This connector does not support flow calculation and associated properties.

