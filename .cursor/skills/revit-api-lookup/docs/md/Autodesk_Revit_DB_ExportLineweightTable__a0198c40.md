---
kind: type
id: T:Autodesk.Revit.DB.ExportLineweightTable
source: html/5620708e-0c7c-ced6-9887-0237a9229800.htm
---
# Autodesk.Revit.DB.ExportLineweightTable

A table supporting a mapping of line weights in Revit to line weight names that will be set
 in the target export format.

## Syntax (C#)
```csharp
public class ExportLineweightTable : IEnumerable<KeyValuePair<ExportLineweightKey, ExportLineweightInfo>>, 
	IDisposable
```

## Remarks
This table is structured as a mapping from ExportLineweightKey to
 ExportLineweightInfo members. The ExportLineweightKey 
 contains the identification information for the pattern table: the Revit line weight. The
 ExportLineweightInfo contains the line weight to use in the export format. The table can be accessed via direct iteration as a collection of KeyValuePairs, or by traversal of the stored keys
 obtained from GetKeys(), or via specific lookup of a key constructed externally. In all cases, the
 ExportLineweightInfo returned will be a copy of the ExportLineweightInfo 
 from the table. In order to make changes to the ExportLineweightInfo and use those settings during export,
 set the modified ExportLineweightInfo back into the table using the same key.

