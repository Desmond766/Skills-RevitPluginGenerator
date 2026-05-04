---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ElectricalSystem.CircuitPathMode
source: html/78b13087-63d8-090e-92ab-024d06717903.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSystem.CircuitPathMode Property

The circuit path mode of the electrical system.

## Syntax (C#)
```csharp
public ElectricalCircuitPathMode CircuitPathMode { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - When setting this property: None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The electrical system circuit path does not have customized path, so the CircuitPathMode cannot be set as Custom.

