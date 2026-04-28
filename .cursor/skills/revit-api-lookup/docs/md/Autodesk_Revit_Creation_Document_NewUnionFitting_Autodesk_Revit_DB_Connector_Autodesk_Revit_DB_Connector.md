---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewUnionFitting(Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
zh: 文档、文件
source: html/84596c17-3a5a-74f5-e050-98ab3b15dd5b.htm
---
# Autodesk.Revit.Creation.Document.NewUnionFitting Method

**中文**: 文档、文件

Add a new family instance of an union fitting into the Autodesk Revit document,
using two connectors.

## Syntax (C#)
```csharp
public FamilyInstance NewUnionFitting(
	Connector connector1,
	Connector connector2
)
```

## Parameters
- **connector1** (`Autodesk.Revit.DB.Connector`) - The first connector to be connected to the union.
- **connector2** (`Autodesk.Revit.DB.Connector`) - The second connector to be connected to the union.

## Returns
If creation was successful then an family instance to the new object is returned,
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument connector1 or connector2 is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the connectors cannot be used for union creation. For example, 
they cannot be from the same element, they must be of the same domain and shape, 
and the owner of the connector1 should be a (flex) duct or pipe.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when union fitting cannot be created.

