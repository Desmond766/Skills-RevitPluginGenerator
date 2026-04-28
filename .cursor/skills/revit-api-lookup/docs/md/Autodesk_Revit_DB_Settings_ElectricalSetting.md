---
kind: property
id: P:Autodesk.Revit.DB.Settings.ElectricalSetting
source: html/9bbcc232-2cc1-ebeb-2390-677322054a38.htm
---
# Autodesk.Revit.DB.Settings.ElectricalSetting Property

Retrieves an object that provides access to all the electrical settings include voltage type, distribution system type,
demand factor, wire type in the Autodesk Revit application and project.

## Syntax (C#)
```csharp
public ElectricalSetting ElectricalSetting { get; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Electrical settings can be accessed only if Revit MEP product is available.

