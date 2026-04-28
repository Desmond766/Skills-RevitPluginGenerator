---
kind: method
id: M:Autodesk.Revit.DB.ExportLayerInfo.AddCutLayerModifier(Autodesk.Revit.DB.LayerModifier)
source: html/21ab97e0-269b-9d13-2c7f-84ac30e84f76.htm
---
# Autodesk.Revit.DB.ExportLayerInfo.AddCutLayerModifier Method

Adds a cut layer modifier to the layer info.

## Syntax (C#)
```csharp
public void AddCutLayerModifier(
	LayerModifier layerModifier
)
```

## Parameters
- **layerModifier** (`Autodesk.Revit.DB.LayerModifier`) - The cut layer modifier.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The separator string contains one or more prohibited characters.
 -or-
 The modifier type already exists in the cut layer info.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

