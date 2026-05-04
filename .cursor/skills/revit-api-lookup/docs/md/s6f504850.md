---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtElbow(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
source: html/e588f46f-f3bd-ce92-5f0e-297c2f30ecf1.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectDuctPlaceholdersAtElbow Method

Connects a pair of placeholders that can intersect in an Elbow connection.

## Syntax (C#)
```csharp
public static bool ConnectDuctPlaceholdersAtElbow(
	Document document,
	Connector connector1,
	Connector connector2
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **connector1** (`Autodesk.Revit.DB.Connector`) - The end connector of the first placeholder.
- **connector2** (`Autodesk.Revit.DB.Connector`) - The end connector of the second placeholder.

## Returns
True if connection succeeds, false otherwise.

## Remarks
The placeholders may have a physical intersection but this is not required.
 If they are not intersecting the connectors must be coplanar and able to be moved to
 intersect each other.
 If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The owner of connector is not duct placeholder.
 -or-
 The owners of connectors belong to different types of system.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

