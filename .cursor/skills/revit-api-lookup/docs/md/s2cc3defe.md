---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.Duct.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/9d345e78-2051-1452-e9b4-34432fb91088.htm
---
# Autodesk.Revit.DB.Mechanical.Duct.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new duct that connects to the connector.

## Syntax (C#)
```csharp
public static Duct Create(
	Document document,
	ElementId ductTypeId,
	ElementId levelId,
	Connector startConnector,
	XYZ endPoint
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **ductTypeId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the new duct type.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level id for the new duct.
- **startConnector** (`Autodesk.Revit.DB.Connector`) - The first connector where the new duct starts.
- **endPoint** (`Autodesk.Revit.DB.XYZ`) - The second point of the new duct.

## Returns
The created duct.

## Remarks
The new duct will have the same diameter and system type as the specified connector. The creation will also connect the new duct
 to the component who owns the specified connector. If necessary, additional fitting(s) are included to make a valid connection.
 If the new duct can not be connected to the next component (e.g., mismatched direction, no valid fitting, and etc), the new duct
 will still be created at the specified connector position, and an InvalidOperationException is thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The duct type ductTypeId is not valid duct type.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The connector's domain is not Domain.â€‹DomainHvac.
 -or-
 The points of startConnector and endPoint are too close: for MEPCurve, the minimum length is 1/10 inch.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the new duct fails to connect with the connector.

