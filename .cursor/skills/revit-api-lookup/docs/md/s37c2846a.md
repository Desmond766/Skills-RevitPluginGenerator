---
kind: property
id: P:Autodesk.Revit.DB.Connector.PressureDrop
zh: 连接件、接口
source: html/7a7cd52e-4c83-68fe-acf1-d3ebd49422f8.htm
---
# Autodesk.Revit.DB.Connector.PressureDrop Property

**中文**: 连接件、接口

The pressure drop of the connector.

## Syntax (C#)
```csharp
public double PressureDrop { get; }
```

## Remarks
Instantaneous pressure drop of this connector, calculated according to system.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This connector does not support flow calculation and associated properties.

