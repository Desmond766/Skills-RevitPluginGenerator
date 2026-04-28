---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.Pipe.IsPipingConnector(Autodesk.Revit.DB.Connector)
zh: 管道、水管、管线
source: html/ef930ad5-4d7e-2fb6-441e-ff3c2a8681f8.htm
---
# Autodesk.Revit.DB.Plumbing.Pipe.IsPipingConnector Method

**中文**: 管道、水管、管线

Checks if the given connector is a valid piping connector.

## Syntax (C#)
```csharp
public static bool IsPipingConnector(
	Connector connector
)
```

## Parameters
- **connector** (`Autodesk.Revit.DB.Connector`) - Connector to check

## Returns
True if the connector has the Piping domain type.

## Remarks
A connector must be Piping domain type to be connected with other pipes.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

