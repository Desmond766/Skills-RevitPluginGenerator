---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightGroup.AddLight(Autodesk.Revit.DB.ElementId)
source: html/c415f9ac-ecba-78d2-3057-ce29b0e43837.htm
---
# Autodesk.Revit.DB.Lighting.LightGroup.AddLight Method

Add a new light instance to the group

## Syntax (C#)
```csharp
public void AddLight(
	ElementId lightId
)
```

## Parameters
- **lightId** (`Autodesk.Revit.DB.ElementId`) - The ID of the light instance to add to the group

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element ID does not correspond to a light instance
 -or-
 The light instance is in this LightGroup
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

