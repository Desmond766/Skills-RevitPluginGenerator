---
kind: method
id: M:Autodesk.Revit.DB.FamilyThermalProperties.Find(Autodesk.Revit.DB.Document,System.String)
source: html/49d9eee6-8634-3567-7f65-d8e346f7872b.htm
---
# Autodesk.Revit.DB.FamilyThermalProperties.Find Method

Finds the thermal properties by the 'id' property of a constructionType node in Constructions.xml.

## Syntax (C#)
```csharp
public static FamilyThermalProperties Find(
	Document pADoc,
	string constructionId
)
```

## Parameters
- **pADoc** (`Autodesk.Revit.DB.Document`) - The document.
- **constructionId** (`System.String`) - The 'id' property of a constructionType node in Constructions.xml

## Returns
The thermal properties found, or Nothing nullptr a null reference ( Nothing in Visual Basic) if no match was found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

