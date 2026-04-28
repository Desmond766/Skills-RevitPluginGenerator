---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtTee(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
source: html/c2ef008e-636e-8ec8-4a8a-42d5996e037e.htm
---
# Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtTee Method

Connects three placeholders that looks like Tee connection.

## Syntax (C#)
```csharp
public static bool ConnectPipePlaceholdersAtTee(
	Document document,
	Connector connector1,
	Connector connector2,
	Connector connector3
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **connector1** (`Autodesk.Revit.DB.Connector`) - The first end connector of placeholder to be connected to the second.
- **connector2** (`Autodesk.Revit.DB.Connector`) - The second end connector of placeholder to be connected to the first.
- **connector3** (`Autodesk.Revit.DB.Connector`) - The third end connector of placeholder to be connected to the first or second.

## Returns
True if connection succeeds, false otherwise.

## Remarks
The three placeholders may or may not have physically connections. However,
 the first one should be collinear with the second and third one must have
 intersection with first and second.
 If first placeholder and second placeholder have the same size, the second one
 is merged with first one and original placeholder element will be invalid.
 If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The owner of connector is not pipe placeholder.
 -or-
 The owners of connectors belong to different types of system.
 -or-
 The curves of connector1 and connector2 are not collinear or either the connecto1 or connector2 is not connector of curve end.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

