---
kind: method
id: M:Autodesk.Revit.DB.WorksetDefaultVisibilitySettings.GetWorksetDefaultVisibilitySettings(Autodesk.Revit.DB.Document)
source: html/9dc63e54-f45b-b479-1b61-50578abe3e6f.htm
---
# Autodesk.Revit.DB.WorksetDefaultVisibilitySettings.GetWorksetDefaultVisibilitySettings Method

Get the WorksetDefaultVisibilitySettings of the document.

## Syntax (C#)
```csharp
public static WorksetDefaultVisibilitySettings GetWorksetDefaultVisibilitySettings(
	Document aDoc
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document.

## Returns
The WorksetDefaultVisibilitySettings of the document.

## Remarks
WorksetDefaultVisibilitySettings is not available in family documents.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - WorksetDefaultVisibilitySettings is not applicable to family documents.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

