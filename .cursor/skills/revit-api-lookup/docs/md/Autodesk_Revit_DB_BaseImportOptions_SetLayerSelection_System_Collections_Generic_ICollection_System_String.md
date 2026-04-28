---
kind: method
id: M:Autodesk.Revit.DB.BaseImportOptions.SetLayerSelection(System.Collections.Generic.ICollection{System.String})
source: html/d9a9c5be-f8b4-a92c-be88-ef2ec7d9394e.htm
---
# Autodesk.Revit.DB.BaseImportOptions.SetLayerSelection Method

Set the layers name which user want to import into Revit.

## Syntax (C#)
```csharp
public void SetLayerSelection(
	ICollection<string> layerSelection
)
```

## Parameters
- **layerSelection** (`System.Collections.Generic.ICollection < String >`) - The layers imported into Revit.

## Remarks
If user don't set any layer selection, all layers would be imported into Revit for dgn.
 But for dwg|dxf, all layers (or visible layers, it is up to visibleLayersOnly was set or not) would be imported into Revit.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

