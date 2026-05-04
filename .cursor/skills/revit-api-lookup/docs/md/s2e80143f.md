---
kind: property
id: P:Autodesk.Revit.DB.Structure.LineLoad.MomentVector1
source: html/0094b002-656b-9c6b-2a9c-9a4d9eb97705.htm
---
# Autodesk.Revit.DB.Structure.LineLoad.MomentVector1 Property

The moment vector applied to the start point of the line load, oriented according to OrientTo setting.

## Syntax (C#)
```csharp
public XYZ MomentVector1 { get; set; }
```

## Remarks
The default force unit is kN-m/m for metric, and kip-ft/ft for imperial.
 Use UnitUtils class methods to convert value from or to internal units.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

