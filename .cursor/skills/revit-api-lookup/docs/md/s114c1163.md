---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarHookType.HookAngle
source: html/85af7224-b751-4c40-a5d5-5b4dc757f742.htm
---
# Autodesk.Revit.DB.Structure.RebarHookType.HookAngle Property

The hook angle, measured in radians. Must be greater than 0 and no more than pi.

## Syntax (C#)
```csharp
public double HookAngle { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for hookAngle is not a number
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: hookAngle must be greater than 0 and no more than pi.

