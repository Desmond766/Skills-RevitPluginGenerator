---
kind: property
id: P:Autodesk.Revit.DB.Structure.LineLoad.ForceVector2
source: html/3b7d9168-aaa1-9efa-cc74-d384736e62c7.htm
---
# Autodesk.Revit.DB.Structure.LineLoad.ForceVector2 Property

The force vector applied to the end point of the line load, oriented according to OrientTo setting.

## Syntax (C#)
```csharp
public XYZ ForceVector2 { get; set; }
```

## Remarks
The default force unit is kN/m for metric, and kip/ft for imperial.
 Use UnitUtils class methods to convert value from or to internal units.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

