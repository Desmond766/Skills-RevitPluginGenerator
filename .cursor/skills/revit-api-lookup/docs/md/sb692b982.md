---
kind: method
id: M:Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults.GetFileSyntaxErrors
source: html/03139947-dff9-6122-f235-6f8d1cba7c20.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults.GetFileSyntaxErrors Method

Gets all the records in the key-based tree data text file that could not be parsed into KeyBasedTreeEntries.

## Syntax (C#)
```csharp
public IList<string> GetFileSyntaxErrors()
```

## Returns
An array of strings that are copies of the records in the text file that could not be parsed.

## Remarks
Only applies to KeyBasedTreeEntries built from text files.

