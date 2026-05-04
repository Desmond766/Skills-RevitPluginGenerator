---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightGroupManager.IsLightGroupOn(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/3214ec82-7ec9-ecab-e687-4e282ffe57b5.htm
---
# Autodesk.Revit.DB.Lighting.LightGroupManager.IsLightGroupOn Method

Returns true if the given light group is on

## Syntax (C#)
```csharp
public bool IsLightGroupOn(
	ElementId viewId,
	ElementId groupId
)
```

## Parameters
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The Id of the view
- **groupId** (`Autodesk.Revit.DB.ElementId`) - The Id of the light group

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element Id does not correspond to a 3d view
 -or-
 The given element Id does not correspond to a light group
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

