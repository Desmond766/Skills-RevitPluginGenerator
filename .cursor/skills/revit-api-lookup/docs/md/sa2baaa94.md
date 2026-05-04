---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalSystem.Rating
source: html/d72e9aee-81c5-bebc-555d-fe126ea3ab04.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.Rating Property

The Rating value of the Electrical System.

## Syntax (C#)
```csharp
public double Rating { get; set; }
```

## Remarks
This property is used to retrieve the Rating value of the Electrical System.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for rating is not a number
 -or-
 When setting this property: The given value for rating is not finite
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for rating must be non-negative.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - When setting this property: None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This property only available when System Type is Power!

