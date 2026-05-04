---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightGroup.RemoveLight(Autodesk.Revit.DB.ElementId)
source: html/ca880392-46cf-43a0-3c39-0168c5c1ccaa.htm
---
# Autodesk.Revit.DB.Lighting.LightGroup.RemoveLight Method

Remove the given light instance from the set of light instances in this group

## Syntax (C#)
```csharp
public void RemoveLight(
	ElementId lightId
)
```

## Parameters
- **lightId** (`Autodesk.Revit.DB.ElementId`) - The light instance to remove

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The light instance is not in this LightGroup
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

