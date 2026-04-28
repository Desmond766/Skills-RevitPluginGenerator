---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightGroupManager.IsLightOn(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/b3ad0ab8-f465-9e6f-3194-ae5530a8892f.htm
---
# Autodesk.Revit.DB.Lighting.LightGroupManager.IsLightOn Method

Returns true if the given light is on for rendering the given view

## Syntax (C#)
```csharp
public bool IsLightOn(
	ElementId viewId,
	ElementId lightId
)
```

## Parameters
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The Id of the view
- **lightId** (`Autodesk.Revit.DB.ElementId`) - The Id of the light

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element Id does not correspond to a 3d view
 -or-
 The given element Id does not correspond to a light instance
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

