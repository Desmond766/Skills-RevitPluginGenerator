---
kind: method
id: M:Autodesk.Revit.DB.Connector.ConnectTo(Autodesk.Revit.DB.Connector)
zh: 连接件、接口
source: html/04ee99c9-f411-aabe-7b87-013a6f9adb1d.htm
---
# Autodesk.Revit.DB.Connector.ConnectTo Method

**中文**: 连接件、接口

Make connection between two connectors.

## Syntax (C#)
```csharp
public void ConnectTo(
	Connector connector
)
```

## Parameters
- **connector** (`Autodesk.Revit.DB.Connector`) - Indicate the connector will be connected to.

## Remarks
Connection success may create a new Fitting between two connectors, if necessary.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Argument is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when two connectors with different domain types.
Thrown when these two connectors fail to connect each other.
Thrown when connection already exists.

