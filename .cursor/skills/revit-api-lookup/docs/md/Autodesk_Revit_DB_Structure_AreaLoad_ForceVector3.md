---
kind: property
id: P:Autodesk.Revit.DB.Structure.AreaLoad.ForceVector3
source: html/000a344f-d68f-8718-c6e5-72edef5ce04c.htm
---
# Autodesk.Revit.DB.Structure.AreaLoad.ForceVector3 Property

The force vector applied to the 3rd reference point of the area load, oriented according to OrientTo setting.

## Syntax (C#)
```csharp
public XYZ ForceVector3 { get; set; }
```

## Remarks
The default force unit is kN/m^2 for metric, and ksf for imperial.
 Use UnitUtils class methods to convert value from or to internal units.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

