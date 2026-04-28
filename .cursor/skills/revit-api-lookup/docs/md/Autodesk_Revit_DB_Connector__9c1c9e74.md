---
kind: type
id: T:Autodesk.Revit.DB.Connector
zh: 连接件、接口
source: html/11e07082-b3f2-26a1-de79-16535f44716c.htm
---
# Autodesk.Revit.DB.Connector

**中文**: 连接件、接口

A connector in an Autodesk Revit MEP project document.

## Syntax (C#)
```csharp
public class Connector : IConnector, IDisposable
```

## Remarks
This connector is an item that is a part of another element (duct, pipe, fitting, or equipment etc.).
 This connector does not represent the connector element that can be created inside a family;
 for that element, refer to ConnectorElement .

