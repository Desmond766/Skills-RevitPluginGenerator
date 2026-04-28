---
kind: method
id: M:Autodesk.Revit.DB.MEPAnalyticalConnection.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
zh: 创建、新建、生成、建立、新增
source: html/68e973e2-ae44-6a82-1d88-e526c60aea75.htm
---
# Autodesk.Revit.DB.MEPAnalyticalConnection.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new analytical connection between two open connectors.

## Syntax (C#)
```csharp
public static MEPAnalyticalConnection Create(
	Document doc,
	ElementId typeId,
	Connector startConnector,
	Connector endConnector
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document where the new element is created.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The type of new analytical connection.
- **startConnector** (`Autodesk.Revit.DB.Connector`) - The open connector on the equipment side, whose level is inherited by the analytical connection.
- **endConnector** (`Autodesk.Revit.DB.Connector`) - The open connector on the network.

## Returns
The newly created analytical connection element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Invalid connection type.
 -or-
 The connector does not support analytical connection.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

