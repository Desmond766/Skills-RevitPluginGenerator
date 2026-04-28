---
kind: property
id: P:Autodesk.Revit.DB.Structure.PointLoad.MomentVector
source: html/ae7ef94a-aaa7-a5d5-a567-3108a351c177.htm
---
# Autodesk.Revit.DB.Structure.PointLoad.MomentVector Property

The moment vector applied to the point load, oriented according to OrientTo setting.

## Syntax (C#)
```csharp
public XYZ MomentVector { get; set; }
```

## Remarks
The default force unit is kN-m for metric, and kip-ft for imperial.
 Use UnitUtils class methods to convert value from or to internal units.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

