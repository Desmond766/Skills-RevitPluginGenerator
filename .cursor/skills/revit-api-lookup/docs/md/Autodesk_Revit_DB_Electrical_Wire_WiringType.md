---
kind: property
id: P:Autodesk.Revit.DB.Electrical.Wire.WiringType
source: html/7a670559-0af9-8ed0-eee7-4afdff667b15.htm
---
# Autodesk.Revit.DB.Electrical.Wire.WiringType Property

The wiring type(arc or chamfer) for the wire.

## Syntax (C#)
```csharp
public WiringType WiringType { get; set; }
```

## Remarks
If the WiringType is arc, the shape of the wire depends on the number of points - it may be linear, a circular arc, or a spline.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

