---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewElbowFitting(Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
zh: 文档、文件
source: html/6f206b7d-f982-bdbd-8342-ed99719e9d81.htm
---
# Autodesk.Revit.Creation.Document.NewElbowFitting Method

**中文**: 文档、文件

Add a new family instance of an elbow fitting into the Autodesk Revit document,
using two connectors.

## Syntax (C#)
```csharp
public FamilyInstance NewElbowFitting(
	Connector connector1,
	Connector connector2
)
```

## Parameters
- **connector1** (`Autodesk.Revit.DB.Connector`) - The first connector to be connected to the elbow.
- **connector2** (`Autodesk.Revit.DB.Connector`) - The second connector to be connected to the elbow.

## Returns
If creation was successful then an family instance to the new object is returned,
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument connector1 or connector2 is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the connectors cannot be used for the elbow creation. For example, 
they cannot be from the same element, they must be of the same domain, 
and the angle between them must fall within the valid range (typically 2 to 95 degrees).
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when an elbow fitting cannot be created because the angle between the two connectors is too large or too small,
the connectors are not close enough together, or the connectors are placed at positions with too high of a tolerance.

