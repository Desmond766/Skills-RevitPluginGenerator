---
kind: property
id: P:Autodesk.Revit.DB.RoutingConditions.PreferredJunctionType
source: html/476ce25e-b865-5205-6199-ec31b922de19.htm
---
# Autodesk.Revit.DB.RoutingConditions.PreferredJunctionType Property

The junction type (Tee or Tap) to select if defined fittings of both junction types meet all routing conditions.

## Syntax (C#)
```csharp
public PreferredJunctionType PreferredJunctionType { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - When setting this property: None of the following disciplines is enabled: Mechanical Electrical Piping.

