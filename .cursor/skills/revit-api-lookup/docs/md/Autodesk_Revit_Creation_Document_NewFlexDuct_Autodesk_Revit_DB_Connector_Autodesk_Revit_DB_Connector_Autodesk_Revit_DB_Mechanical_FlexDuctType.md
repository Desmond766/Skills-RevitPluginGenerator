---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewFlexDuct(Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Mechanical.FlexDuctType)
zh: 文档、文件
source: html/0910f241-d976-2ee8-496d-268a44725d13.htm
---
# Autodesk.Revit.Creation.Document.NewFlexDuct Method

**中文**: 文档、文件

Adds a new flexible duct into the document, 
using two connector, and duct type.

## Syntax (C#)
```csharp
public FlexDuct NewFlexDuct(
	Connector connector1,
	Connector connector2,
	FlexDuctType ductType
)
```

## Parameters
- **connector1** (`Autodesk.Revit.DB.Connector`) - The first connector to be connected to the duct.
- **connector2** (`Autodesk.Revit.DB.Connector`) - The second connector to be connected to the duct.
- **ductType** (`Autodesk.Revit.DB.Mechanical.FlexDuctType`) - The type of the flexible duct.

## Returns
If creation was successful then a new flexible duct is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
If the connectors are fitting or equipment connectors of the correct domain, 
and if the connectors' direction match the direction of the flexible duct to be created, 
the connectors will be automatically connected. A transition fitting will be added 
at the connector(s) if necessary. If the connector's type, domain, 
does not match the one of the input connector, no connection will be established.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument connector1 or connector2 is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the flexible duct cannot be created or regenerate fails.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the flexible duct type does not exist in the given document.

