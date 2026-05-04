---
kind: method
id: M:Autodesk.Revit.DB.AlphanumericRevisionSettings.IsEqual(Autodesk.Revit.DB.AlphanumericRevisionSettings)
source: html/c1a2f01a-8bfd-b990-c8da-bb8e7804e0be.htm
---
# Autodesk.Revit.DB.AlphanumericRevisionSettings.IsEqual Method

Determines whether a specified AlphanumericRevisionSettings is the same as 'this'.

## Syntax (C#)
```csharp
public bool IsEqual(
	AlphanumericRevisionSettings other
)
```

## Parameters
- **other** (`Autodesk.Revit.DB.AlphanumericRevisionSettings`) - The AlphanumericRevisionSettings object to be compared with 'this'.

## Returns
True, if two AlphanumericRevisionSettings are the same.

## Remarks
The two AlphanumericRevisionSettings are regarded as the same only if they have the same
 revision numbering sequence, and the same prefix and suffix strings.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

