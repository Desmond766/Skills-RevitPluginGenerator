---
kind: method
id: M:Autodesk.Revit.DB.ExportPDFSettings.GetActivePredefinedSettings(Autodesk.Revit.DB.Document)
source: html/2ccf1b3b-786a-4cb4-c9e9-962c42a05d92.htm
---
# Autodesk.Revit.DB.ExportPDFSettings.GetActivePredefinedSettings Method

Gets the active settings element in the document.

## Syntax (C#)
```csharp
public static ExportPDFSettings GetActivePredefinedSettings(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to find the active settings.

## Returns
The active settings, or Nothing nullptr a null reference ( Nothing in Visual Basic) if none.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

