---
kind: property
id: P:Autodesk.Revit.DB.Connector.Height
zh: 高度
source: html/e3c75767-f737-eed3-a19f-b7f98a9e7b65.htm
---
# Autodesk.Revit.DB.Connector.Height Property

**中文**: 高度

The height of the connector.

## Syntax (C#)
```csharp
public virtual double Height { get; set; }
```

## Remarks
In order to set this property, it must be mapped to a writable instance parameter in the family definition.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the connector's shape is not rectangular.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the argument is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown on failure to set height.

