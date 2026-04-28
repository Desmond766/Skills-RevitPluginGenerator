---
kind: method
id: M:Autodesk.Revit.DB.MultipleValuesIndicationSettings.GetMultipleValuesIndicationSettings(Autodesk.Revit.DB.Document)
source: html/9f006777-7f5e-4bac-a7c9-ce951c0184ac.htm
---
# Autodesk.Revit.DB.MultipleValuesIndicationSettings.GetMultipleValuesIndicationSettings Method

Returns the MultipleValuesIndicationSettings element for a given document.

## Syntax (C#)
```csharp
public static MultipleValuesIndicationSettings GetMultipleValuesIndicationSettings(
	Document cda
)
```

## Parameters
- **cda** (`Autodesk.Revit.DB.Document`) - The document for which to get the MultipleValuesIndicationSettings element.

## Returns
Returns the MultipleValuesIndicationSettings element in project documents
 or Nothing nullptr a null reference ( Nothing in Visual Basic) for family documents .

## Remarks
Project documents have a MultipleValuesIndicationSettings element, one per document.
 Family documents do not have MultipleValuesIndicationSettings elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

