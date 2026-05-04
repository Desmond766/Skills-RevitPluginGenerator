---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtTee(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
source: html/2743d178-a9ab-3c11-6ccc-78ccbc5f7f13.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtTee Method

Connects a trio of placeholders that can intersect in a Tee connection.

## Syntax (C#)
```csharp
public static bool ConnectDuctPlaceholdersAtTee(
	Document document,
	Connector connector1,
	Connector connector2,
	Connector connector3
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **connector1** (`Autodesk.Revit.DB.Connector`) - The end connector of the first placeholder.
- **connector2** (`Autodesk.Revit.DB.Connector`) - The end connector of second placeholder.
- **connector3** (`Autodesk.Revit.DB.Connector`) - The end connector of the third placeholder.

## Returns
True if connection succeeds, false otherwise.

## Remarks
The three placeholders may or may not have physical connections. However,
 the first connector should be collinear with the second connector, and the third connector must have
 be able to be extended to have an intersection with first and second.
 If first placeholder and second placeholder have the same size, the second one
 is merged with first one and original placeholder element will become invalid.
 If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The owner of connector is not duct placeholder.
 -or-
 The owners of connectors belong to different types of system.
 -or-
 The curves of connector1 and connector2 are not collinear or either the connecto1 or connector2 is not connector of curve end.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

