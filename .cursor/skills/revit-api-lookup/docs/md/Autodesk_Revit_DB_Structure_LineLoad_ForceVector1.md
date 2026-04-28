---
kind: property
id: P:Autodesk.Revit.DB.Structure.LineLoad.ForceVector1
source: html/50cbbc07-492f-b5f3-2753-1da47d52a8db.htm
---
# Autodesk.Revit.DB.Structure.LineLoad.ForceVector1 Property

The force vector applied to the start point of the line load, oriented according to OrientTo setting.

## Syntax (C#)
```csharp
public XYZ ForceVector1 { get; set; }
```

## Remarks
The default force unit is kN/m for metric, and kip/ft for imperial.
 Use UnitUtils class methods to convert value from or to internal units.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

