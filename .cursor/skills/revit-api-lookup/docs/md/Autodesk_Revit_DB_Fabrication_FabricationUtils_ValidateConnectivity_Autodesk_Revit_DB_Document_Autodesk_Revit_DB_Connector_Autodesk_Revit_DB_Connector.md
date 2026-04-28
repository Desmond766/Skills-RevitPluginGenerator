---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationUtils.ValidateConnectivity(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
source: html/22945910-13a4-38dc-5c63-01aedf362000.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationUtils.ValidateConnectivity Method

Check if two connectors are valid to connect directly without couplings.

## Syntax (C#)
```csharp
public static bool ValidateConnectivity(
	Document document,
	Connector connector1,
	Connector connector2
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **connector1** (`Autodesk.Revit.DB.Connector`) - First connector to check.
- **connector2** (`Autodesk.Revit.DB.Connector`) - Second connector to check against.

## Returns
True if connection is valid otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

