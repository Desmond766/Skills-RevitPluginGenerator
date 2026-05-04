---
kind: property
id: P:Autodesk.Revit.DB.Connector.Flow
zh: 连接件、接口
source: html/9e4a6207-9f27-e5bf-8bf9-be19d1923680.htm
---
# Autodesk.Revit.DB.Connector.Flow Property

**中文**: 连接件、接口

The flow of the connector.

## Syntax (C#)
```csharp
public double Flow { get; }
```

## Remarks
Instantaneous flow at this connector, calculated according to system.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This connector does not support flow calculation and associated properties.

