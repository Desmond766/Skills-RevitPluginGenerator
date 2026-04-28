---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.GetFromDocument(Autodesk.Revit.DB.Document)
source: html/030c1184-846a-440c-d0df-72e756918d96.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.GetFromDocument Method

Every project document has a EnergyDataSettings element.
 Family documents do not have EnergyDataSettings elements.

## Syntax (C#)
```csharp
public static EnergyDataSettings GetFromDocument(
	Document cda
)
```

## Parameters
- **cda** (`Autodesk.Revit.DB.Document`) - The document.

## Returns
Returns the EnergyDataSettings element or NULL.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

