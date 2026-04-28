---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalSystem.Frame
source: html/162d8eee-6d8c-593f-ad56-1a93aea30540.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.Frame Property

The Frame value of the Electrical System.

## Syntax (C#)
```csharp
public double Frame { get; set; }
```

## Remarks
This property is used to retrieve the Frame value of the Electrical System.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for frame is not a number
 -or-
 When setting this property: The given value for frame is not finite
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for frame must be non-negative.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - When setting this property: None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This property only available when System Type is Power and Circuit Type is NOT Space!

