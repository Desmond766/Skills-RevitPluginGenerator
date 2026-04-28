---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalSystem.TrueLoad
source: html/60271c8b-4d64-f629-45cf-7d601651025f.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.TrueLoad Property

The TrueLoad value of the Electrical System.

## Syntax (C#)
```csharp
public double TrueLoad { get; set; }
```

## Remarks
This property is used to retrieve the TrueLoad value of the Electrical System.

## Exceptions
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - When setting this property: None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This property only available when System Type is Power!

