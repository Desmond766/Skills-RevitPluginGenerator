---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtCross(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
source: html/2f099ebb-ef3b-4502-835f-349a10efb04b.htm
---
# Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtCross Method

Connects placeholders that looks like Cross connection.

## Syntax (C#)
```csharp
public static bool ConnectPipePlaceholdersAtCross(
	Document document,
	Connector connector1,
	Connector connector2,
	Connector connector3,
	Connector connector4
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **connector1** (`Autodesk.Revit.DB.Connector`) - The first end connector of placeholder to be connected to the second.
- **connector2** (`Autodesk.Revit.DB.Connector`) - The second end connector of placeholder to be connected to the first.
- **connector3** (`Autodesk.Revit.DB.Connector`) - The third end connector of placeholder to be connected to the forth.
- **connector4** (`Autodesk.Revit.DB.Connector`) - The fourth end connector of placeholder to be connected to the third.

## Returns
True if connection succeeds, false otherwise.

## Remarks
The placeholders may or may not have physical connection. However
 a) The ends of four connectors should intersect at same point;
 b) the first and second placeholders should be collinear each other;
 c) the third and fourth placeholders should be collinear each other and
 d) the third and fourth should have intersection with first or second placeholder.
 If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The owner of connector is not pipe placeholder.
 -or-
 The owners of connectors belong to different types of system.
 -or-
 The curves of connector1 and connector2 are not collinear or either the connecto1 or connector2 is not connector of curve end.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

