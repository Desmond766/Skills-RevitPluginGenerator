---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewPipingSystem(Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.ConnectorSet,Autodesk.Revit.DB.Plumbing.PipeSystemType)
zh: 文档、文件
source: html/ce8ca4d6-8fb3-fe68-c5e3-6970c00a9a2b.htm
---
# Autodesk.Revit.Creation.Document.NewPipingSystem Method

**中文**: 文档、文件

Creates a new MEP piping system element.

## Syntax (C#)
```csharp
public PipingSystem NewPipingSystem(
	Connector baseEquipmentConnector,
	ConnectorSet connectors,
	PipeSystemType pipingSystemType
)
```

## Parameters
- **baseEquipmentConnector** (`Autodesk.Revit.DB.Connector`) - One connector within base equipment which is used to connect with the system. 
The base equipment is optional for the system, so this argument may be Nothing nullptr a null reference ( Nothing in Visual Basic) .
The baseEquipmentConnector should not be included in the connectors.
- **connectors** (`Autodesk.Revit.DB.ConnectorSet`) - Connectors that will connect to the system.
The owner elements of these connectors will be added into system as its elements.
- **pipingSystemType** (`Autodesk.Revit.DB.Plumbing.PipeSystemType`) - The System type.

## Returns
If creation was successful then an instance of piping system is returned, 
otherwise an exception with information will be thrown.

## Remarks
This method will regenerate the document even in manual regeneration mode.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when calling this function outside of the Autodesk Revit MEP product.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the connectors parameter value is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the pipingSystemType parameter value is out of permitted scope.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when some connectors can't be used to create the mechanical system.
All the input connectors and base equipment connector should match system type and domain with the system,
and they should not have been used in another system.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the piping system creation failed.

