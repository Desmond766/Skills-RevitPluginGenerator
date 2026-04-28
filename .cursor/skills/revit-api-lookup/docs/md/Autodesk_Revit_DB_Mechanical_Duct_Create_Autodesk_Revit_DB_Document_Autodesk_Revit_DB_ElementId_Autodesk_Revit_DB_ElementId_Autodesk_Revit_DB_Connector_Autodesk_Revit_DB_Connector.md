---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.Duct.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
zh: 创建、新建、生成、建立、新增
source: html/d4a329e7-ba33-21dd-c281-2e1fa7ab71c7.htm
---
# Autodesk.Revit.DB.Mechanical.Duct.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new duct that connects to two connectors.

## Syntax (C#)
```csharp
public static Duct Create(
	Document document,
	ElementId ductTypeId,
	ElementId levelId,
	Connector startConnector,
	Connector endConnector
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **ductTypeId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the new duct type.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level ElementId for the new duct.
- **startConnector** (`Autodesk.Revit.DB.Connector`) - The first connector where the new duct starts.
- **endConnector** (`Autodesk.Revit.DB.Connector`) - The second point of the new duct.

## Returns
The created duct.

## Remarks
The new duct will have the same diameter and system type as the start connector. The creation will also connect the new duct
 to two component who owns the specified connectors. If necessary, additional fitting(s) are included to make a valid connection.
 If the new duct can not be connected to the next component (e.g., mismatched direction, no valid fitting, and etc), the new duct
 will still be created at the specified connector position, and an InvalidOperationException is thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The duct type ductTypeId is not valid duct type.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The connector's domain is not Domain.â€‹DomainHvac.
 -or-
 The points of startConnector and endConnector are too close: for MEPCurve, the minimum length is 1/10 inch.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the new duct fails to connect with the connector.

