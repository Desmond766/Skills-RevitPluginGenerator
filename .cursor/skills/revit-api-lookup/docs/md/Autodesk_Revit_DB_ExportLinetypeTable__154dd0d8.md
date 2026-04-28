---
kind: type
id: T:Autodesk.Revit.DB.ExportLinetypeTable
source: html/136c6197-2f4c-5686-e70c-09cee48b71ad.htm
---
# Autodesk.Revit.DB.ExportLinetypeTable

A table supporting a mapping of linetypes in Revit to linetype names that will be set
 in the target export format.

## Syntax (C#)
```csharp
public class ExportLinetypeTable : IEnumerable<KeyValuePair<ExportLinetypeKey, ExportLinetypeInfo>>, 
	IDisposable
```

## Remarks
This table is structured as a mapping from ExportLinetypeKey to
 ExportLinetypeInfo members. The ExportLinetypeKey 
 contains the identification information for the pattern table: the Revit linetype name. The
 ExportLinetypeInfo contains the linetype name to use in the export format. The table can be accessed via direct iteration as a collection of KeyValuePairs, or by traversal of the stored keys
 obtained from GetKeys(), or via specific lookup of a key constructed externally. In all cases, the
 ExportLinetypeInfo returned will be a copy of the ExportLinetypeInfo 
 from the table. In order to make changes to the ExportLinetypeInfo and use those settings during export,
 set the modified ExportLinetypeInfo back into the table using the same key.

