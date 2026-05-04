---
kind: method
id: M:Autodesk.Revit.DB.Electrical.Wire.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Electrical.WiringType,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
zh: 创建、新建、生成、建立、新增
source: html/748caa8a-5792-91bf-dd3c-b62beba5efd3.htm
---
# Autodesk.Revit.DB.Electrical.Wire.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new wire.

## Syntax (C#)
```csharp
public static Wire Create(
	Document document,
	ElementId wireTypeId,
	ElementId viewId,
	WiringType wiringType,
	IList<XYZ> vertexPoints,
	Connector startConnectorTo,
	Connector endConnectorTo
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **wireTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the wire type of the newly created wire.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the wire is to be visible. This must be the id of a floor plan or reflected ceiling plan view.
- **wiringType** (`Autodesk.Revit.DB.Electrical.WiringType`) - Specifiies the wiring type for the newly created wire. The shape of the wire is determined by this value and the total number of points supplied via the vertexPoints and endpoint connectors. If the wiring type is WiringType.Arc:
 If there are 2 total points supplied, the wire is a straight-line wire. If there are 3 total points supplied, the wire is a circular arc wire. If there are 4 or more points, the wire is a spline wire. 
 If the wiring type is WiringType.Chamfer, a polyline wire will be created connecting all the points.
- **vertexPoints** (`System.Collections.Generic.IList < XYZ >`) - The vertex point of the wire.
 If the startConnectorTo is Nothing nullptr a null reference ( Nothing in Visual Basic) , the first vertex of the vertexPoints will be the start point, otherwise, the start connector origin will be the start point.
 If the endConnectorTo is Nothing nullptr a null reference ( Nothing in Visual Basic) , the last vertex of the vertexPoints will be the end point, otherwise, the end connector origin will be the end point.
- **startConnectorTo** (`Autodesk.Revit.DB.Connector`) - The connector to which the wire start point connects. If Nothing nullptr a null reference ( Nothing in Visual Basic) , the start point connects to no existing connector. If set with a connector, the connector's origin will be added to the wire's vertices as the start point.
- **endConnectorTo** (`Autodesk.Revit.DB.Connector`) - The connector to which the wire end point connects. If Nothing nullptr a null reference ( Nothing in Visual Basic) , the end point connects to no existing connector. If set with a connector, the connector's origin will be added to the wire's vertices as the end point.

## Returns
The wire created.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - wireTypeId is not a valid WireType id.
 -or-
 viewId does not represent a view valid for a Wire element. Either a floor plan or reflected ceiling plan is expected.
 -or-
 vertexPoints is not valid, because one or more points are coincident by comparing the X and Y of the points, or there are not at least two points including the connectors.
 -or-
 startConnectorTo cannot be connected to a wire, as it is not an electrical connector.
 -or-
 endConnectorTo cannot be connected to a wire, as it is not an electrical connector.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

