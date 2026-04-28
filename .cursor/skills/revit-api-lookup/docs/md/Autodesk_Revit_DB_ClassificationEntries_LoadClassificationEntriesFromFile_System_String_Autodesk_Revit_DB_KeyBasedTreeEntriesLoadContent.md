---
kind: method
id: M:Autodesk.Revit.DB.ClassificationEntries.LoadClassificationEntriesFromFile(System.String,Autodesk.Revit.DB.KeyBasedTreeEntriesLoadContent)
source: html/5f2df0e9-2900-6e7a-3c98-6842b3758752.htm
---
# Autodesk.Revit.DB.ClassificationEntries.LoadClassificationEntriesFromFile Method

Loads the contents of a classification text file into the provided KeyBasedTreeEntriesLoadContent.

## Syntax (C#)
```csharp
public static bool LoadClassificationEntriesFromFile(
	string filePath,
	KeyBasedTreeEntriesLoadContent loadContent
)
```

## Parameters
- **filePath** (`System.String`) - The full path of the existing classification file.
- **loadContent** (`Autodesk.Revit.DB.KeyBasedTreeEntriesLoadContent`) - The classification entries read from the filePath will be added to this object.
 A KeyBasedTreeEntriesLoadContent object will also be updated to contain status information,
 including information about any errors that occurred while reading the keynote entries from
 the specified file.

## Returns
True if reading the keynote file succeeds; False if the classification file cannot be read.

## Remarks
The entries read from the file will be added to any existing entries read from other files before this reading operation
 in the provided KeyBasedTreeEntriesLoadContent.
 if file A was read, and then file B was failed to read, all the entries from file A will still be there to build KeynoteEntries object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - filePath is an empty string.
 -or-
 The KeyBasedTreeEntries object owned by this KeyBasedTreeEntriesLoadContent object is built already.
 Adding more KeyBasedTreeEntries as well as repeated building, is not supported.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidPathArgumentException** - The destination file name includes one or more invalid characters.

