---
kind: property
id: P:Autodesk.Revit.DB.Floor.SpanDirectionAngle
zh: 楼板、板、地板
source: html/d029779d-cc65-5ed5-5ff1-a7abab977dc6.htm
---
# Autodesk.Revit.DB.Floor.SpanDirectionAngle Property

**中文**: 楼板、板、地板

Retrieve the span direction angle of the floor.

## Syntax (C#)
```csharp
public double SpanDirectionAngle { get; set; }
```

## Remarks
The angle returned is in radians. An exception will be thrown if the floor is non structural.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property:

