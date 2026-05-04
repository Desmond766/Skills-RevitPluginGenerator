---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightGroupManager.GetLightDimmer(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/edf4b002-99ec-1073-e150-d924a3253792.htm
---
# Autodesk.Revit.DB.Lighting.LightGroupManager.GetLightDimmer Method

Gets the dimmer value for the given light for rendering the given view

## Syntax (C#)
```csharp
public double GetLightDimmer(
	ElementId viewId,
	ElementId lightId
)
```

## Parameters
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The Id of the view
- **lightId** (`Autodesk.Revit.DB.ElementId`) - The Id of the light to turn on or off

## Remarks
The dimmer value is in the range [0.0, 1.0] with 0.0 being totally dimmed and 1.0 being totally on

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element Id does not correspond to a 3d view
 -or-
 The given element Id does not correspond to a light instance
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

