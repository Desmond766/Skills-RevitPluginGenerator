---
kind: method
id: M:Autodesk.Revit.DB.DimensionType.CanHaveOrdinateDimensionSetting
source: html/aaab2cfd-af6c-9ef4-2754-91f2be6ee5bd.htm
---
# Autodesk.Revit.DB.DimensionType.CanHaveOrdinateDimensionSetting Method

Checks whether this DimensionType can have an ordinate dimension settings.

## Syntax (C#)
```csharp
public bool CanHaveOrdinateDimensionSetting()
```

## Returns
True when the DimensionType is linear and the Dimension String Type parameter is ordinate, false otherwise.

## Remarks
It returns true when the DimensionType is linear and when Dimension String Type parameter is set to Ordinate.

