---
kind: method
id: M:Autodesk.Revit.DB.RevisionSettings.RoundRevisionCloudSpacing(Autodesk.Revit.DB.Document,System.Double)
source: html/a368d940-b037-9f40-e341-180d8a91036b.htm
---
# Autodesk.Revit.DB.RevisionSettings.RoundRevisionCloudSpacing Method

Rounds the given revision cloud spacing value according to the document's settings.

## Syntax (C#)
```csharp
public static double RoundRevisionCloudSpacing(
	Document ccda,
	double rawValue
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`) - The document to use for rounding.
- **rawValue** (`System.Double`) - The unrounded value.

## Returns
The rounded revision cloud spacing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

