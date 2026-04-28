---
kind: method
id: M:Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults.GetFileReadErrors
source: html/770e8df1-2e73-aec3-6977-279ae4751d06.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults.GetFileReadErrors Method

Gets the names of any files which could not be read due to access errors.

## Syntax (C#)
```csharp
public IList<string> GetFileReadErrors()
```

## Returns
An array of strings containing the filenames of files which could not be read.

## Remarks
Only applies to KeyBasedTreeEntries built from text files.

