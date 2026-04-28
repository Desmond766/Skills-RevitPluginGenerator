---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtElbow(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
source: html/5beafb2e-8863-6602-7c5f-38daa3a69a81.htm
---
# Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConnectPipePlaceholdersAtElbow Method

Connects placeholders that looks like elbow connection.

## Syntax (C#)
```csharp
public static bool ConnectPipePlaceholdersAtElbow(
	Document document,
	Connector connector1,
	Connector connector2
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **connector1** (`Autodesk.Revit.DB.Connector`) - The first end connector of placeholder to be connected to.
- **connector2** (`Autodesk.Revit.DB.Connector`) - The second end connector of placeholder to be connected to.

## Returns
True if connection succeeds, false otherwise.

## Remarks
The placeholders may have physical connection or may not connect at all.
 In the latter case, the first one connects to the end of second one.
 If connection fails, the placeholders cannot be physically connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The owner of connector is not pipe placeholder.
 -or-
 The owners of connectors belong to different types of system.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

