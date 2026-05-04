---
kind: type
id: T:Autodesk.Revit.DB.ExportLayerTable
source: html/e68ce1c7-a922-d1b7-53bb-f832a4bad273.htm
---
# Autodesk.Revit.DB.ExportLayerTable

A table supporting a mapping of category and subcategory to layer name and other layer properties that will be set
 in the target export format.

## Syntax (C#)
```csharp
public class ExportLayerTable : IEnumerable<KeyValuePair<ExportLayerKey, ExportLayerInfo>>, 
	IDisposable
```

## Remarks
This table is structured as a mapping from ExportLayerKey to
 ExportLayerInfo members. The ExportLayerKey 
 contains the identification information for the layer table: the Revit category and subcategory names. In addition,
 the key contains a SpecialType member used only to represent non-Revit categories
 that can be assigned specific layer information on export. The ExportLayerInfo 
 contains the exported layer name, color name, and layer modifiers for standard and cut representations. The table can be accessed via direct iteration as a collection of KeyValuePairs, or by traversal of the stored keys
 obtained from GetKeys(), or via specific lookup of a key constructed externally. In all cases, the
 ExportLayerInfo returned will be a copy of the ExportLayerInfo 
 from the table. In order to make changes to the ExportLayerInfo and use those settings during export,
 set the modified ExportLayerInfo back into the table using the same key.

