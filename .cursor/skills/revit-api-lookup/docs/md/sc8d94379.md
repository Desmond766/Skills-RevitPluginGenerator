---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtCross(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
source: html/c97c477a-5d60-4a9d-e7d5-5987b5d4ccbc.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtCross Method

Connects a group of placeholders that can intersect in a Cross connection.

## Syntax (C#)
```csharp
public static bool ConnectDuctPlaceholdersAtCross(
	Document document,
	Connector connector1,
	Connector connector2,
	Connector connector3,
	Connector connector4
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **connector1** (`Autodesk.Revit.DB.Connector`) - The end connector of the first placeholder.
- **connector2** (`Autodesk.Revit.DB.Connector`) - The end connector of the second placeholder.
- **connector3** (`Autodesk.Revit.DB.Connector`) - The end connector of the third placeholder.
- **connector4** (`Autodesk.Revit.DB.Connector`) - The end connector of the fourth placeholder.

## Returns
True if connection succeeds, false otherwise.

## Remarks
The placeholders may or may not have physical connection. However:
 The ends of four connectors should intersect at same point. The first and second placeholders should be collinear each other. The third and fourth placeholders should be collinear each other. The third and fourth should have intersection with first or second placeholder. 
 If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The owner of connector is not duct placeholder.
 -or-
 The owners of connectors belong to different types of system.
 -or-
 The curves of connector1 and connector2 are not collinear or either the connecto1 or connector2 is not connector of curve end.
 -or-
 The curves of connector3 and connector4 are not collinear or either the connecto1 or connector2 is not connector of curve end.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

