---
kind: method
id: M:Autodesk.Revit.DB.MEPAnalyticalConnection.CanSupportAnalyticalConnection(Autodesk.Revit.DB.Connector)
source: html/3058b8d3-5282-d69a-8173-b7f5dfce712c.htm
---
# Autodesk.Revit.DB.MEPAnalyticalConnection.CanSupportAnalyticalConnection Method

Checks if the connector can support the analytical connection.

## Syntax (C#)
```csharp
public static bool CanSupportAnalyticalConnection(
	Connector connector
)
```

## Parameters
- **connector** (`Autodesk.Revit.DB.Connector`) - The testing connector.

## Returns
True if the connector can support the network flow/pressure analysis, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

