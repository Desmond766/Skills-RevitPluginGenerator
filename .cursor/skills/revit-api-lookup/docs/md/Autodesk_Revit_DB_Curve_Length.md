---
kind: property
id: P:Autodesk.Revit.DB.Curve.Length
zh: 长度
source: html/c6bca686-f136-ce45-8668-8d430267cd0d.htm
---
# Autodesk.Revit.DB.Curve.Length Property

**中文**: 长度

The exact length of the curve.

## Syntax (C#)
```csharp
public double Length { get; }
```

## Remarks
Computes the length of the curve using analytical or numeric
integration. There is no performance hit for lines and arcs.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the curve is unbound and not periodic.

