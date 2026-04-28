---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSetting.GetSpecificFittingAngles
source: html/b0948977-6da0-58fb-3a38-5d10e685ecc4.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSetting.GetSpecificFittingAngles Method

Gets the list of specific fitting angles.

## Syntax (C#)
```csharp
public IList<double> GetSpecificFittingAngles()
```

## Returns
Angles (in degrees).

## Remarks
Revit will only use the angles specified during the cable tray or conduit layout or modifying the layout.
 When laying out the cable tray or conduit, if the angle between two cable trays or conduits is close to the allowed angle,
 The specific angle is used for that cable tray or conduit fitting.

