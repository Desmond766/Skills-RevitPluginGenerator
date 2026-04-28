---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalSystem.NeutralConductorsNumber
source: html/9f62c1f5-a9c9-16ee-e891-81171f131fc7.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.NeutralConductorsNumber Property

The NeutralConductors Number of the Electrical System.

## Syntax (C#)
```csharp
public int NeutralConductorsNumber { get; set; }
```

## Remarks
This property is used to retrieve the NeutralConductors Number of the Electrical System.

## Exceptions
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - When setting this property: None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This property only available when System Type is Power!

