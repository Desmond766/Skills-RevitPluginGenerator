---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewTeeFitting(Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
zh: 文档、文件
source: html/c261a205-f1fc-8552-6e8f-8c81186b6b6d.htm
---
# Autodesk.Revit.Creation.Document.NewTeeFitting Method

**中文**: 文档、文件

Add a new family instance of a tee fitting into the Autodesk Revit document,
using three connectors.

## Syntax (C#)
```csharp
public FamilyInstance NewTeeFitting(
	Connector connector1,
	Connector connector2,
	Connector connector3
)
```

## Parameters
- **connector1** (`Autodesk.Revit.DB.Connector`) - The first connector to be connected to the tee.
- **connector2** (`Autodesk.Revit.DB.Connector`) - The second connector to be connected to the tee.
- **connector3** (`Autodesk.Revit.DB.Connector`) - The third connector to be connected to the tee. 
This should be connected to the branch of the tee.

## Returns
If creation was successful then an family instance to the new object is returned,
and the transition fitting will be added at the connectors' end if necessary, 
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument connector1, connector2 or connector3 is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the connectors cannot be used for the tee creation. For example, 
they cannot be from the same element, they must be of the same domain, 
and the owner of the connectors should be a (flex) duct or pipe.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when tee fitting cannot be created.

