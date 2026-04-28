---
kind: method
id: M:Autodesk.Revit.DB.ExportLayerTable.GetAvaliableLayerModifierTypes(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExportLayerKey)
source: html/688f2403-1d4b-2498-8365-c5480fb9a080.htm
---
# Autodesk.Revit.DB.ExportLayerTable.GetAvaliableLayerModifierTypes Method

Gets all the avaliable layer modifier types for the layer key.

## Syntax (C#)
```csharp
public static IList<ModifierType> GetAvaliableLayerModifierTypes(
	Document document,
	ExportLayerKey exportLayerKey
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - A Revit document to retrieve avaliable layer modifier types from.
- **exportLayerKey** (`Autodesk.Revit.DB.ExportLayerKey`) - The export layer key to specify wich category and subCategory will be used to get the layer modifier types.

## Returns
The layer modifier types.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

