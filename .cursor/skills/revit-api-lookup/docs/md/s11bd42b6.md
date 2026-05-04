---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarCurvesData.CanAddBarGeometry
source: html/a7ffdbd4-6702-2c77-eedc-bf03e60663c0.htm
---
# Autodesk.Revit.DB.Structure.RebarCurvesData.CanAddBarGeometry Method

If the layout rule is Singe or FixedNumber or NumberWithSpacing this function will return true if getNumberOfBarGeometry() is less getBarsNumber(), false otherwise. If the layout rule is MaximumSpacing or MinimumClearSpacing this function will return always true.

## Syntax (C#)
```csharp
public bool CanAddBarGeometry()
```

## Returns
Returns true if we can add more bar geometry for the current layout, false otherwise.

