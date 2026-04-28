---
kind: method
id: M:Autodesk.Revit.DB.KeyBasedTreeEntries.FindEntry(System.String)
source: html/1fc6cf20-bc62-3c74-f1bf-49676a30f3cd.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntries.FindEntry Method

Finds the KeyBasedTreeEntry associated with the given key value.

## Syntax (C#)
```csharp
public KeyBasedTreeEntry FindEntry(
	string key
)
```

## Parameters
- **key** (`System.String`) - The specified key value.

## Returns
The KeyBasedTreeEntry corresponds to the given key value.

## Remarks
If no matching KeyBasedTreeEntry can be found, null will be returned;
 The given key value cannot be an empty string.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - key is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

