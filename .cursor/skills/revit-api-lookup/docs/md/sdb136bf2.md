---
kind: method
id: M:Autodesk.Revit.DB.MEPAnalyticalConnection.CreateMultipleConnections(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Collections.Generic.IList{Autodesk.Revit.DB.Connector},System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/4e4285fa-20e3-c1af-2981-f484831e1c90.htm
---
# Autodesk.Revit.DB.MEPAnalyticalConnection.CreateMultipleConnections Method

Creates new analytical connections between the equipment connector and the nearest point on the curves.

## Syntax (C#)
```csharp
public static ISet<ElementId> CreateMultipleConnections(
	Document doc,
	ElementId typeId,
	IList<Connector> equipmentOpenConnectors,
	IList<ElementId> curveIdsToConnect
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document where the new elements are created.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The type of new analytical connections.
- **equipmentOpenConnectors** (`System.Collections.Generic.IList < Connector >`) - The open equipment connectors to be analytically connected.
- **curveIdsToConnect** (`System.Collections.Generic.IList < ElementId >`) - The curves which the equipment is connected to.

## Returns
The new analytical connection elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Invalid connection type.
 -or-
 Not all connectors support the analytical connection.
 -or-
 No connector included.
 -or-
 Not all elements are valid curve ids.
 -or-
 No curve included.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

