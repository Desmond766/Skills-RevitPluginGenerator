---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalSystem.Length
zh: 长度
source: html/02858191-a544-82e6-faeb-0b59fd5c7ee8.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.Length Property

**中文**: 长度

The Length value of the Electrical System.

## Syntax (C#)
```csharp
public double Length { get; }
```

## Remarks
This property is used to retrieve the Length value of the Electrical System.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the length cannot be computed, because it is zero, or because the circuit is not connected to a panel.

