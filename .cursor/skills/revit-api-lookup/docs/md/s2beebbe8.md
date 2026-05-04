---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightGroupManager.SetLightGroupOn(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/33b097c4-15ee-ffec-e9a9-0efdec482e12.htm
---
# Autodesk.Revit.DB.Lighting.LightGroupManager.SetLightGroupOn Method

Turns the given light group on or off for rendering the given view depending on the bool argument

## Syntax (C#)
```csharp
public void SetLightGroupOn(
	ElementId viewId,
	ElementId groupId,
	bool turnOn
)
```

## Parameters
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The Id of the view
- **groupId** (`Autodesk.Revit.DB.ElementId`) - The Id of the light group
- **turnOn** (`System.Boolean`) - Turns the light group on if true, off if false

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element Id does not correspond to a 3d view
 -or-
 The given element Id does not correspond to a light group
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

