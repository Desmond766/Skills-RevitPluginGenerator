---
kind: type
id: T:Autodesk.Revit.DB.ExportPatternTable
source: html/3e87bc0e-e04b-f76a-2b06-82e951b5aec2.htm
---
# Autodesk.Revit.DB.ExportPatternTable

A table supporting a mapping of FillPatterns in Revit to pattern names that will be set
 in the target export format.

## Syntax (C#)
```csharp
public class ExportPatternTable : IEnumerable<KeyValuePair<ExportPatternKey, ExportPatternInfo>>, 
	IDisposable
```

## Remarks
This table is structured as a mapping from ExportPatternKey to
 ExportPatternInfo members. The ExportPatternKey 
 contains the identification information for the pattern table: the Revit fill pattern type and name. The
 ExportPatternInfo contains the pattern name to use in the export format. The table can be accessed via direct iteration as a collection of KeyValuePairs, or by traversal of the stored keys
 obtained from GetKeys(), or via specific lookup of a key constructed externally. In all cases, the
 ExportPatternInfo returned will be a copy of the ExportPatternInfo 
 from the table. In order to make changes to the ExportPatternInfo and use those settings during export,
 set the modified ExportPatternInfo back into the table using the same key.

