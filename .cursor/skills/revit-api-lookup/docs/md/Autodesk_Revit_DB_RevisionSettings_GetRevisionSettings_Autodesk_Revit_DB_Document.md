---
kind: method
id: M:Autodesk.Revit.DB.RevisionSettings.GetRevisionSettings(Autodesk.Revit.DB.Document)
source: html/934375fa-4e83-b988-981a-05d59c78b74a.htm
---
# Autodesk.Revit.DB.RevisionSettings.GetRevisionSettings Method

Returns the RevisionSettings for the given project document.

## Syntax (C#)
```csharp
public static RevisionSettings GetRevisionSettings(
	Document ccda
)
```

## Parameters
- **ccda** (`Autodesk.Revit.DB.Document`) - The document to get the RevisionSettings from.

## Returns
The RevisionSettings for the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - ccda is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

