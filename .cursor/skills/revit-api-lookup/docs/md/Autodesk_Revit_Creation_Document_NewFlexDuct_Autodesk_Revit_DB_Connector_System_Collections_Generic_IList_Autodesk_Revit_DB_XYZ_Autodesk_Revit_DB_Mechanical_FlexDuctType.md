---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewFlexDuct(Autodesk.Revit.DB.Connector,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},Autodesk.Revit.DB.Mechanical.FlexDuctType)
zh: 文档、文件
source: html/3f73b205-4121-eb63-c6de-d31fd1c74be7.htm
---
# Autodesk.Revit.Creation.Document.NewFlexDuct Method

**中文**: 文档、文件

Adds a new flexible duct into the document, 
using a connector, point array and duct type.

## Syntax (C#)
```csharp
public FlexDuct NewFlexDuct(
	Connector connector,
	IList<XYZ> points,
	FlexDuctType ductType
)
```

## Parameters
- **connector** (`Autodesk.Revit.DB.Connector`) - The connector to be connected to the duct, including the end points.
- **points** (`System.Collections.Generic.IList < XYZ >`) - The point array indicating the path of the flexible duct.
- **ductType** (`Autodesk.Revit.DB.Mechanical.FlexDuctType`) - The type of the flexible duct.

## Returns
If creation was successful then a new flexible duct is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
If the connector is a fitting or equipment connector of the correct domain, 
and if the connector's direction matches the direction of the flexible duct to be created, 
the connectors will be automatically connected. A transition fitting will be added 
at the connector(s) if necessary. If the connector's type, domain, 
does not match the one of the input connector, no connection will be established.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument connector or points is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the flexible duct cannot be created or regenerate fails.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the flexible duct type does not exist in the given document.

