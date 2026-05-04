---
kind: method
id: M:Autodesk.Revit.DB.ColorFillScheme.SetEntries(System.Collections.Generic.IList{Autodesk.Revit.DB.ColorFillSchemeEntry})
source: html/a2099010-ccb3-5ad1-5e80-5209422add42.htm
---
# Autodesk.Revit.DB.ColorFillScheme.SetEntries Method

Update scheme entries in batch mode.

## Syntax (C#)
```csharp
public void SetEntries(
	IList<ColorFillSchemeEntry> entries
)
```

## Parameters
- **entries** (`System.Collections.Generic.IList < ColorFillSchemeEntry >`) - Collection of new entries.

## Remarks
For by range scheme: If there is only one entry in the input, Revit will generate another one automatically. If the first existing entry is found in the input, it will be updated, otherwise keep not changed. If the other existing entries are found in the input, they will be updated, otherwise removed. For by value scheme: For an existing entry that is in use, it will be updated if it can be found in the input, otherwise keep not changed. For an existing entry that is no in use, it will be updated if it can be found in the input, otherwise removed. If an entry in the input cannot be found in the existing entries, it will be added to the scheme. To make sure that entry can be added to the scheme, call [M:Autodesk.Revit.DB.ColorFillScheme.AreEntriesConsistentWithScheme(System.Collections.Generic.IList`1{Autodesk.Revit.DB.ColorFillSchemeEntry})] first.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There exists entries whose values are duplicated in the input entries.
 -or-
 There exists at lease one entry whose value is invalid for the scheme in the input entries.
 -or-
 There exists at least one entry in the input entries whose storage type is different with the scheme.
 -or-
 There exists at least one entry in the input entries whose fill pattern is invalid for color fill scheme.
 -or-
 There exists some inconsistent in the input entries.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

