---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewTransitionFitting(Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
zh: 文档、文件
source: html/1dcbaa41-5881-b807-b333-10855acb408e.htm
---
# Autodesk.Revit.Creation.Document.NewTransitionFitting Method

**中文**: 文档、文件

Add a new family instance of an transition fitting into the Autodesk Revit document,
using two connectors.

## Syntax (C#)
```csharp
public FamilyInstance NewTransitionFitting(
	Connector connector1,
	Connector connector2
)
```

## Parameters
- **connector1** (`Autodesk.Revit.DB.Connector`) - The first connector to be connected to the transition.
- **connector2** (`Autodesk.Revit.DB.Connector`) - The second connector to be connected to the transition.

## Returns
If creation was successful then an family instance to the new object is returned,
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument connector1 or connector2 is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the connectors cannot be used for transition creation. For example, 
they cannot be from the same element, they must be of the same domain, 
and the owner of connector1 should be a (flex) duct or pipe.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when transition fitting cannot be created.

