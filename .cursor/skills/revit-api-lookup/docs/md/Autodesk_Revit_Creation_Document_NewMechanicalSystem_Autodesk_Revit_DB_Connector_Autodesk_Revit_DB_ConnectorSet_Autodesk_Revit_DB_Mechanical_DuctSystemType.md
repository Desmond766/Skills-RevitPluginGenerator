---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewMechanicalSystem(Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.ConnectorSet,Autodesk.Revit.DB.Mechanical.DuctSystemType)
zh: 文档、文件
source: html/d9d6fd18-6cf3-d7d3-31a1-d7d7ef45cfa0.htm
---
# Autodesk.Revit.Creation.Document.NewMechanicalSystem Method

**中文**: 文档、文件

Creates a new MEP mechanical system element.

## Syntax (C#)
```csharp
public MechanicalSystem NewMechanicalSystem(
	Connector baseEquipmentConnector,
	ConnectorSet connectors,
	DuctSystemType ductSystemType
)
```

## Parameters
- **baseEquipmentConnector** (`Autodesk.Revit.DB.Connector`) - One connector within base equipment which is used to connect with the system. 
The base equipment is optional for the system, so this argument may be Nothing nullptr a null reference ( Nothing in Visual Basic) .
The baseEquipmentConnector should not be included in the connectors.
- **connectors** (`Autodesk.Revit.DB.ConnectorSet`) - Connectors that will connect to the system.
The owner elements of these connectors will be added into system as its elements.
- **ductSystemType** (`Autodesk.Revit.DB.Mechanical.DuctSystemType`) - The system type.

## Returns
If creation was successful then an instance of mechanical system is returned, 
otherwise an exception with information will be thrown.

## Remarks
This method will regenerate the document even in manual regeneration mode.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when calling this function outside of the Autodesk Revit MEP product.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input connectors parameter value is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the ductSystemType parameter is out of permitted scope.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when some connectors can't be used to create the mechanical system.
All the input connectors and base equipment connector should match system type and domain with the system,
and they should not have been used in another system.
The owner of BaseConnector should be a mechanical equipment, and the owner of other connectors should be a mechanical equipment or air terminal.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the mechanical system creation failed.

