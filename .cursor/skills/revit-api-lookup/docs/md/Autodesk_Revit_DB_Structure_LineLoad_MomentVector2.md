---
kind: property
id: P:Autodesk.Revit.DB.Structure.LineLoad.MomentVector2
source: html/ca5f8ab4-f017-81f7-46b9-de5154beaa70.htm
---
# Autodesk.Revit.DB.Structure.LineLoad.MomentVector2 Property

The moment vector applied to the end point of the line load, oriented according to OrientTo setting.

## Syntax (C#)
```csharp
public XYZ MomentVector2 { get; set; }
```

## Remarks
The default force unit is kN-m/m for metric, and kip-ft/ft for imperial.
 Use UnitUtils class methods to convert value from or to internal units.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

