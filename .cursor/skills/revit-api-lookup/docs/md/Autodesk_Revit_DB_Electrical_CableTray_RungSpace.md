---
kind: property
id: P:Autodesk.Revit.DB.Electrical.CableTray.RungSpace
zh: 桥架、线槽
source: html/071ca21c-4867-72cf-d0ce-c412efe248c5.htm
---
# Autodesk.Revit.DB.Electrical.CableTray.RungSpace Property

**中文**: 桥架、线槽

Distance between two rungs for the ladder cable tray.

## Syntax (C#)
```csharp
public double RungSpace { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The rung space value should be at least equal to or larger than rang width which is 1 inch.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - When setting this property: None of the following disciplines is enabled: Mechanical Electrical Piping.

