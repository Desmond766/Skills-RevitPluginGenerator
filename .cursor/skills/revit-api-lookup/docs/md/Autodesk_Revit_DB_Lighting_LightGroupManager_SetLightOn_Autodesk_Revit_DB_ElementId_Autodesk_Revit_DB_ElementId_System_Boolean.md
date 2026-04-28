---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightGroupManager.SetLightOn(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/10f64022-fbdb-8a77-db6b-7d60832e6447.htm
---
# Autodesk.Revit.DB.Lighting.LightGroupManager.SetLightOn Method

Turns the given light on or off for rendering the given view depending on the bool argument

## Syntax (C#)
```csharp
public void SetLightOn(
	ElementId viewId,
	ElementId lightId,
	bool turnOn
)
```

## Parameters
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The Id of the view
- **lightId** (`Autodesk.Revit.DB.ElementId`) - The Id of the light to turn on or off
- **turnOn** (`System.Boolean`) - Turns the light on if true, off if false

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element Id does not correspond to a 3d view
 -or-
 The given element Id does not correspond to a light instance
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

