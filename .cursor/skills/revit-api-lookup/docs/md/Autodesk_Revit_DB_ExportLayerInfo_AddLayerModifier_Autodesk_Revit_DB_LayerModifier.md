---
kind: method
id: M:Autodesk.Revit.DB.ExportLayerInfo.AddLayerModifier(Autodesk.Revit.DB.LayerModifier)
source: html/9d0be239-72cd-958d-4cf7-39e868b9a6e8.htm
---
# Autodesk.Revit.DB.ExportLayerInfo.AddLayerModifier Method

Adds a project layer modifier to the layer info.

## Syntax (C#)
```csharp
public void AddLayerModifier(
	LayerModifier layerModifier
)
```

## Parameters
- **layerModifier** (`Autodesk.Revit.DB.LayerModifier`) - The project layer modifier.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The separator string contains one or more prohibited characters.
 -or-
 The modifier type already exists in the layer info.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

