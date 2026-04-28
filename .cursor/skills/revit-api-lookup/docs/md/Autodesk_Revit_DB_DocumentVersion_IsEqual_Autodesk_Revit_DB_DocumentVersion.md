---
kind: method
id: M:Autodesk.Revit.DB.DocumentVersion.IsEqual(Autodesk.Revit.DB.DocumentVersion)
source: html/8464cbda-4d08-cab7-1773-f3cbf73ab584.htm
---
# Autodesk.Revit.DB.DocumentVersion.IsEqual Method

Checks whether two DocumentVersions are identical.
 They are identical if both the GUID and number of saves
 are equal. If two DocumentVersions are identical, they
 come from the same document, with the same set of changes.

## Syntax (C#)
```csharp
public bool IsEqual(
	DocumentVersion other
)
```

## Parameters
- **other** (`Autodesk.Revit.DB.DocumentVersion`) - The DocumentVersion to compare to this DocumentVersion.

## Returns
True if the two DocumentVersions are equal. False otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

