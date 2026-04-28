---
kind: property
id: P:Autodesk.Revit.DB.Connector.Coefficient
zh: 连接件、接口
source: html/b0bc0f95-1312-cfbf-9590-926c7a4669a4.htm
---
# Autodesk.Revit.DB.Connector.Coefficient Property

**中文**: 连接件、接口

The coefficient of the connector.

## Syntax (C#)
```csharp
public double Coefficient { get; }
```

## Remarks
Instantaneous coefficient of this connector, calculated according to system.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This connector does not support flow calculation and associated properties.

