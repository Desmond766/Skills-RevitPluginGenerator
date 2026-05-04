---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewCrossFitting(Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
zh: 文档、文件
source: html/f8175e3f-31d3-7342-054c-4911a239531d.htm
---
# Autodesk.Revit.Creation.Document.NewCrossFitting Method

**中文**: 文档、文件

Add a new family instance of a cross fitting into the Autodesk Revit document,
using four connectors.

## Syntax (C#)
```csharp
public FamilyInstance NewCrossFitting(
	Connector connector1,
	Connector connector2,
	Connector connector3,
	Connector connector4
)
```

## Parameters
- **connector1** (`Autodesk.Revit.DB.Connector`) - The first connector to be connected to the cross.
- **connector2** (`Autodesk.Revit.DB.Connector`) - The second connector to be connected to the cross.
- **connector3** (`Autodesk.Revit.DB.Connector`) - The third connector to be connected to the cross.
- **connector4** (`Autodesk.Revit.DB.Connector`) - The fourth connector to be connected to the cross.

## Returns
If creation was successful then an family instance to the new object is returned,
and the transition fitting will be added at the connectors' end if necessary, 
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument connector1, connector2, connector3, or connector4 is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the connectors cannot be used for cross creation. For example, 
they cannot be from the same element, they must be of the same domain, 
and the owner of the connectors should be a (flex) duct or pipe.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when cross fitting cannot be created.

