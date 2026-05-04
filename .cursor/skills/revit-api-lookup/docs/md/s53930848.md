---
kind: type
id: T:Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults
source: html/f5208754-8b50-cfff-f2ca-f31a0645fbd5.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults

This class contains the results and status information regarding an attempt to load the KeyBasedTreeEntries from an External Resource.

## Syntax (C#)
```csharp
public class KeyBasedTreeEntriesLoadResults : IDisposable
```

## Remarks
A KeyBasedTreeEntriesLoadResults object is returned by the KeynoteTable or AssemblyCodeTable API methods LoadFrom() and Reload() so that callers can
 determine whether the KeynoteTable or AssemblyCodeTable was updated successfully and what, if any, errors occurred.

