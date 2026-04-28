---
kind: property
id: P:Autodesk.Revit.DB.Connector.Direction
zh: 连接件、接口
source: html/2b1dc55a-6597-7143-4af9-6e92e4c4d024.htm
---
# Autodesk.Revit.DB.Connector.Direction Property

**中文**: 连接件、接口

The direction of the connector.

## Syntax (C#)
```csharp
public FlowDirectionType Direction { get; }
```

## Remarks
Instantaneous direction of this connector, calculated according to system.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This connector does not support flow calculation and associated properties.

