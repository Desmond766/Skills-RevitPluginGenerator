---
kind: property
id: P:Autodesk.Revit.DB.Structure.PointLoad.ForceVector
source: html/b21413c1-0b57-a52a-6de4-a43e4817e169.htm
---
# Autodesk.Revit.DB.Structure.PointLoad.ForceVector Property

The force vector applied to the point load, oriented according to OrientTo setting.

## Syntax (C#)
```csharp
public XYZ ForceVector { get; set; }
```

## Remarks
The default force unit is kN for metric, and kip for imperial.
 Use UnitUtils class methods to convert value from or to internal units.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

