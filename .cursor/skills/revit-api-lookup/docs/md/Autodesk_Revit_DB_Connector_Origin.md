---
kind: property
id: P:Autodesk.Revit.DB.Connector.Origin
zh: 原点
source: html/28a9cf5e-9191-f9ce-74c8-622a681201f6.htm
---
# Autodesk.Revit.DB.Connector.Origin Property

**中文**: 原点

The location of the connector.

## Syntax (C#)
```csharp
public virtual XYZ Origin { get; set; }
```

## Remarks
Changing the location of the connector may lead to changes of location
 and geometry for the connector's host element and the hosts for other elements 
 the element is connected to.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when connector's type is NonEndConn.
Thrown when the connector is a part of a family instance.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the assigned origin is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to set origin.

