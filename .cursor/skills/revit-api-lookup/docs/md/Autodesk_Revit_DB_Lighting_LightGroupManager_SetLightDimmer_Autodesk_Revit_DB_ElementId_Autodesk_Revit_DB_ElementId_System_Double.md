---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightGroupManager.SetLightDimmer(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Double)
source: html/118435ea-6e2d-1299-a016-8e0f47b563c4.htm
---
# Autodesk.Revit.DB.Lighting.LightGroupManager.SetLightDimmer Method

Sets the dimmer value for the given light for rendering the given view

## Syntax (C#)
```csharp
public void SetLightDimmer(
	ElementId viewId,
	ElementId lightId,
	double dimmingValue
)
```

## Parameters
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The Id of the view
- **lightId** (`Autodesk.Revit.DB.ElementId`) - The Id of the light to turn on or off
- **dimmingValue** (`System.Double`) - The dimmer value to set int the range of [0.0, 1.0]

## Remarks
The dimmer value is in the range [0.0, 1.0] with 0.0 being totally dimmed and 1.0 being totally on

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element Id does not correspond to a 3d view
 -or-
 The given element Id does not correspond to a light instance
 -or-
 The given dimming value is not in the range [0.0, 1.0]
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

