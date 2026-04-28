---
kind: type
id: T:Autodesk.Revit.DB.ExportFontTable
source: html/b3b4f237-f7f3-ced4-be3d-721f7ac05832.htm
---
# Autodesk.Revit.DB.ExportFontTable

A table supporting a mapping of Revit font names to font names that will be set
 in the target export format.

## Syntax (C#)
```csharp
public class ExportFontTable : IEnumerable<KeyValuePair<ExportFontKey, ExportFontInfo>>, 
	IDisposable
```

## Remarks
This table is structured as a mapping from ExportFontKey to
 ExportFontInfo members. The ExportFontKey 
 contains the identification information for the font table: the Revit font name. The
 ExportFontInfo contains the font name to use in the export format. The table can be accessed via direct iteration as a collection of KeyValuePairs, or by traversal of the stored keys
 obtained from GetKeys(), or via specific lookup of a key constructed externally. In all cases, the
 ExportFontInfo returned will be a copy of the ExportFontInfo 
 from the table. In order to make changes to the ExportFontInfo and use those settings during export,
 set the modified ExportFontInfo back into the table using the same key.

