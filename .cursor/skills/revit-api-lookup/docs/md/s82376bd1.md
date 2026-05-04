---
kind: method
id: M:Autodesk.Revit.DB.Fabrication.FabricationPartRouteEnd.CreateFromConnector(Autodesk.Revit.DB.Connector)
source: html/14cf7184-74dd-8f5b-39ab-58a389056cf5.htm
---
# Autodesk.Revit.DB.Fabrication.FabricationPartRouteEnd.CreateFromConnector Method

Create fabrication routing end from connector end point.

## Syntax (C#)
```csharp
public static FabricationPartRouteEnd CreateFromConnector(
	Connector connnector
)
```

## Parameters
- **connnector** (`Autodesk.Revit.DB.Connector`) - The connector that the route will connect to. The connector cannot have an existing connection.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Connector is connected.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

