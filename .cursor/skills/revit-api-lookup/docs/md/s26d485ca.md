---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewTakeoffFitting(Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.MEPCurve)
zh: 文档、文件
source: html/9aef4be8-349b-ee4c-c1bc-b41d6211c79c.htm
---
# Autodesk.Revit.Creation.Document.NewTakeoffFitting Method

**中文**: 文档、文件

Add a new family instance of an takeoff fitting into the Autodesk Revit document,
using one connector and one MEP curve.

## Syntax (C#)
```csharp
public FamilyInstance NewTakeoffFitting(
	Connector connector,
	MEPCurve curve
)
```

## Parameters
- **connector** (`Autodesk.Revit.DB.Connector`) - The connector to be connected to the takeoff.
- **curve** (`Autodesk.Revit.DB.MEPCurve`) - The duct or pipe which is the trunk for the takeoff.

## Returns
If creation was successful then an family instance to the new object is returned,
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument connector1 or curve is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the connector and the curve cannot be used for takeoff creation. For example, 
they must be of the same domain, the curve must be a duct or pipe, 
and the owner of the connector should be (flex) duct or pipe.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when takeoff fitting cannot be created.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the curve does not exist in the given document.

