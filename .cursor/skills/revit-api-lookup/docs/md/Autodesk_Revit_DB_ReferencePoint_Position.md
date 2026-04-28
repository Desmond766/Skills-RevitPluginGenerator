---
kind: property
id: P:Autodesk.Revit.DB.ReferencePoint.Position
source: html/4f540b05-f562-8a72-37ef-834d45cea027.htm
---
# Autodesk.Revit.DB.ReferencePoint.Position Property

The position of the ReferencePoint.

## Syntax (C#)
```csharp
public XYZ Position { get; set; }
```

## Remarks
This is an alternate interface to the property
CoordinateSystem.Origin. When set, the effect is the same
as setting the CoordinateSystem property to the same as
its current value but with a different Origin.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when CoordinateSystem is set while the Reference 
property is not Nothing nullptr a null reference ( Nothing in Visual Basic) , and the ReferencePoint is unable to
move to the new location.

