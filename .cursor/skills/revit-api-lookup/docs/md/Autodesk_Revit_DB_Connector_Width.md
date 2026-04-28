---
kind: property
id: P:Autodesk.Revit.DB.Connector.Width
zh: 宽度
source: html/adcdacef-bad0-6dab-fe3c-944add943d18.htm
---
# Autodesk.Revit.DB.Connector.Width Property

**中文**: 宽度

The width of the connector.

## Syntax (C#)
```csharp
public virtual double Width { get; set; }
```

## Remarks
In order to set this property, it must be mapped to a writable instance parameter in the family definition.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's shape is not rectangular.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the argument is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to set width.

