---
kind: property
id: P:Autodesk.Revit.DB.Structure.AreaLoad.ForceVector1
source: html/2fa5cdff-3d4c-a479-fbc6-f2bae9c06884.htm
---
# Autodesk.Revit.DB.Structure.AreaLoad.ForceVector1 Property

The force vector applied to the 1st reference point of the area load, oriented according to OrientTo setting.

## Syntax (C#)
```csharp
public XYZ ForceVector1 { get; set; }
```

## Remarks
The default force unit is kN/m^2 for metric, and ksf for imperial.
 Use UnitUtils class methods to convert value from or to internal units.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

