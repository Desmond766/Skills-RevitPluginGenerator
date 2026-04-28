---
kind: method
id: M:Autodesk.Revit.DB.FabricationServiceSettings.GetFabricationServiceSettings(Autodesk.Revit.DB.Document)
source: html/cce22614-e34d-b846-ff1c-20169f128500.htm
---
# Autodesk.Revit.DB.FabricationServiceSettings.GetFabricationServiceSettings Method

Gets the settings element in the document.

## Syntax (C#)
```csharp
public static FabricationServiceSettings GetFabricationServiceSettings(
	Document doc
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document where the settings element is found.

## Returns
The element which stores the fabrication service settings for the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

