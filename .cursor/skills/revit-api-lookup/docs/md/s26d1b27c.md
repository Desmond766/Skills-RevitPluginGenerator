---
kind: method
id: M:Autodesk.Revit.DB.DimensionType.SetOrdinateDimensionSetting(Autodesk.Revit.DB.OrdinateDimensionSetting)
source: html/b6201e90-b02d-a2a0-a239-9230f79e8a20.htm
---
# Autodesk.Revit.DB.DimensionType.SetOrdinateDimensionSetting Method

Sets the ordinate dimension settings for this DimensionType.

## Syntax (C#)
```csharp
public void SetOrdinateDimensionSetting(
	OrdinateDimensionSetting ordinateDimSetting
)
```

## Parameters
- **ordinateDimSetting** (`Autodesk.Revit.DB.OrdinateDimensionSetting`) - The new ordinate dimension settings.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The origin tick mark id in the Ordinate Dimension Setting is invalid for the dimension style.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This DimensionType cannot be assigned ordinate dimension settings, as it is not a linear DimensionType or its Dimension String Type parameter is not set to Ordinate.

