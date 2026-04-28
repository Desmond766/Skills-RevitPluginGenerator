---
kind: property
id: P:Autodesk.Revit.DB.Structure.AreaLoad.ForceVector2
source: html/c5f25cdc-7120-6e86-b0ec-70cc4ffec360.htm
---
# Autodesk.Revit.DB.Structure.AreaLoad.ForceVector2 Property

The force vector applied to the 2nd reference point of the area load, oriented according to OrientTo setting.

## Syntax (C#)
```csharp
public XYZ ForceVector2 { get; set; }
```

## Remarks
The default force unit is kN/m^2 for metric, and ksf for imperial.
 Use UnitUtils class methods to convert value from or to internal units.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

