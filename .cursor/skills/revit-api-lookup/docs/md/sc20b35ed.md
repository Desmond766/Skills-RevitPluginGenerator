---
kind: method
id: M:Autodesk.Revit.DB.LabelUtils.GetLabelFor(Autodesk.Revit.DB.Analysis.gbXMLBuildingType,Autodesk.Revit.DB.Document)
source: html/3e86f8bf-b9b6-5383-3f65-0a9c9a5acf61.htm
---
# Autodesk.Revit.DB.LabelUtils.GetLabelFor Method

Gets the user-visible name for a gbXMLBuildingType.

## Syntax (C#)
```csharp
public static string GetLabelFor(
	gbXMLBuildingType buildingType,
	Document document
)
```

## Parameters
- **buildingType** (`Autodesk.Revit.DB.Analysis.gbXMLBuildingType`) - The gbXMLBuildingType to get the user-visible name.
- **document** (`Autodesk.Revit.DB.Document`) - The document from which to get the gbXMLBuildingType.

## Remarks
The name is obtained in the current Revit language.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input gXMLBuildingType is not available in the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

